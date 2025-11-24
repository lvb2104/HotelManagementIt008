using Gridify;

namespace HotelManagementIt008.Services
{
    public interface IRoomService
    {
        Task<Result<Paging<RoomResponseDto>>> GetAllRoomsAsync(GridifyQuery query);
        //Task<Result<RoomResponseDto>> CreateRoomAsync(CreateRoomDto dto);
    }
}
