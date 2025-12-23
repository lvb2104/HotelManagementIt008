using HotelManagementIt008.Helpers;

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<LoginResponseDto>> LogInAsync(LoginRequestDto dto);
        Task<Result<User>> CreateDefaultUserAsync(CreateParticipantDto dto);
      //  Result<int> CountByRoleType(RoleType? role = null);
        Task<Result<int>> CountByRoleTypeAsync(RoleType? role = null);
        Task<Result<UserResponseDto>> GetUserByIdAsync( Guid id);
        Task<Result<UserResponseDto>> UpdateUserAsync(Guid id, UpdateUserDto dto);
        Task<Result<List<UserSummaryDto>>> GetUserSummariesAsync();
        Task<Result<bool>> DeleteUserAsync(Guid id);
        Task<Result<UserResponseDto>> CreateUserAsync(CreateUserDto dto);
    }
}
