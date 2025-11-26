using HotelManagementIt008.Dtos.Requests;
using HotelManagementIt008.Dtos.Responses;

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Result<IEnumerable<BookingResponseDto>>> GetAllBookingsAsync(string userId);
        Task<Result<BookingResponseDto>> GetBookingByIdAsync(string id, string userId);
        Task<Result<BookingResponseDto>> CreateBookingAsync(CreateBookingDto dto, string userId);
        Task<Result<BookingResponseDto>> UpdateBookingAsync(string id, UpdateBookingDto dto, string userId);
        Task<Result<bool>> RemoveBookingAsync(string id, string userId);
    }
}
