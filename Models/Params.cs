namespace HotelManagementIt008.Models
{
    public class Params : ISoftDeletable
    {
        public Guid Id { get; set; }

        public string Key { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
