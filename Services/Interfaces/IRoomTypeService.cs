namespace HotelManagementIt008.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<Result<ICollection<RoomTypeResponseDto>>> GetAllRoomTypesAsync();
    }
}
