using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagementIt008.Forms
{
    partial class UserManagementForm
    {
        private Panel pnlTitle;
        private Label lblTitle;

        private TextBox txtUsername;
        private TextBox txtEmail;
        private TextBox txtFullName;
        private ComboBox cboRole;
        private ComboBox cboUserType;
        private ComboBox cboStatus;

        private Button btnSearch;
        private Button btnClearFilter;

        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnPrint;

        private DataGridView dgvUsers;

        private Button btnPrevious;
        private Button btnNext;
        private Label lblPageInfo;

        private void InitializeComponent()
        {
            // ===============================
            // Form
            // ===============================
            this.ClientSize = new Size(1200, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "User Management";
            this.Font = new Font("Segoe UI", 10.5F);

            // ===============================
            // Title Panel
            // ===============================
            pnlTitle = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(25, 118, 210)
            };
            lblTitle = new Label
            {
                Text = "User Management",
                BackColor = Color.White,
                ForeColor = Color.FromArgb(33,57,155),
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };
            pnlTitle.Controls.Add(lblTitle);
            this.Controls.Add(pnlTitle);

            // ===============================
            // Search Filters
            // ===============================
            int filterTop = pnlTitle.Bottom + 20;

            txtUsername = new TextBox { Location = new Point(30, filterTop), Size = new Size(160, 30), PlaceholderText = "Username" };
            txtEmail = new TextBox { Location = new Point(200, filterTop), Size = new Size(160, 30), PlaceholderText = "Email" };
            txtFullName = new TextBox { Location = new Point(370, filterTop), Size = new Size(160, 30), PlaceholderText = "Full Name" };
            cboRole = new ComboBox { Location = new Point(540, filterTop), Size = new Size(120, 30), DropDownStyle = ComboBoxStyle.DropDownList };
            cboUserType = new ComboBox { Location = new Point(670, filterTop), Size = new Size(120, 30), DropDownStyle = ComboBoxStyle.DropDownList };
           //  cboStatus = new ComboBox { Location = new Point(800, filterTop), Size = new Size(120, 30), DropDownStyle = ComboBoxStyle.DropDownList };

            btnSearch = new Button
            {
                Text = "Search",
                Location = new Point(940, filterTop),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSearch.FlatAppearance.BorderSize = 0;

            btnClearFilter = new Button
            {
                Text = "Clear Filters",
                Location = new Point(1050, filterTop),
                Size = new Size(100, 30),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClearFilter.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { txtUsername, txtEmail, txtFullName, cboRole, cboUserType, cboStatus, btnSearch, btnClearFilter });

            // ===============================
            // Action Buttons
            // ===============================
            int actionTop = filterTop + 50;

            btnAddUser = new Button
            {
                Text = "➕ Add User",
                Location = new Point(30, actionTop),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAddUser.FlatAppearance.BorderSize = 0;

            btnEditUser = new Button
            {
                Text = "✏️ Edit",
                Location = new Point(200, actionTop),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(255, 152, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnEditUser.FlatAppearance.BorderSize = 0;

            btnDeleteUser = new Button
            {
                Text = "🗑️ Delete",
                Location = new Point(370, actionTop),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDeleteUser.FlatAppearance.BorderSize = 0;

            btnPrint = new Button
            {
                Text = "📄 Print",
                Location = new Point(540, actionTop),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnPrint.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { btnAddUser, btnEditUser, btnDeleteUser, btnPrint });

            // ===============================
            // DataGridView
            // ===============================
            dgvUsers = new DataGridView
            {
                Location = new Point(30, actionTop + 60),
                Size = new Size(1120, 580),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoGenerateColumns = false,
                RowTemplate = { Height = 36 },
                Font = new Font("Segoe UI", 10.5F)
            };
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.Controls.Add(dgvUsers);

            // ===============================
            // Pagination
            // ===============================
            int pageTop = dgvUsers.Bottom + 10;

            btnPrevious = new Button { Text = "◀ Previous", Location = new Point(30, pageTop), Size = new Size(120, 30) };
            btnNext = new Button { Text = "Next ▶", Location = new Point(1030, pageTop), Size = new Size(120, 30) };
            lblPageInfo = new Label { Text = "Page 1 of 1", Location = new Point(550, pageTop), AutoSize = true, Font = new Font("Segoe UI", 11F, FontStyle.Bold) };

            this.Controls.AddRange(new Control[] { btnPrevious, btnNext, lblPageInfo });
        }
    }
}
