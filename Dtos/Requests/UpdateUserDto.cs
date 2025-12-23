using HotelManagementIt008.Types;

namespace HotelManagementIt008.Dtos.Requests
{
    public class UpdateUserDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? IdentityNumber { get; set; }
        public UserTypeType? UserType { get; set; }
        public RoleType? Role { get; set; }
        public UpdateProfileDto? Profile { get; set; }
    }
    public class UpdateProfileDto
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? IdentityNumber { get; set; }
    }
}
