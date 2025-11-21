namespace HotelManagementIt008.Services
{
    public interface IUserService
    {
        Task<Result<LoginResponseDto>> LogInAsync(LoginRequestDto loginRequestDto);
    }
}
