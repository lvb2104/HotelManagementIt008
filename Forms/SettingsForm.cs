namespace HotelManagementIt008.Forms
{
    public partial class SettingsForm : BaseForm
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public SettingsForm(IUserService userService, ICurrentUserService currentUserService)
        {
            try 
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing SettingsForm: {ex.Message}\nStack: {ex.StackTrace}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _userService = userService;
            _currentUserService = currentUserService;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Simple validation
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("New password and confirmation do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new ChangePasswordRequestDto
            {
                OldPassword = txtOldPassword.Text,
                NewPassword = txtNewPassword.Text,
                ConfirmPassword = txtConfirmPassword.Text
            };

            try
            {
                var result = await _userService.ChangePasswordAsync(_currentUserService.UserId, dto);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Reset fields
                    txtOldPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();

                    // Reset visibility to hidden
                    txtOldPassword.PasswordChar = '*';
                    btnShowOldPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
                    
                    txtNewPassword.PasswordChar = '*';
                    btnShowNewPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;

                    txtConfirmPassword.PasswordChar = '*';
                    btnShowConfirmPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage ?? "Failed to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TogglePasswordVisibility(TextBox textBox, FontAwesome.Sharp.IconButton iconButton)
        {
            if (textBox.PasswordChar == '*')
            {
                textBox.PasswordChar = '\0';
                iconButton.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                textBox.PasswordChar = '*';
                iconButton.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        private void btnShowOldPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(txtOldPassword, btnShowOldPassword);
        }

        private void btnShowNewPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(txtNewPassword, btnShowNewPassword);
        }

        private void btnShowConfirmPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(txtConfirmPassword, btnShowConfirmPassword);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
