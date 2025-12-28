
using AutoMapper;

using Gridify;
using Gridify.EntityFramework;

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGridifyMapper<Room> _gridifyMapper;

        public RoomService(IUnitOfWork unitOfWork, IMapper mapper, IGridifyMapper<Room> gridifyMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _gridifyMapper = gridifyMapper;
        }

        public Result<int> CountRoomsByStatus(RoomStatus? status = null)
        {
            try
            {
                var count = _unitOfWork.RoomRepository.Count(r => !status.HasValue || r.Status == status.Value);
                return Result<int>.Success(count);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"An error occurred while counting rooms: {ex.Message}");
            }
        }

        public async Task<Result<RoomResponseDto>> GetRoomByIdAsync(Guid id)
        {
            try
            {
                var room = await _unitOfWork.RoomRepository
                    .GetAllQueryable()
                    .Include(r => r.RoomType)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (room == null)
                    return Result<RoomResponseDto>.Failure("Room not found");

                var roomDto = _mapper.Map<RoomResponseDto>(room);
                return Result<RoomResponseDto>.Success(roomDto);
            }
            catch (Exception ex)
            {
                return Result<RoomResponseDto>.Failure($"An error occurred while retrieving room: {ex.Message}");
            }
        }

        public async Task<Result<RoomResponseDto>> CreateRoomAsync(CreateRoomDto dto)
        {
            try
            {
                // Check if room number already exists
                var existingRoom = await _unitOfWork.RoomRepository
                    .GetAllQueryable()
                    .FirstOrDefaultAsync(r => r.RoomNumber == dto.RoomNumber);

                if (existingRoom != null)
                    return Result<RoomResponseDto>.Failure($"Room number {dto.RoomNumber} already exists");

                var room = _mapper.Map<Room>(dto);
                room.Id = Guid.NewGuid();
                room.CreatedAt = DateTime.UtcNow;
                room.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.RoomRepository.AddAsync(room);
                await _unitOfWork.SaveAsync();

                // Reload with RoomType
                var createdRoom = await _unitOfWork.RoomRepository
                    .GetAllQueryable()
                    .Include(r => r.RoomType)
                    .FirstOrDefaultAsync(r => r.Id == room.Id);

                var roomDto = _mapper.Map<RoomResponseDto>(createdRoom);
                return Result<RoomResponseDto>.Success(roomDto);
            }
            catch (Exception ex)
            {
                return Result<RoomResponseDto>.Failure($"An error occurred while creating room: {ex.Message}");
            }
        }

        public async Task<Result<RoomResponseDto>> UpdateRoomAsync(Guid id, UpdateRoomDto dto)
        {
            try
            {
                // Get room WITH tracking so EF can detect changes
                var room = await _unitOfWork.RoomRepository
                    .GetAllQueryable()
                    .AsTracking()
                    .Include(r => r.RoomType)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (room == null)
                    return Result<RoomResponseDto>.Failure("Room not found");

                // Check if new room number conflicts with another room
                if (room.RoomNumber != dto.RoomNumber)
                {
                    var existingRoom = await _unitOfWork.RoomRepository
                        .GetAllQueryable()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(r => r.RoomNumber == dto.RoomNumber && r.Id != id);

                    if (existingRoom != null)
                        return Result<RoomResponseDto>.Failure($"Room number {dto.RoomNumber} already exists");
                }

                // Update properties - EF will track changes
                room.RoomNumber = dto.RoomNumber;
                room.Note = dto.Note;
                room.Status = dto.Status;
                room.RoomTypeId = dto.RoomTypeId;
                room.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.SaveAsync();

                // Map the already-updated room (no need to reload, we already have RoomType included)
                var roomDto = _mapper.Map<RoomResponseDto>(room);
                return Result<RoomResponseDto>.Success(roomDto);
            }
            catch (Exception ex)
            {
                return Result<RoomResponseDto>.Failure($"An error occurred while updating room: {ex.Message}");
            }
        }

        public async Task<Result<bool>> DeleteRoomAsync(Guid id)
        {
            try
            {
                // Get room WITH tracking so EF can detect the soft delete
                var room = await _unitOfWork.RoomRepository
                    .GetAllQueryable()
                    .AsTracking()
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (room == null)
                    return Result<bool>.Failure("Room not found");

                // Use Remove to mark entity as Deleted, which triggers DbContext's soft delete handler
                await _unitOfWork.RoomRepository.RemoveAsync(room);
                await _unitOfWork.SaveAsync();

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"An error occurred while deleting room: {ex.Message}");
            }
        }



        public async Task<Result<Paging<RoomResponseDto>>> GetAllRoomsAsync(GridifyQuery query)
        {
            try
            {
                // Get queryable with includes
                var roomsQuery = _unitOfWork.RoomRepository.GetAllQueryable().Include(r => r.RoomType);

                // Apply Gridify filtering, sorting, and paging
                var pagedRooms = await roomsQuery.GridifyAsync(query, _gridifyMapper);

                // Map to DTOs
                var roomDtos = _mapper.Map<ICollection<RoomResponseDto>>(pagedRooms.Data);

                // Create paged result
                var result = new Paging<RoomResponseDto>
                {
                    Data = roomDtos,
                    Count = pagedRooms.Count,
                };

                return Result<Paging<RoomResponseDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<Paging<RoomResponseDto>>.Failure($"An error occurred while retrieving rooms: {ex.Message}");
            }
        }
    }
}
