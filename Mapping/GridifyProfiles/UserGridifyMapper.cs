using Gridify;

namespace HotelManagementIt008.Mapping.GridifyProfiles
{
    public class UserGridifyMapper : GridifyMapper<User>
    {
        public UserGridifyMapper()
        {
            AddMap("username", u => u.Username)
                .AddMap("email", u => u.Email)
                .AddMap("fullName", u => u.Profile != null ? u.Profile.FullName : string.Empty)
                .AddMap("role", u => u.Role.Type)
                .AddMap("userType", u => u.UserType != null ? u.UserType.Type : (UserTypeType?)null)
                .AddMap("createdAt", u => u.CreatedAt.Date);
        }
    }
}
