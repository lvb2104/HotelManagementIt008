using Gridify;

namespace HotelManagementIt008.Interfaces.Services
{
    public interface IRoomService
    {
        Task<Result<Paging<RoomResponseDto>>> GetAllRoomsAsync(GridifyQuery query);
    }
}
