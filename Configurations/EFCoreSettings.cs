namespace HotelManagementIt008.Configurations
{
    internal class EFCoreSettings
    {
        public const string SettingsSection = "ConnectionStrings";

        public required string DefaultConnection { get; set; }
    }
}
