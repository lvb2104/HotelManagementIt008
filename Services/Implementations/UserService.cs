using AutoMapper;

using Gridify;
using Gridify.EntityFramework;

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGridifyMapper<User> _gridifyMapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IGridifyMapper<User> gridifyMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _gridifyMapper = gridifyMapper;
        }

        public async Task<Result<LoginResponseDto>> LogInAsync(LoginRequestDto dto)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.FindUserByUsernameAsync(dto.Username);
                if (user == null)
                    return Result<LoginResponseDto>.Failure("User not found.");

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
                if (!isPasswordValid)
                    return Result<LoginResponseDto>.Failure("Invalid password.");

                var response = _mapper.Map<LoginResponseDto>(user);
                return Result<LoginResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                return Result<LoginResponseDto>.Failure($"An error occurred during login. Please try again later: {ex.Message}");
            }
        }

        public async Task<Result<User>> CreateDefaultUserAsync(CreateParticipantDto dto)
        {
            try
            {
                var userType = await _unitOfWork.UserTypeRepository.GetAllQueryable()
                    .AsTracking()
                    .FirstOrDefaultAsync(ut => ut.Type == dto.UserType);

                if (userType == null)
                    return Result<User>.Failure($"UserType {dto.UserType} not found");

                var user = new User
                {
                    Email = dto.Email,
                    Username = (!string.IsNullOrWhiteSpace(dto.FullName) ? dto.FullName.Replace(" ", "").ToLower() : dto.Email.Split('@')[0].ToLower()) + new Random().Next(1000, 9999),
                    UserTypeId = userType.Id,
                    UserType = userType,
                    Profile = new HotelManagementIt008.Models.Profile
                    {
                        FullName = dto.FullName,
                        Address = dto.Address,
                        IdentityCardNumber = dto.IdentityNumber
                    }
                };

                var userRole = await _unitOfWork.RoleRepository.GetAllQueryable()
                    .FirstOrDefaultAsync(r => r.Type == RoleType.Customer);
                if (userRole != null)
                    user.RoleId = userRole.Id;

                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.SaveAsync();

                return Result<User>.Success(user);
            }
            catch (Exception ex)
            {
                return Result<User>.Failure($"Error creating default user: {ex.Message}");
            }
        }

        public async Task<Result<int>> CountByRoleTypeAsync(RoleType? role = null)
        {
            try
            {
                var query = _unitOfWork.UserRepository.GetAllQueryable();
                if (role.HasValue)
                {
                    query = query.Where(u => u.Role.Type == role.Value);
                }

                int count = await query.CountAsync(); // async EF
                return Result<int>.Success(count);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"An error occurred while counting users: {ex.Message}");
            }
        }
        public async Task<Result<UserResponseDto>> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository
                .GetAllQueryable()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return Result<UserResponseDto>.Failure("User not found");

            return Result<UserResponseDto>.Success(
                _mapper.Map<UserResponseDto>(user)
            );
        }
        public async Task<Result<UserResponseDto>> UpdateUserAsync(Guid id, UpdateUserDto dto)
        {
            var user = await _unitOfWork.UserRepository
                .GetAllQueryable()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return Result<UserResponseDto>.Failure("User not found");

            if (!string.IsNullOrWhiteSpace(dto.Username))
                user.Username = dto.Username;

            if (!string.IsNullOrWhiteSpace(dto.Email))
                user.Email = dto.Email;

            if (dto.UserType.HasValue)
            {
                var userType = await _unitOfWork.UserTypeRepository
                    .GetAllQueryable()
                    .AsTracking()
                    .FirstOrDefaultAsync(x => x.Type == dto.UserType.Value);

                if (userType != null)
                {
                    user.UserTypeId = userType.Id;
                    user.UserType = userType;
                }
            }

            if (dto.Role.HasValue)
            {
                var role = await _unitOfWork.RoleRepository
                    .GetAllQueryable()
                    .AsTracking()
                    .FirstOrDefaultAsync(r => r.Type == dto.Role.Value);

                if (role != null)
                {
                    user.RoleId = role.Id;
                    user.Role = role;
                }
            }

            if (!string.IsNullOrEmpty(dto.Password))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            }

            if (user.Profile != null)
            {
                user.Profile.FullName = dto.FullName ?? user.Profile.FullName;
                user.Profile.Address = dto.Address ?? user.Profile.Address;
                user.Profile.IdentityCardNumber =
                    dto.IdentityNumber ?? user.Profile.IdentityCardNumber;
            }

            user.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.SaveAsync();

            return Result<UserResponseDto>.Success(
                _mapper.Map<UserResponseDto>(user)
            );
        }
        public async Task<Result<Paging<UserSummaryDto>>> GetUserSummariesAsync(GridifyQuery query)
        {
            try
            {
                var usersQuery = _unitOfWork.UserRepository
                    .GetAllQueryable()
                    .AsNoTracking();

                // Apply Gridify filtering, sorting, and paging
                var pagedUsers = await usersQuery.GridifyAsync(query, _gridifyMapper);

                // Project to DTOs
                var userDtos = pagedUsers.Data.Select(u => new UserSummaryDto
                {
                    Id = u.Id,
                    Username = u.Username ?? string.Empty,
                    Email = u.Email ?? string.Empty,
                    FullName = u.Profile != null ? u.Profile.FullName : string.Empty,
                    Role = u.Role.Type.ToString(),
                    UserType = u.UserType != null ? u.UserType.Type.ToString() : string.Empty,
                    Address = u.Profile != null ? u.Profile.Address : string.Empty,
                    CreatedAt = u.CreatedAt
                }).ToList();

                return Result<Paging<UserSummaryDto>>.Success(new Paging<UserSummaryDto>
                {
                    Data = userDtos,
                    Count = pagedUsers.Count
                });
            }
            catch (Exception ex)
            {
                return Result<Paging<UserSummaryDto>>.Failure(
                    $"Error loading users: {ex.Message}"
                );
            }
        }
        public async Task<Result<bool>> DeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
                return Result<bool>.Failure("User not found");

            await _unitOfWork.UserRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return Result<bool>.Success(true);
        }
        public async Task<Result<UserResponseDto>> CreateUserAsync(CreateUserDto dto)
        {
            try
            {
                // Get UserType entity from DB
                var userTypeEntity = await _unitOfWork.UserTypeRepository
                    .GetAllQueryable()
                    .FirstOrDefaultAsync(ut => ut.Type == dto.UserType);

                if (userTypeEntity == null)
                    return Result<UserResponseDto>.Failure($"UserType {dto.UserType} not found.");

                // Get Role entity from DB
                var roleEntity = await _unitOfWork.RoleRepository
                    .GetAllQueryable()
                    .FirstOrDefaultAsync(r => r.Type == dto.Role);

                // If not found, get default Role: Customer
                if (roleEntity == null)
                {
                    roleEntity = await _unitOfWork.RoleRepository
                        .GetAllQueryable()
                        .FirstOrDefaultAsync(r => r.Type == RoleType.Customer);

                    if (roleEntity == null)
                        return Result<UserResponseDto>.Failure("Role 'Customer' not found in database.");
                }

                // Create new User
                var user = new User
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    PasswordHash = !string.IsNullOrEmpty(dto.Password) ? BCrypt.Net.BCrypt.HashPassword(dto.Password) : null,
                    UserTypeId = userTypeEntity.Id,
                    // UserType = userTypeEntity,
                    RoleId = roleEntity.Id,
                    // Role = roleEntity,
                    Profile = new HotelManagementIt008.Models.Profile
                    {
                        FullName = dto.FullName,
                        Address = dto.Address,
                        IdentityCardNumber = dto.IdentityNumber
                    }
                };

                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.SaveAsync();

                // Map ra UserResponseDto
                var response = new UserResponseDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,

                    Role = user.Role?.Type ?? RoleType.Customer,      // default hợp lý
                    UserType = user.UserType?.Type ?? UserTypeType.Local,

                    FullName = user.Profile?.FullName ?? string.Empty,
                    Address = user.Profile?.Address ?? string.Empty,
                    IdentityNumber = user.Profile?.IdentityCardNumber ?? string.Empty
                };

                return Result<UserResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                return Result<UserResponseDto>.Failure($"Error creating user: {ex.Message}");
            }
        }


        public async Task<Result<bool>> ChangePasswordAsync(Guid userId, ChangePasswordRequestDto dto)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
                if (user == null)
                    return Result<bool>.Failure("User not found.");

                bool isOldPasswordValid = BCrypt.Net.BCrypt.Verify(dto.OldPassword, user.PasswordHash);
                if (!isOldPasswordValid)
                    return Result<bool>.Failure("Incorrect old password.");

                string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                user.PasswordHash = newPasswordHash;
                user.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.SaveAsync();
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error changing password: {ex.Message}");
            }
        }
    }
}
