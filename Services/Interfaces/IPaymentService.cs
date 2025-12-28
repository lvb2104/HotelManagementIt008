using Gridify;

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Result<PaymentResponseDto>> CreatePaymentAsync(CreatePaymentDto dto);
        Task<Result<PaymentResponseDto>> GetPaymentByIdAsync(string id);
        Task<Result<List<PaymentResponseDto>>> GetAllPaymentsAsync();
        Task<Result<Paging<PaymentResponseDto>>> GetPaymentsAsync(GridifyQuery query);
        Task<Result<PaymentResponseDto>> UpdatePaymentAsync(string id, UpdatePaymentDto dto);
        Task<Result<bool>> DeletePaymentAsync(string id);
        Task<Result<PaymentResponseDto>> MergePaymentsAsync(MergePaymentsDto dto);
    }
}
