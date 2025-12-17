using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HotelManagementIt008.Dtos.Requests;
using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Types;

namespace HotelManagementIt008.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<InvoiceResponseDto>> CreateInvoiceAsync(CreateInvoiceDto dto)
        {
            try
            {
                var invoice = _mapper.Map<Invoice>(dto);
                invoice.Status = InvoiceStatus.Pending; // Default to Unpaid/Pending

                await _unitOfWork.InvoiceRepository.AddAsync(invoice);
                await _unitOfWork.SaveAsync();

                // Load relations for response
                var createdInvoice = await _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Booker)
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Room)
                    .FirstOrDefaultAsync(i => i.Id == invoice.Id);

                return Result<InvoiceResponseDto>.Success(_mapper.Map<InvoiceResponseDto>(createdInvoice));
            }
            catch (Exception ex)
            {
                return Result<InvoiceResponseDto>.Failure($"Error creating invoice: {ex.Message}");
            }
        }

        public async Task<Result<InvoiceResponseDto>> GetInvoiceByIdAsync(string id)
        {
            try
            {
                var invoice = await _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Booker)
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Room)
                    .Include(i => i.Payment)
                    .FirstOrDefaultAsync(i => i.Id.ToString() == id);

                if (invoice == null)
                {
                    return Result<InvoiceResponseDto>.Failure($"Invoice with id {id} not found");
                }

                return Result<InvoiceResponseDto>.Success(_mapper.Map<InvoiceResponseDto>(invoice));
            }
            catch (Exception ex)
            {
                return Result<InvoiceResponseDto>.Failure($"Error retrieving invoice: {ex.Message}");
            }
        }

        public async Task<Result<InvoiceResponseDto>> GetInvoiceByBookingIdAsync(string bookingId)
        {
            try
            {
                var invoice = await _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Booker)
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Room)
                    .Include(i => i.Payment)
                    .FirstOrDefaultAsync(i => i.BookingId.ToString() == bookingId);

                if (invoice == null)
                {
                    return Result<InvoiceResponseDto>.Failure($"Invoice for booking {bookingId} not found");
                }

                return Result<InvoiceResponseDto>.Success(_mapper.Map<InvoiceResponseDto>(invoice));
            }
            catch (Exception ex)
            {
                return Result<InvoiceResponseDto>.Failure($"Error retrieving invoice: {ex.Message}");
            }
        }

        public async Task<Result<InvoiceResponseDto>> UpdateInvoiceStatusAsync(string id, InvoiceStatus status)
        {
            try
            {
                var invoice = await _unitOfWork.InvoiceRepository.GetByIdAsync(id);
                if (invoice == null)
                {
                    return Result<InvoiceResponseDto>.Failure($"Invoice with id {id} not found");
                }

                invoice.Status = status;
                await _unitOfWork.InvoiceRepository.UpdateAsync(invoice);
                await _unitOfWork.SaveAsync();

                return await GetInvoiceByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Result<InvoiceResponseDto>.Failure($"Error updating invoice status: {ex.Message}");
            }
        }

        public async Task<Result<InvoiceResponseDto>> UpdateInvoiceAsync(string id, UpdateInvoiceDto dto)
        {
            try
            {
                var invoice = await _unitOfWork.InvoiceRepository.GetByIdAsync(id);
                if (invoice == null)
                {
                    return Result<InvoiceResponseDto>.Failure($"Invoice with id {id} not found");
                }

                if (dto.BasePrice.HasValue) invoice.BasePrice = dto.BasePrice.Value;
                if (dto.TaxPrice.HasValue) invoice.TaxPrice = dto.TaxPrice.Value;
                if (dto.TotalPrice.HasValue) invoice.TotalPrice = dto.TotalPrice.Value;
                if (dto.DaysStayed.HasValue) invoice.DaysStayed = dto.DaysStayed.Value;
                if (dto.Status.HasValue) invoice.Status = dto.Status.Value;

                await _unitOfWork.InvoiceRepository.UpdateAsync(invoice);
                await _unitOfWork.SaveAsync();

                return await GetInvoiceByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Result<InvoiceResponseDto>.Failure($"Error updating invoice: {ex.Message}");
            }
        }

        public async Task<Result<IEnumerable<InvoiceResponseDto>>> GetInvoicesByMonthOrYearAsync(int? year, int? month)
        {
            try
            {
                IQueryable<Invoice> query = _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Booker)
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Room);

                if (year.HasValue)
                {
                    query = query.Where(i => i.CreatedAt.Year == year.Value);
                }

                if (month.HasValue)
                {
                    query = query.Where(i => i.CreatedAt.Month == month.Value);

                    if (!year.HasValue)
                    {
                        var currentYear = DateTime.Now.Year;
                        query = query.Where(i => i.CreatedAt.Year == currentYear);
                    }
                }

                var invoices = await query.OrderByDescending(i => i.CreatedAt).ToListAsync();
                return Result<IEnumerable<InvoiceResponseDto>>.Success(_mapper.Map<IEnumerable<InvoiceResponseDto>>(invoices));
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<InvoiceResponseDto>>.Failure($"Error retrieving invoices: {ex.Message}");
            }
        }

        public async Task<Result<IEnumerable<InvoiceResponseDto>>> GetInvoicesAsync(string role, string userId)
        {
            try
            {
                IQueryable<Invoice> query = _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Booker)
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Room);

                if (role != "admin") // Assuming "admin" is the role name
                {
                    query = query.Where(i => i.Booking.BookerId.ToString() == userId);
                }

                var invoices = await query.ToListAsync();
                return Result<IEnumerable<InvoiceResponseDto>>.Success(_mapper.Map<IEnumerable<InvoiceResponseDto>>(invoices));
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<InvoiceResponseDto>>.Failure($"Error retrieving invoices: {ex.Message}");
            }
        }

        public async Task<Result<InvoiceResponseDto>> GetInvoiceForUserAsync(string role, string userId, string invoiceId)
        {
            try
            {
                var invoice = await _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Booker)
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Room)
                    .FirstOrDefaultAsync(i => i.Id.ToString() == invoiceId);

                if (invoice == null)
                {
                    return Result<InvoiceResponseDto>.Failure("Invoice not found.");
                }

                if (role != "admin" && invoice.Booking.BookerId.ToString() != userId)
                {
                    return Result<InvoiceResponseDto>.Failure("You do not have permission to access this invoice.");
                }

                return Result<InvoiceResponseDto>.Success(_mapper.Map<InvoiceResponseDto>(invoice));
            }
            catch (Exception ex)
            {
                return Result<InvoiceResponseDto>.Failure($"Error retrieving invoice: {ex.Message}");
            }
        }

        public async Task<Result<bool>> DeleteInvoiceAsync(string id)
        {
            try
            {
                var success = await _unitOfWork.InvoiceRepository.RemoveAsync(id);
                if (!success)
                {
                    return Result<bool>.Failure("Invoice not found.");
                }
                await _unitOfWork.SaveAsync();
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error deleting invoice: {ex.Message}");
            }
        }

        public async Task<Result<bool>> HandleUpdateStatusOfInvoiceAsync(string invoiceId, string vnp_ResponseCode, string vnp_TransactionStatus)
        {
            try
            {
                var invoice = await _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .Include(i => i.Booking)
                        .ThenInclude(b => b.Room)
                            .ThenInclude(r => r.RoomType)
                    .FirstOrDefaultAsync(i => i.Id.ToString() == invoiceId);

                if (invoice == null)
                {
                    return Result<bool>.Failure("Invoice not found.");
                }

                var status = (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                    ? InvoiceStatus.Paid
                    : InvoiceStatus.Pending; // Or Unpaid

                invoice.Status = status;

                if (status == InvoiceStatus.Paid)
                {
                    // TODO: Implement ReportService to handle monthly revenue
                    // var formattedDate = invoice.UpdatedAt.ToString("yyyy-MM");
                    // await _reportService.HandleCreateOrUpdateMonthlyRevenue(formattedDate, invoice.TotalPrice, invoice.Booking.Room.RoomType.Id);
                }

                await _unitOfWork.InvoiceRepository.UpdateAsync(invoice);
                await _unitOfWork.SaveAsync();

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error updating invoice status: {ex.Message}");
            }
        }
    }
}
