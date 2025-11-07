namespace HotelManagementIt008.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<LoginResponseDto>> LogInAsync(LoginRequestDto loginRequestDto);
    }
}
