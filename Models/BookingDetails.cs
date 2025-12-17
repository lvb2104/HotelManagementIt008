namespace HotelManagementIt008.Models
{
    public class BookingDetails : ISoftDeletable
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Guid BookingId { get; set; }

        public Guid UserId { get; set; }

        // -------------- Navigation Properties --------------

        public Booking Booking { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
