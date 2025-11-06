using AutoMapper;

using HotelManagementIt008.Dtos.Requests;
using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Helpers;
using HotelManagementIt008.Interfaces;

namespace HotelManagementIt008.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<LoginResponseDto>> LogInAsync(LoginRequestDto loginRequestDto)
        {
            var user = await _unitOfWork.UserRepository.FindUserByUsernameAsync(loginRequestDto.Username);

            if (user == null)
            {
                return Result<LoginResponseDto>.Failure("User not found.");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return Result<LoginResponseDto>.Failure("Invalid password.");
            }

            var loginResponseDto = _mapper.Map<LoginResponseDto>(user);
            return Result<LoginResponseDto>.Success(loginResponseDto);
        }
    }
}
