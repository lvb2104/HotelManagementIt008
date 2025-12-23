using HotelManagementIt008.Dtos.Requests;
using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Services.Interfaces;
using HotelManagementIt008.Types;
using System.ComponentModel;

namespace HotelManagementIt008.Forms
{
    public partial class UserDetailForm : Form
    {
        private readonly IUserService _userService;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid? UserId { get; set; }

        private BindingList<CreateParticipantDto> _participants = new BindingList<CreateParticipantDto>();
        private UserResponseDto? _user;

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
           // }

        }

        public UserDetailForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            ConfigureParticipantsGrid();
            LoadUserTypes();
        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (UserId == null) return;

            var result = await _userService.GetUserByIdAsync(UserId.Value);

            if (!result.IsSuccess || result.Value == null)
            {
                MessageBox.Show("Không thể tải thông tin người dùng");
                Close();
                return;
            }

            BindUser(result.Value);
        }

        private void UserDetailForm_Load(object sender, EventArgs e)
        {
            // 1️⃣ Load enum vào ComboBox TRƯỚC
         //   cboUserType.DataSource = Enum.GetValues(typeof(UserTypeType));
         //   cboRole.DataSource = Enum.GetValues(typeof(RoleType));

            if (UserId.HasValue)
            {
                Text = "Edit User";
                txtUsername.Enabled = false; // Username không đổi
                LoadUserDetails();           // 2️⃣ Sau đó mới gán SelectedItem
            }
            else
            {
                Text = "Create User";
            }
        }

        private void ConfigureParticipantsGrid()
        {
            dgvParticipants.AutoGenerateColumns = false;
            dgvParticipants.DataSource = _participants;
            dgvParticipants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParticipants.MultiSelect = false;
            dgvParticipants.Columns.Clear();

            dgvParticipants.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Width = 150
            });
            dgvParticipants.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Full Name",
                Width = 150
            });
            dgvParticipants.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Address",
                Width = 150
            });
            dgvParticipants.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdentityNumber",
                HeaderText = "Identity Number",
                Width = 120
            });

            var userTypeColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "UserType",
                HeaderText = "User Type",
                DataSource = Enum.GetValues(typeof(UserTypeType)),
                Width = 120
            };
            dgvParticipants.Columns.Add(userTypeColumn);
        }

        private async void LoadUserDetails()
        {
            if (!UserId.HasValue)
                return;
            var result = await _userService.GetUserByIdAsync(UserId.Value);

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage);
                return;
            }

            var user = result.Value!; // 👈 ĐÚNG

            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtAddress.Text = user.Address;
            txtFullName.Text = user.FullName;
            txtIdentityNumber.Text = user.IdentityNumber;
            cboUserType.SelectedItem = user.UserType;

        }


        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            _participants.Add(new CreateParticipantDto { UserType = UserTypeType.Local });
        }

        private void btnRemoveParticipant_Click(object sender, EventArgs e)
        {
            if (dgvParticipants.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvParticipants.SelectedRows)
                {
                    if (row.DataBoundItem is CreateParticipantDto item)
                        _participants.Remove(item);
                }
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
                    UserType = (UserTypeType?)cboUserType.SelectedItem
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
