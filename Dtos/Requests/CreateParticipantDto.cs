using System.ComponentModel.DataAnnotations;
using HotelManagementIt008.Types;

namespace HotelManagementIt008.Dtos.Requests
{
    public class CreateParticipantDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string IdentityNumber { get; set; } = string.Empty;

        [Required]
        public UserTypeType UserType { get; set; }
    }
}
