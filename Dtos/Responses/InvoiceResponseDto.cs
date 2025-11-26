using HotelManagementIt008.Types;

namespace HotelManagementIt008.Dtos.Responses
{
    public class InvoiceResponseDto
    {
        public Guid Id { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int DaysStayed { get; set; }
        public InvoiceStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public BookingInvoiceResponseDto Booking { get; set; }
    }

    public class BookingInvoiceResponseDto
    {
        public Guid Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public UserInvoiceResponseDto User { get; set; }
        public RoomResponseDto Room { get; set; }
    }

    public class UserInvoiceResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
