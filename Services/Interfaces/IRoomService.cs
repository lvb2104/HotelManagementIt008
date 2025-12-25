using Gridify;

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Result<Paging<RoomResponseDto>>> GetAllRoomsAsync(GridifyQuery query);
        Result<int> CountRoomsByStatus(RoomStatus? status = null);
        Task<Result<RoomResponseDto>> GetRoomByIdAsync(Guid id);
        Task<Result<RoomResponseDto>> CreateRoomAsync(CreateRoomDto dto);
        Task<Result<RoomResponseDto>> UpdateRoomAsync(Guid id, UpdateRoomDto dto);
        Task<Result<bool>> DeleteRoomAsync(Guid id);
    }
}
