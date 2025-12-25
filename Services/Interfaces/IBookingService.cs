using Gridify;

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Result<Paging<BookingResponseDto>>> GetAllBookingsAsync(string userId, GridifyQuery query);
        Task<Result<Paging<BookingSummaryDto>>> GetBookingSummariesAsync(string userId, GridifyQuery query);
        Task<Result<BookingResponseDto>> GetBookingByIdAsync(string id, string userId);
        Task<Result<BookingResponseDto>> CreateBookingAsync(CreateBookingDto dto, string userId);
        Task<Result<BookingResponseDto>> UpdateBookingAsync(string id, UpdateBookingDto dto, string userId);
        Task<Result<bool>> RemoveBookingAsync(string id, string userId);
    }
}
