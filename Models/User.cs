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

        public Guid RoleId { get; set; }

        public Guid? UserTypeId { get; set; }

        // -------------- Navigation properties --------------

        public Profile Profile { get; set; } = null!;

        public Role Role { get; set; } = null!;

        public UserType? UserType { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public ICollection<BookingDetails> BookingDetails { get; set; } = new List<BookingDetails>();
    }
}
