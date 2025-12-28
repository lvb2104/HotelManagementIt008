using AutoMapper;

using Gridify;
using Gridify.EntityFramework;

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Services.Implementations
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGridifyMapper<RoomType> _gridifyMapper;

        public RoomTypeService(IUnitOfWork unitOfWork, IMapper mapper, IGridifyMapper<RoomType> gridifyMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _gridifyMapper = gridifyMapper;
        }

        public async Task<Result<ICollection<RoomTypeResponseDto>>> GetAllRoomTypesAsync()
        {
            try
            {
                var roomTypes = await _unitOfWork.RoomTypeRepository.GetAllAsync();
                var roomTypeDtos = _mapper.Map<List<RoomTypeResponseDto>>(roomTypes);
                return Result<ICollection<RoomTypeResponseDto>>.Success(roomTypeDtos);
            }
            catch (Exception ex)
            {
                return Result<ICollection<RoomTypeResponseDto>>.Failure($"An error occurred while retrieving room types: {ex.Message}");
            }
        }

        public async Task<Result<Paging<RoomTypeResponseDto>>> GetAllRoomTypesAsync(GridifyQuery query)
        {
            try
            {
                // Get queryable
                var roomTypesQuery = _unitOfWork.RoomTypeRepository.GetAllQueryable();

                // Apply Gridify filtering, sorting, and paging
                var pagedRoomTypes = await roomTypesQuery.GridifyAsync(query, _gridifyMapper);

                // Map to DTOs
                var roomTypeDtos = _mapper.Map<ICollection<RoomTypeResponseDto>>(pagedRoomTypes.Data);

                // Create paged result
                var result = new Paging<RoomTypeResponseDto>
                {
                    Data = roomTypeDtos,
                    Count = pagedRoomTypes.Count,
                };

                return Result<Paging<RoomTypeResponseDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<Paging<RoomTypeResponseDto>>.Failure($"An error occurred while retrieving room types: {ex.Message}");
            }
        }

        public async Task<Result<RoomTypeResponseDto>> GetRoomTypeByIdAsync(Guid id)
        {
            try
            {
                var roomType = await _unitOfWork.RoomTypeRepository
                    .GetAllQueryable()
                    .FirstOrDefaultAsync(rt => rt.Id == id);

                if (roomType == null)
                    return Result<RoomTypeResponseDto>.Failure("Room type not found");

                var roomTypeDto = _mapper.Map<RoomTypeResponseDto>(roomType);
                return Result<RoomTypeResponseDto>.Success(roomTypeDto);
            }
            catch (Exception ex)
            {
                return Result<RoomTypeResponseDto>.Failure($"An error occurred while retrieving room type: {ex.Message}");
            }
        }

        public async Task<Result<RoomTypeResponseDto>> CreateRoomTypeAsync(CreateRoomTypeDto dto)
        {
            try
            {
                // Check if room type name already exists
                var existingRoomType = await _unitOfWork.RoomTypeRepository
                    .GetAllQueryable()
                    .FirstOrDefaultAsync(rt => rt.Name == dto.Name);

                if (existingRoomType != null)
                    return Result<RoomTypeResponseDto>.Failure($"Room type '{dto.Name}' already exists");

                var roomType = _mapper.Map<RoomType>(dto);
                roomType.Id = Guid.NewGuid();
                roomType.CreatedAt = DateTime.UtcNow;
                roomType.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.RoomTypeRepository.AddAsync(roomType);
                await _unitOfWork.SaveAsync();

                var roomTypeDto = _mapper.Map<RoomTypeResponseDto>(roomType);
                return Result<RoomTypeResponseDto>.Success(roomTypeDto);
            }
            catch (Exception ex)
            {
                return Result<RoomTypeResponseDto>.Failure($"An error occurred while creating room type: {ex.Message}");
            }
        }

        public async Task<Result<RoomTypeResponseDto>> UpdateRoomTypeAsync(Guid id, UpdateRoomTypeDto dto)
        {
            try
            {
                // Get room type WITH tracking so EF can detect changes
                var roomType = await _unitOfWork.RoomTypeRepository
                    .GetAllQueryable()
                    .AsTracking()
                    .FirstOrDefaultAsync(rt => rt.Id == id);

                if (roomType == null)
                    return Result<RoomTypeResponseDto>.Failure("Room type not found");

                // Check if new name conflicts with another room type
                if (roomType.Name != dto.Name)
                {
                    var existingRoomType = await _unitOfWork.RoomTypeRepository
                        .GetAllQueryable()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(rt => rt.Name == dto.Name && rt.Id != id);

                    if (existingRoomType != null)
                        return Result<RoomTypeResponseDto>.Failure($"Room type '{dto.Name}' already exists");
                }

                // Update properties - EF will track changes
                roomType.Name = dto.Name;
                roomType.Description = dto.Description;
                roomType.PricePerNight = dto.PricePerNight;
                roomType.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.SaveAsync();

                var roomTypeDto = _mapper.Map<RoomTypeResponseDto>(roomType);
                return Result<RoomTypeResponseDto>.Success(roomTypeDto);
            }
            catch (Exception ex)
            {
                return Result<RoomTypeResponseDto>.Failure($"An error occurred while updating room type: {ex.Message}");
            }
        }

        public async Task<Result<bool>> DeleteRoomTypeAsync(Guid id)
        {
            try
            {
                // Get room type WITH tracking so EF can detect the soft delete
                var roomType = await _unitOfWork.RoomTypeRepository
                    .GetAllQueryable()
                    .AsTracking()
                    .FirstOrDefaultAsync(rt => rt.Id == id);

                if (roomType == null)
                    return Result<bool>.Failure("Room type not found");

                // Use Remove to mark entity as Deleted, which triggers DbContext's soft delete handler
                await _unitOfWork.RoomTypeRepository.RemoveAsync(roomType);
                await _unitOfWork.SaveAsync();

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"An error occurred while deleting room type: {ex.Message}");
            }
        }
    }
}
