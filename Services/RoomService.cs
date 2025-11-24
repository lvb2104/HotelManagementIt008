
using AutoMapper;

using Gridify;
using Gridify.EntityFramework;

using HotelManagementIt008.Repositories;

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Services
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

        //public Task<Result<RoomResponseDto>> CreateRoomAsync(CreateRoomDto dto)
        //{

        //}

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
