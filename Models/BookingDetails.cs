namespace HotelManagementIt008.Models
{
    public class BookingDetails : ISoftDeletable
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        // -------------- Navigation Properties --------------

        public Guid BookingId { get; set; }

        public Booking Booking { get; set; } = null!;

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
