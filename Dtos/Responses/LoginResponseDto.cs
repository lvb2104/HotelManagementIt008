namespace HotelManagementIt008.Dtos.Responses
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public RoleType Role { get; set; }
    }
}
