namespace HotelManagementIt008.Configurations
{
    public class SecuritySettings
    {
        public const string SettingsSection = "Security";

        public required string SaltKey { get; set; }
    }
}
