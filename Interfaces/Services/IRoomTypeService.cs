namespace HotelManagementIt008.Interfaces.Services
{
    public interface IRoomTypeService
    {
        Task<Result<ICollection<RoomTypeResponseDto>>> GetAllRoomTypesAsync();
    }
}
