namespace HotelManagementIt008.Models
{
    public class RoomType : ISoftDeletable
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public double PricePerNight { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        // -------------- Navigation properties --------------

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
