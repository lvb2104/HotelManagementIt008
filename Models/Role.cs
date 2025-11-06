namespace HotelManagementIt008.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        public RoleType Type { get; set; } = RoleType.Customer;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        // -------------- Navigation properties --------------

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
