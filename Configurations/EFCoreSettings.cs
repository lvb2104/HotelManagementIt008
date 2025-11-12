using System.ComponentModel.DataAnnotations;

namespace HotelManagementIt008.Configurations
{
    public class EFCoreSettings
    {
        public const string SettingsSection = "ConnectionStrings";

        [Required]
        [MinLength(1)]
        public required string DefaultConnection { get; set; }
    }
}
