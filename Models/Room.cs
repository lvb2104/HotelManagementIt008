using HotelManagementIt008.Enums;

namespace HotelManagementIt008.Models
{
    internal class Room
    {
        public Guid Id { get; set; }

        public string RoomNumber { get; set; } = string.Empty;

        public string? Note { get; set; }

        public RoomStatus Status { get; set; } = RoomStatus.Available;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        // -------------- Navigation properties --------------

        public Guid RoomTypeId { get; set; }

        public RoomType RoomType { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
