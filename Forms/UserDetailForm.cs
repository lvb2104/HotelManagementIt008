using System.ComponentModel;

namespace HotelManagementIt008.Forms
{
    public partial class UserDetailForm : Form
    {
        private readonly IUserService _userService;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid? UserId { get; set; }

        public UserDetailForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            LoadUserTypes();
        }

        private void BindUser(UserResponseDto user)
        {
            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtFullName.Text = user.FullName ?? string.Empty;
            txtAddress.Text = user.Address ?? string.Empty;
            txtIdentityNumber.Text = user.IdentityNumber ?? string.Empty;

            // if (user.UserType != null)
            // {
            cboUserType.SelectedItem = user.UserType;
            cboRole.SelectedItem = user.Role;
            // }

        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (UserId.HasValue)
            {
                Text = "Edit User";
                txtUsername.Enabled = false;
                lblPassword.Visible = false;
                txtPassword.Visible = false;

                var result = await _userService.GetUserByIdAsync(UserId.Value);

                if (!result.IsSuccess || result.Value == null)
                {
                    MessageBox.Show("Không thể tải thông tin người dùng");
                    Close();
                    return;
                }

                BindUser(result.Value);
            }
            else
            {
                Text = "Create User";
                // Ensure defaults for Create mode
                txtUsername.Enabled = true;
                lblPassword.Visible = true;
                txtPassword.Visible = true;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (UserId.HasValue)
            {
                // Edit user
                var updateDto = new UpdateUserDto
                {
                    Username = txtUsername.Text,
                    Email = txtEmail.Text,
                    FullName = txtFullName.Text,
                    Address = txtAddress.Text,
                    IdentityNumber = txtIdentityNumber.Text,
                    UserType = (UserTypeType?)cboUserType.SelectedItem,
                    Role = (RoleType?)cboRole.SelectedItem,
                    Password = txtPassword.Text
                };

                var result = await _userService.UpdateUserAsync(UserId.Value, updateDto);
                if (result.IsSuccess)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage);
                }
            }
            else
            {
                // Add new user
                var createDto = new CreateUserDto
                {
                    Username = txtUsername.Text,
                    Email = txtEmail.Text,
                    FullName = txtFullName.Text,
                    Address = txtAddress.Text,
                    IdentityNumber = txtIdentityNumber.Text,
                    //UserType = (UserTypeType)cboUserType.SelectedItem
                    UserType = cboUserType.SelectedItem as UserTypeType? ?? UserTypeType.Local,
                    Role = (RoleType?)cboRole.SelectedItem ?? RoleType.Customer,
                    Password = txtPassword.Text
                };

                var result = await _userService.CreateUserAsync(createDto);
                if (result.IsSuccess)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage);
                }
            }
        }

        private void LoadUserTypes()
        {
            // Lấy tất cả giá trị từ enum UserTypeType
            cboUserType.DataSource = Enum.GetValues(typeof(UserTypeType));
            cboRole.DataSource = Enum.GetValues(typeof(RoleType));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
