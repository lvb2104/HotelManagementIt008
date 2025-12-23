using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace HotelManagementIt008.Forms
{
    public partial class UserManagementForm : BaseForm
    {
        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;
        private int _currentPage = 1;      // trang hiện tại
        private readonly int _pageSize = 20;        // số dòng mỗi trang
        private int _totalPages = 1;
        public UserManagementForm(
           IUserService userService,
           IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userService = userService;
            _serviceProvider = serviceProvider;

            ConfigureDataGridView();
            _ = LoadUsersAsync();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void cboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private List<UserSummaryDto> _allUsers = new();

        private void ConfigureDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUsername",
                DataPropertyName = "Username",
                HeaderText = "Username",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmail",
                DataPropertyName = "Email",
                HeaderText = "Email",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRole",
                DataPropertyName = "Role",
                HeaderText = "Role",
                Width = 100
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUserType",
                DataPropertyName = "UserType",
                HeaderText = "User Type",
                Width = 100
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCreatedAt",
                DataPropertyName = "CreatedAt",
                HeaderText = "Created At",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                Width = 100
            });
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
            dgvUsers.CellDoubleClick += DgvUsers_CellDoubleClick;
        }
        private void DgvUsers_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvUsers.Rows[e.RowIndex];
            // var userId = (Guid)row.Cells["colId"].Value;
            if (row.Cells["colId"].Value is not Guid userId)
                return;
            using var scope = _serviceProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<UserDetailForm>();
            form.UserId = userId;
            form.ShowDialog();

            _ = LoadUsersAsync(); // reload sau khi đóng form
        }
        private async Task LoadUsersAsync()
        {
            var result = await _userService.GetUserSummariesAsync();
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage ?? "UnKnow error");
                return;
            }

            _allUsers = result.Value ?? new List<UserSummaryDto>();
            dgvUsers.DataSource = _allUsers;
        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadFilterSources();
            await LoadUsersAsync();
        }
        private void LoadFilterSources()
        {
            cboRole.Items.Clear();
            cboRole.Items.Add("All");
            cboRole.Items.AddRange(Enum.GetNames(typeof(RoleType)));
            cboRole.SelectedIndex = 0;

            cboUserType.Items.Clear();
            cboUserType.Items.Add("All");
            cboUserType.Items.AddRange(Enum.GetNames(typeof(UserTypeType)));
            cboUserType.SelectedIndex = 0;
        }
        private void ApplyFilter()
        {
            var username = txtUsername.Text.Trim().ToLower();
            var email = txtEmail.Text.Trim().ToLower();
            var role = cboRole.SelectedItem?.ToString();
            var userType = cboUserType.SelectedItem?.ToString();

            var filtered = _allUsers.Where(u =>
                (string.IsNullOrEmpty(username) || (u.Username?.ToLower().Contains(username) ?? false)) &&
                (string.IsNullOrEmpty(email) || (u.Email?.ToLower().Contains(email) ?? false)) &&
                (role == "All" || u.Role == role) &&
                (userType == "All" || u.UserType == userType)
            ).ToList();
            _totalPages = Math.Max(1,
        (int)Math.Ceiling((double)filtered.Count / _pageSize));
            if (_currentPage > _totalPages) _currentPage = _totalPages;
            if (_currentPage < 1) _currentPage = 1;

            // Lấy dữ liệu trang hiện tại
            var pageData = filtered.Skip((_currentPage - 1) * _pageSize)
                                   .Take(_pageSize)
                                   .ToList();

            // pagination nếu có
            dgvUsers.DataSource = pageData;
            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
            btnPrevious.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtEmail.Clear();
            cboRole.SelectedIndex = 0;
            cboUserType.SelectedIndex = 0;
            dgvUsers.DataSource = _allUsers;
        }
        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<UserDetailForm>();
            form.UserId = null; // null nghĩa là tạo mới
            form.ShowDialog();
            await LoadUsersAsync();
        }
        private async void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            if (dgvUsers.CurrentRow.Cells["colId"].Value is not Guid userId) return;

            using var scope = _serviceProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<UserDetailForm>();
            form.UserId = userId;
            form.ShowDialog();
            await LoadUsersAsync();
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            if (dgvUsers.CurrentRow.Cells["colId"].Value is not Guid userId) return;

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            var result = await _userService.DeleteUserAsync(userId); // cần tạo method DeleteUserAsync trong IUserService
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage ?? "Delete failed");
                return;
            }

            await LoadUsersAsync();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // TODO: xử lý in hoặc xuất dữ liệu
            // Ví dụ đơn giản xuất DataGridView ra CSV
            StringBuilder csv = new StringBuilder();

            foreach (DataGridViewColumn col in dgvUsers.Columns)
                csv.Append(col.HeaderText + ",");
            csv.AppendLine();

            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    csv.Append(cell.Value + ",");
                csv.AppendLine();
            }

            File.WriteAllText("Users.csv", csv.ToString());
            MessageBox.Show("Exported to Users.csv");
        }
        private void DgvUsers_SelectionChanged(object? sender, EventArgs e)
        {
            bool hasSelection = dgvUsers.SelectedRows.Count > 0;

            btnEditUser.Enabled = hasSelection;
            btnDeleteUser.Enabled = hasSelection;
            btnPrint.Enabled = hasSelection;
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage <= 1)
                return;

            _currentPage--;
            ApplyFilter(); // ✅ giống Next
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                ApplyFilter();
            }
        }

    }
}
