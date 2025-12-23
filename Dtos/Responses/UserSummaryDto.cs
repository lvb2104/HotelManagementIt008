using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementIt008.Dtos.Responses
{
    public class UserSummaryDto
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? UserType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
