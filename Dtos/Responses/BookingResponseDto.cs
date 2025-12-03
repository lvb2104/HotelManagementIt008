namespace HotelManagementIt008.Dtos.Responses
{
    public class BookingResponseDto
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserBookingResponseDto User { get; set; } = default!;
        public RoomResponseDto Room { get; set; } = default!;
        public InvoiceResponseDto? Invoice { get; set; }
        public List<ParticipantResponseDto> Participants { get; set; } = new List<ParticipantResponseDto>();
    }

    public class UserBookingResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public RoleResponseDto Role { get; set; } = default!;
    }

    public class ParticipantResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public ProfileResponseDto Profile { get; set; } = default!;
        public UserTypeResponseDto UserType { get; set; } = default!;
    }

    public class ProfileResponseDto
    {
        public string FullName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string IdentityNumber { get; set; } = default!;
    }

    public class UserTypeResponseDto
    {
        public string TypeName { get; set; } = default!;
    }

    public class RoleResponseDto
    {
        public string RoleName { get; set; } = default!;
    }
}
