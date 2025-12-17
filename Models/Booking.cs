namespace HotelManagementIt008.Models
{
    public class Booking : ISoftDeletable
    {
        public Guid Id { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Guid BookerId { get; set; }

        public Guid RoomId { get; set; }

        // -------------- Navigation Properties --------------

        public User Booker { get; set; } = null!;

        public ICollection<BookingDetails> BookingDetails { get; set; } = new List<BookingDetails>();

        public Room Room { get; set; } = null!;

        public Invoice Invoice { get; set; } = null!;
    }
}
