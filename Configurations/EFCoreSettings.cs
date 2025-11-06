namespace HotelManagementIt008.Configurations
{
    public class EFCoreSettings
    {
        public const string SettingsSection = "ConnectionStrings";

        public required string DefaultConnection { get; set; }
    }
}
