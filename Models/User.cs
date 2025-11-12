namespace HotelManagementIt008.Models
{
    public class User : ISoftDeletable
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        // -------------- Navigation properties --------------

        public Guid? ProfileId { get; set; }

        public Profile? Profile { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; } = null!;

        public Guid? UserTypeId { get; set; }

        public UserType? UserType { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

        public ICollection<BookingDetails>? BookingDetails { get; set; }
    }
}
