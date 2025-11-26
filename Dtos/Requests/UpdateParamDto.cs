using System.ComponentModel.DataAnnotations;

namespace HotelManagementIt008.Dtos.Requests
{
    public class UpdateParamDto
    {
        [Required]
        public string Value { get; set; } = string.Empty;
    }
}
