namespace HotelManagementIt008.Services.Implementations
{
    public class CurrentUserService : ICurrentUserService
    {
        private LoginResponseDto? _currentUser;

        public Guid UserId => _currentUser?.Id ?? Guid.Empty;
        public string Username => _currentUser?.Username ?? string.Empty;
        public RoleType Role => _currentUser?.Role ?? RoleType.Customer;
        public bool IsAuthenticated => _currentUser != null;

        public void SetUser(LoginResponseDto user)
        {
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
        }

        public void Clear()
        {
            _currentUser = null;
        }
    }
}

