namespace HotelManagementIt008.Models
{
    internal class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        // -------------- Navigation properties --------------

        public Guid ProfileId { get; set; }

        public Profile Profile { get; set; } = null!;

        public Guid RoleId { get; set; }

        public Role Role { get; set; } = null!;

        public Guid UserTypeId { get; set; }

        public UserType UserType { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public ICollection<BookingDetails> BookingDetails { get; set; } = new List<BookingDetails>();
    }
}
