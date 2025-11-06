namespace HotelManagementIt008.Models
{
    public class UserType
    {
        public Guid Id { get; set; }

        public UserTypeType Type { get; set; } = UserTypeType.Local;

        public string? Description { get; set; }

        public double SurchargeRate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        // ------------- Navigation properties --------------

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
