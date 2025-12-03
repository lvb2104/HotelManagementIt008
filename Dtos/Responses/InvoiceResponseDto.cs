namespace HotelManagementIt008.Dtos.Responses
{
    public class InvoiceResponseDto
    {
        public Guid Id { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int DaysStayed { get; set; }
        public InvoiceStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public BookingInvoiceResponseDto Booking { get; set; } = default!;
    }

    public class BookingInvoiceResponseDto
    {
        public Guid Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public UserInvoiceResponseDto User { get; set; } = default!;
        public RoomResponseDto Room { get; set; } = default!;
    }

    public class UserInvoiceResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
