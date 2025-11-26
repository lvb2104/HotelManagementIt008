namespace HotelManagementIt008.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<LoginResponseDto>> LogInAsync(LoginRequestDto dto);
        Task<Result<User>> CreateDefaultUserAsync(CreateParticipantDto dto);
        Result<int> CountByRoleType(RoleType? role = null);
    }
}
