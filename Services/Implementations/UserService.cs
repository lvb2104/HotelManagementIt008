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

        public async Task<Result<User>> CreateDefaultUserAsync(CreateParticipantDto dto)
        {
            try
            {
                var userType = await _unitOfWork.UserTypeRepository.GetAllQueryable().FirstOrDefaultAsync(ut => ut.Type == dto.UserType);
                if (userType == null) return Result<User>.Failure($"UserType {dto.UserType} not found");

                var user = new User
                {
                    Email = dto.Email,
                    Username = dto.FullName.Replace(" ", "").ToLower() + new Random().Next(1000, 9999),
                    // PasswordHash? Default password?
                    UserTypeId = userType.Id,
                    Profile = new Models.Profile
                    {
                        FullName = dto.FullName,
                        Address = dto.Address,
                        IdentityCardNumber = dto.IdentityNumber
                    }
                };

                var userRole = await _unitOfWork.RoleRepository.GetAllQueryable().FirstOrDefaultAsync(r => r.Type == RoleType.Customer);
                if (userRole != null) user.RoleId = userRole.Id;

                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.SaveAsync();

                return Result<User>.Success(user);
            }
            catch (Exception ex)
            {
                return Result<User>.Failure($"Error creating default user: {ex.Message}");
            }
        }
    }
}
