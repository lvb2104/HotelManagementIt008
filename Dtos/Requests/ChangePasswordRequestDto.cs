using System.ComponentModel.DataAnnotations;

namespace HotelManagementIt008.Dtos.Requests
{
    public class ChangePasswordRequestDto
    {
        [Required]
        public string OldPassword { get; set; } = string.Empty;

        [Required]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
