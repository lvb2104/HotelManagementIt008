namespace HotelManagementIt008.Dtos.Responses
{
    public class BookingSummaryDto
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookerEmail { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
