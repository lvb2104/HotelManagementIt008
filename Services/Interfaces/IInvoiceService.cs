using Gridify;

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<Result<InvoiceResponseDto>> CreateInvoiceAsync(CreateInvoiceDto dto);
        Task<Result<InvoiceResponseDto>> GetInvoiceByIdAsync(string id);
        Task<Result<InvoiceResponseDto>> GetInvoiceByBookingIdAsync(string bookingId);
        Task<Result<InvoiceResponseDto>> UpdateInvoiceStatusAsync(string id, InvoiceStatus status);
        Task<Result<InvoiceResponseDto>> UpdateInvoiceAsync(string id, UpdateInvoiceDto dto);
        Task<Result<IEnumerable<InvoiceResponseDto>>> GetInvoicesByMonthOrYearAsync(int? year, int? month);
        Task<Result<Paging<InvoiceResponseDto>>> GetInvoicesAsync(string role, string userId, GridifyQuery query);
        Task<Result<InvoiceResponseDto>> GetInvoiceForUserAsync(string role, string userId, string invoiceId);
        Task<Result<bool>> DeleteInvoiceAsync(string id);
        Task<Result<bool>> HandleUpdateStatusOfInvoiceAsync(string invoiceId, string vnp_ResponseCode, string vnp_TransactionStatus);
    }
}
