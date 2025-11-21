namespace HotelManagementIt008.Dtos.Responses
{
    public class RoomResponseDto
    {
        public Guid Id { get; set; }

        public string RoomNumber { get; set; } = string.Empty;

        public string? Note { get; set; }

        public RoomStatus Status { get; set; } = RoomStatus.Available;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Guid RoomTypeId { get; set; }

        public RoomType RoomType { get; set; } = null!;

        // Data for GridView
        public string RoomTypeName => RoomType?.Name ?? string.Empty;
        public decimal PricePerNight => RoomType?.PricePerNight ?? 0;
    }
}
