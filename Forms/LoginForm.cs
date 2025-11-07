using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace HotelManagementIt008.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private readonly RoomManagementForm _roomManagementForm;

        public LoginForm(IUserService userService, RoomManagementForm roomManagementForm)
        {
            _userService = userService;
            InitializeComponent();
            ApplyCustomFont();
            SetupCustomEvents();
            _roomManagementForm = roomManagementForm;
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

        private async void btnLogin_Click(object sender, EventArgs e)
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
                var loginRequestDto = new LoginRequestDto
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };
                var result = await _userService.LogInAsync(loginRequestDto);
                if (result.IsSuccess)
                {
                    // Successful login
                    MessageBox.Show("Login successful!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open MainForm
                    this.Hide();
                    _roomManagementForm.FormClosed += (_, __) => this.Close(); // closes hidden LoginForm => app exits
                    _roomManagementForm.Show();
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

        private void ApplyCustomFont()
        {
            // Get the font bytes from Resources
            var fontData = HotelManagementIt008.Properties.Resources.Bauhaus_93_Regular;

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
