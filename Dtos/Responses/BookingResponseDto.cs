using HotelManagementIt008.Types;

namespace HotelManagementIt008.Dtos.Responses
{
    public class BookingResponseDto
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public UserBookingResponseDto User { get; set; }
        public RoomResponseDto Room { get; set; }
        public InvoiceResponseDto? Invoice { get; set; }
        public List<ParticipantResponseDto> Participants { get; set; }
    }

    public class UserBookingResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public RoleResponseDto Role { get; set; }
    }

    public class ParticipantResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public ProfileResponseDto Profile { get; set; }
        public UserTypeResponseDto UserType { get; set; }
    }

    public class ProfileResponseDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
    }

    public class UserTypeResponseDto
    {
        public string TypeName { get; set; }
    }
    
    public class RoleResponseDto
    {
        public string RoleName { get; set; }
    }
}
