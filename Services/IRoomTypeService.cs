namespace HotelManagementIt008.Services
{
    public interface IRoomTypeService
    {
        Task<Result<ICollection<RoomTypeResponseDto>>> GetAllRoomTypesAsync();
    }
}
