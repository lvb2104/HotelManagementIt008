using AutoMapper;

namespace HotelManagementIt008.Services.Implementations
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
        public async Task<Result<LoginResponseDto>> LogInAsync(LoginRequestDto dto)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.FindUserByUsernameAsync(dto.Username);
                if (user == null)
                {
                    return Result<LoginResponseDto>.Failure("User not found.");
                }
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
                if (!isPasswordValid)
                {
                    return Result<LoginResponseDto>.Failure("Invalid password.");
                }
                var response = _mapper.Map<LoginResponseDto>(user);
                return Result<LoginResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                return Result<LoginResponseDto>.Failure($"An error occurred during login. Please try again later: {ex}");
            }
        }

        public Result<int> CountByRoleType(RoleType? role = null)
        {
            try
            {
                var count = _unitOfWork.UserRepository.Count(u => !role.HasValue || u.Role.Type == role.Value);
                return Result<int>.Success(count);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"An error occurred while counting users: {ex.Message}");
            }
        }
    }
}
