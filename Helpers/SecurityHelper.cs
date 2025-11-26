using System.Security.Cryptography;
using System.Text;

namespace HotelManagementIt008.Helpers
{
    public static class SecurityHelper
    {
        // Encrypts text using the Current User's Windows credentials
        public static string Protect(string secret)
        {
            if (string.IsNullOrEmpty(secret)) return string.Empty;

            try
            {
                var data = Encoding.UTF8.GetBytes(secret); // Convert the string to bytes
                // DataProtectionScope.CurrentUser means only YOU can decrypt this
                var encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
                return Convert.ToBase64String(encrypted); // Convert to Base64 for easy storage
            }
            catch
            {
                return string.Empty;
            }
        }

        // Decrypts the blob back to text
        public static string Unprotect(string encryptedSecret)
        {
            if (string.IsNullOrEmpty(encryptedSecret)) return string.Empty;

            try
            {
                var data = Convert.FromBase64String(encryptedSecret);
                var decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(decrypted);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
