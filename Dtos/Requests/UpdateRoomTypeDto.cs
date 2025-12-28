namespace HotelManagementIt008.Dtos.Requests
{
    public class UpdateRoomTypeDto
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal PricePerNight { get; set; }
    }
}
