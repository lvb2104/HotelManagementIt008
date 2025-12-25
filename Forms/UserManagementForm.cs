using System.Text;

using Gridify;

using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementIt008.Forms
{
    public partial class UserManagementForm : BaseForm
    {
        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;
        private int _currentPage = 1;
        private readonly int _pageSize = 20;
        private int _totalPages = 1;
        private int _totalCount = 0;
        public UserManagementForm(
           IUserService userService,
           IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userService = userService;
            _serviceProvider = serviceProvider;

            ConfigureDataGridView();
        }
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await ApplyFilter();
        }

        private async void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            await ApplyFilter();
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await ApplyFilter();
        }
        private async void cboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            await ApplyFilter();
        }


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
                Name = "colFullName",
                DataPropertyName = "FullName",
                HeaderText = "Full Name",
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
            var gridifyQuery = new GridifyQuery
            {
                Page = _currentPage,
                PageSize = _pageSize,
                OrderBy = "createdAt desc"
            };

            var result = await _userService.GetUserSummariesAsync(gridifyQuery);
            if (!result.IsSuccess)
            {
                MessageBox.Show("Failed to load users: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _totalCount = result.Value?.Count ?? 0;
            _totalPages = (int)Math.Ceiling((decimal)_totalCount / _pageSize);
            if (_totalPages == 0) _totalPages = 1;

            dgvUsers.DataSource = result.Value?.Data;
            UpdatePaginationControls();
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
        private async Task ApplyFilter()
        {
            try
            {
                var username = txtUsername.Text.Trim();
                var email = txtEmail.Text.Trim();
                var role = cboRole.SelectedItem?.ToString();
                var userType = cboUserType.SelectedItem?.ToString();

                // Build filter string for Gridify
                var filters = new List<string>();

                if (!string.IsNullOrWhiteSpace(username))
                {
                    filters.Add($"username=*{username}");
                }

                if (!string.IsNullOrWhiteSpace(email))
                {
                    filters.Add($"email=*{email}");
                }

                if (!string.IsNullOrWhiteSpace(role) && role != "All")
                {
                    filters.Add($"role={role}");
                }

                if (!string.IsNullOrWhiteSpace(userType) && userType != "All")
                {
                    filters.Add($"userType={userType}");
                }

                var filterString = filters.Any() ? string.Join(",", filters) : string.Empty;

                var gridifyQuery = new GridifyQuery
                {
                    Page = _currentPage,
                    PageSize = _pageSize,
                    Filter = filterString,
                    OrderBy = "createdAt desc"
                };

                var result = await _userService.GetUserSummariesAsync(gridifyQuery);
                if (!result.IsSuccess)
                {
                    MessageBox.Show("Failed to filter users: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _totalCount = result.Value?.Count ?? 0;
                _totalPages = Math.Max(1, (int)Math.Ceiling((double)_totalCount / _pageSize));

                dgvUsers.DataSource = result.Value?.Data;
                UpdatePaginationControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePaginationControls()
        {
            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
            btnPrevious.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;
        }

        private async void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtEmail.Clear();
            cboRole.SelectedIndex = 0;
            cboUserType.SelectedIndex = 0;
            _currentPage = 1;
            await ApplyFilter();
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
        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage <= 1)
                return;

            _currentPage--;
            await ApplyFilter();
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await ApplyFilter();
            }
        }

    }
}
