namespace HotelManagementIt008.Services.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        string Username { get; }
        RoleType Role { get; }
        bool IsAuthenticated { get; }
        void SetUser(LoginResponseDto user);
        void Clear();
    }
}

