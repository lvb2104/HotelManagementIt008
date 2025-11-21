using AutoMapper;

using HotelManagementIt008.Repositories;

namespace HotelManagementIt008.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
    }
}
