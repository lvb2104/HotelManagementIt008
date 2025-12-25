namespace HotelManagementIt008.Dtos.Requests
{
    public class UpdateRoomDto
    {
        public string RoomNumber { get; set; } = string.Empty;

        public string? Note { get; set; }

        public RoomStatus Status { get; set; }

        public Guid RoomTypeId { get; set; }
    }
}
