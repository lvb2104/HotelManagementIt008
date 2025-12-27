namespace HotelManagementIt008.Dtos.Responses
{
    public class UserSummaryDto
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Role { get; set; }
        public string? UserType { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
