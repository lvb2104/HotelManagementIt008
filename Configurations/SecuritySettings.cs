using System.ComponentModel.DataAnnotations;

namespace HotelManagementIt008.Configurations
{
    public class SecuritySettings
    {
        public const string SettingsSection = "Security";

        [Required]
        [MinLength(1)]
        public required string SaltKey { get; set; }
    }
}
