using Gridify;

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<Result<ICollection<RoomTypeResponseDto>>> GetAllRoomTypesAsync();
        Task<Result<Paging<RoomTypeResponseDto>>> GetAllRoomTypesAsync(GridifyQuery query);
        Task<Result<RoomTypeResponseDto>> GetRoomTypeByIdAsync(Guid id);
        Task<Result<RoomTypeResponseDto>> CreateRoomTypeAsync(CreateRoomTypeDto dto);
        Task<Result<RoomTypeResponseDto>> UpdateRoomTypeAsync(Guid id, UpdateRoomTypeDto dto);
        Task<Result<bool>> DeleteRoomTypeAsync(Guid id);
    }
}
