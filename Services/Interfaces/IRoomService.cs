using Gridify;

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Result<Paging<RoomResponseDto>>> GetAllRoomsAsync(GridifyQuery query);
        Result<int> CountRoomsByStatus(RoomStatus? status = null);
        //Task<Result<RoomResponseDto>> CreateRoomAsync(CreateRoomDto dto);
    }
}
