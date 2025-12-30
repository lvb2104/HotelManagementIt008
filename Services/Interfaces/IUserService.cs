using Gridify;

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<LoginResponseDto>> LogInAsync(LoginRequestDto dto);
        Task<Result<User>> CreateDefaultUserAsync(CreateParticipantDto dto);
        //  Result<int> CountByRoleType(RoleType? role = null);
        Task<Result<int>> CountByRoleTypeAsync(RoleType? role = null);
        Task<Result<UserResponseDto>> GetUserByIdAsync(Guid id);
        Task<Result<UserResponseDto>> UpdateUserAsync(Guid id, UpdateUserDto dto);
        Task<Result<Paging<UserSummaryDto>>> GetUserSummariesAsync(string role, GridifyQuery query);
        Task<Result<bool>> DeleteUserAsync(Guid id);
        Task<Result<UserResponseDto>> CreateUserAsync(CreateUserDto dto);
        Task<Result<bool>> ChangePasswordAsync(Guid userId, ChangePasswordRequestDto dto);
    }
}
