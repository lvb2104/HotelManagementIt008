namespace HotelManagementIt008.Models
{
    public class Profile
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string? Nationality { get; set; }

        public ProfileStatus Status { get; set; } = ProfileStatus.Active;

        public DateTime? Dob { get; set; }

        public string? PhoneNumber { get; set; }

        public string Address { get; set; } = string.Empty;

        public string IdentityCardNumber { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        // -------------- Navigation properties --------------

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
