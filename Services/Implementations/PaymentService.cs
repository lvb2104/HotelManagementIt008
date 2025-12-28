using AutoMapper;

using Gridify;
using Gridify.EntityFramework;

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGridifyMapper<Payment> _gridifyMapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, IGridifyMapper<Payment> gridifyMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _gridifyMapper = gridifyMapper;
        }

        public async Task<Result<PaymentResponseDto>> CreatePaymentAsync(CreatePaymentDto dto)
        {
            try
            {
                var payment = _mapper.Map<Payment>(dto);

                await _unitOfWork.PaymentRepository.AddAsync(payment);
                await _unitOfWork.SaveAsync();

                return await GetPaymentByIdAsync(payment.Id.ToString());
            }
            catch (Exception ex)
            {
                return Result<PaymentResponseDto>.Failure($"Error creating payment: {ex.Message}");
            }
        }

        public async Task<Result<PaymentResponseDto>> GetPaymentByIdAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var guidId))
                    return Result<PaymentResponseDto>.Failure("Invalid payment ID");

                var payment = await _unitOfWork.PaymentRepository.GetAllQueryable()
                    .Include(p => p.Invoices)
                        .ThenInclude(i => i.Booking)
                            .ThenInclude(b => b.Room)
                    .FirstOrDefaultAsync(p => p.Id == guidId);

                if (payment == null)
                    return Result<PaymentResponseDto>.Failure($"Payment with id {id} not found");

                return Result<PaymentResponseDto>.Success(_mapper.Map<PaymentResponseDto>(payment));
            }
            catch (Exception ex)
            {
                return Result<PaymentResponseDto>.Failure($"Error retrieving payment: {ex.Message}");
            }
        }

        public async Task<Result<List<PaymentResponseDto>>> GetAllPaymentsAsync()
        {
            try
            {
                var payments = await _unitOfWork.PaymentRepository.GetAllQueryable()
                    .Where(p => p.DeletedAt == null)
                    .Include(p => p.Invoices)
                    .ToListAsync();

                return Result<List<PaymentResponseDto>>.Success(_mapper.Map<List<PaymentResponseDto>>(payments));
            }
            catch (Exception ex)
            {
                return Result<List<PaymentResponseDto>>.Failure($"Error retrieving all payments: {ex.Message}");
            }
        }

        public async Task<Result<Paging<PaymentResponseDto>>> GetPaymentsAsync(GridifyQuery query)
        {
            try
            {
                IQueryable<Payment> paymentsQuery = _unitOfWork.PaymentRepository.GetAllQueryable()
                    .Include(p => p.Invoices)
                        .ThenInclude(i => i.Booking)
                            .ThenInclude(b => b.Room);

                var pagedPayments = await paymentsQuery.GridifyAsync(query, _gridifyMapper);

                var paymentDtos = _mapper.Map<List<PaymentResponseDto>>(pagedPayments.Data);

                return Result<Paging<PaymentResponseDto>>.Success(new Paging<PaymentResponseDto>
                {
                    Data = paymentDtos,
                    Count = pagedPayments.Count
                });
            }
            catch (Exception ex)
            {
                return Result<Paging<PaymentResponseDto>>.Failure($"Error retrieving payments: {ex.Message}");
            }
        }

        public async Task<Result<PaymentResponseDto>> UpdatePaymentAsync(string id, UpdatePaymentDto dto)
        {
            try
            {
                if (!Guid.TryParse(id, out var guidId))
                    return Result<PaymentResponseDto>.Failure("Invalid payment ID");

                var payment = await _unitOfWork.PaymentRepository.GetByIdAsync(guidId);
                if (payment == null)
                    return Result<PaymentResponseDto>.Failure($"Payment with id {id} not found");

                // Update only provided fields
                if (dto.Method.HasValue) payment.Method = dto.Method.Value;
                if (dto.Amount.HasValue) payment.Amount = dto.Amount.Value;
                if (dto.Status.HasValue) payment.Status = dto.Status.Value;

                await _unitOfWork.PaymentRepository.UpdateAsync(payment);
                await _unitOfWork.SaveAsync();

                return await GetPaymentByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Result<PaymentResponseDto>.Failure($"Error updating payment: {ex.Message}");
            }
        }

        public async Task<Result<bool>> DeletePaymentAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var guidId))
                    return Result<bool>.Failure("Invalid payment ID");

                // Check if payment has linked invoices
                var hasInvoices = await _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .AnyAsync(i => i.PaymentId == guidId);

                if (hasInvoices)
                    return Result<bool>.Failure("Cannot delete payment with linked invoices. Please merge payments instead or delete the invoices first.");

                var success = await _unitOfWork.PaymentRepository.RemoveAsync(guidId);
                if (!success)
                    return Result<bool>.Failure("Payment not found");

                await _unitOfWork.SaveAsync();
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error deleting payment: {ex.Message}");
            }
        }

        public async Task<Result<PaymentResponseDto>> MergePaymentsAsync(MergePaymentsDto dto)
        {
            try
            {
                // Validate target payment exists
                var targetPayment = await _unitOfWork.PaymentRepository.GetByIdAsync(dto.TargetPaymentId);
                if (targetPayment == null)
                    return Result<PaymentResponseDto>.Failure("Target payment not found");

                // Validate and retrieve payments to merge
                var paymentsToMerge = new List<Payment>();
                foreach (var paymentId in dto.PaymentIdsToMerge)
                {
                    var payment = await _unitOfWork.PaymentRepository.GetByIdAsync(paymentId);
                    if (payment == null)
                        return Result<PaymentResponseDto>.Failure($"Payment with id {paymentId} not found");

                    if (payment.Id == dto.TargetPaymentId)
                        return Result<PaymentResponseDto>.Failure("Cannot merge a payment with itself");

                    paymentsToMerge.Add(payment);
                }

                // Get all invoices from payments to merge
                var invoicesToUpdate = await _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .Where(i => dto.PaymentIdsToMerge.Contains(i.PaymentId))
                    .ToListAsync();

                // Update invoices to point to target payment
                foreach (var invoice in invoicesToUpdate)
                {
                    invoice.PaymentId = dto.TargetPaymentId;
                    await _unitOfWork.InvoiceRepository.UpdateAsync(invoice);
                }

                // Update target payment amount (sum of all amounts)
                targetPayment.Amount = paymentsToMerge.Sum(p => p.Amount) + targetPayment.Amount;
                await _unitOfWork.PaymentRepository.UpdateAsync(targetPayment);

                // Soft-delete source payments
                foreach (var payment in paymentsToMerge)
                {
                    await _unitOfWork.PaymentRepository.RemoveAsync(payment.Id);
                }

                await _unitOfWork.SaveAsync();

                return await GetPaymentByIdAsync(dto.TargetPaymentId.ToString());
            }
            catch (Exception ex)
            {
                return Result<PaymentResponseDto>.Failure($"Error merging payments: {ex.Message}");
            }
        }
    }
}
