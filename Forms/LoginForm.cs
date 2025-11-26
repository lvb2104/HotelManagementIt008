using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace HotelManagementIt008.Forms
{
    public partial class LoginForm : BaseForm
    {
        private readonly IUserService _userService;
        public event EventHandler<LoginResponseDto>? LoginSuccess;

        public LoginForm(IUserService userService)
        {
            _userService = userService;

            InitializeComponent();
            ApplyCustomFont();
            SetupCustomEvents();
            LoadSavedCredentials();
        }

        private void LoadSavedCredentials()
        {
            if (Settings.Default.IsRemembered)
            {
                txtUsername.Text = Settings.Default.Username;
                txtPassword.Text = SecurityHelper.Unprotect(Settings.Default.EncryptedPassword);
                chkRememberMe.Checked = true;
            }
        }

        private void SetupCustomEvents()
        {
            // Hover effects for Login button
            btnLogin.MouseEnter += (s, e) =>
                btnLogin.BackColor = Color.FromArgb(25, 118, 210);
            btnLogin.MouseLeave += (s, e) =>
                btnLogin.BackColor = Color.FromArgb(0, 117, 214);

            // Enter key on password = login
            txtPassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                    btnLogin_Click(s, e);
            };
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '•';
        }

        private async void btnLogin_Click(object? sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter your username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                var dto = new LoginRequestDto
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };

                var result = await _userService.LogInAsync(dto);

                if (result.IsSuccess)
                {
                    if (result.Value == null)
                    {
                        MessageBox.Show("Login failed. Please try again.",
                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SaveCredentials();
                    LoginSuccess?.Invoke(this, result.Value);
                }
                else
                {
                    // Invalid credentials
                    MessageBox.Show("Invalid username or password.",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("An error occurred during login. Please try again later.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCredentials()
        {
            if (chkRememberMe.Checked)
            {
                Settings.Default.Username = txtUsername.Text;
                Settings.Default.EncryptedPassword = SecurityHelper.Protect(txtPassword.Text);
                Settings.Default.IsRemembered = true;
            }
            else
            {
                Settings.Default.Username = string.Empty;
                Settings.Default.EncryptedPassword = string.Empty;
                Settings.Default.IsRemembered = false;
            }
            Settings.Default.Save();
        }

        private void ApplyCustomFont()
        {
            // Get the font bytes from Resources
            var fontData = Resources.Bauhaus93Regular;

            // Allocate memory
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);

            // Copy the font data to the allocated memory
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

            // Create a PrivateFontCollection
            PrivateFontCollection pfc = new PrivateFontCollection();

            // Add the font to the PrivateFontCollection
            pfc.AddMemoryFont(fontPtr, fontData.Length);

            // Free the allocated memory
            Marshal.FreeCoTaskMem(fontPtr);

            title.Font = new Font(pfc.Families[0], 24f, FontStyle.Regular);
        }
    }
}
