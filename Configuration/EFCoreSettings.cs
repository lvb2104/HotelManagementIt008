namespace HotelManagementIt008.Configuration
{
    internal class EFCoreSettings
    {
        public const string SettingsSection = "ConnectionStrings";

        public required string DefaultConnection { get; set; }
    }
}
