using System.ComponentModel.DataAnnotations;

namespace HotelManagementIt008.Dtos.Requests
{
    public class LoginRequestDto
    {
        [MinLength(8)]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;

        [MinLength(8)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
