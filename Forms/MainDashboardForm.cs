using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementIt008.Forms
{
    public partial class MainDashboardForm : BaseForm
    {
        private Form? _currentChildForm; // To keep track of the currently opened child form
        private readonly LoginResponseDto _currentUser; // Store current user info
        private readonly IServiceProvider _serviceProvider;
        public event EventHandler? Logout;

        public MainDashboardForm(LoginResponseDto currentUser, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _serviceProvider = serviceProvider;

            SetupUserInfo();
            SetupButtonEvents();
            SetupButtonHoverEffects();

            // Hide admin-only buttons if not admin
            if (_currentUser.Role != RoleType.Admin)
            {
                btnUsers.Visible = false;
                btnSettings.Visible = false;
                btnParams.Visible = false;
            }

            // Load dashboard by default
            OpenChildForm(ActivatorUtilities.CreateInstance<DashboardForm>(_serviceProvider));
        }

        private void SetupUserInfo()
        {
            lblUsername.Text = $"Welcome, {_currentUser.Username}";
            lblRole.Text = $"Role: {_currentUser.Role}";
        }

        private void SetupButtonEvents()
        {
            btnDashboard.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<DashboardForm>(_serviceProvider));
            btnRooms.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<RoomManagementForm>(_serviceProvider));
            btnBookings.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<BookingManagementForm>(_serviceProvider));
            btnInvoices.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<InvoiceManagementForm>(_serviceProvider));
            btnPayments.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<PaymentManagementForm>(_serviceProvider));
            btnUsers.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<UserManagementForm>(_serviceProvider));
            btnReports.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<ReportsForm>(_serviceProvider));
            btnSettings.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<SettingsForm>(_serviceProvider));
            btnParams.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<ParamForm>(_serviceProvider));

            btnLogout.Click += btnLogout_Click;
        }

        private void SetupButtonHoverEffects()
        {
            var sidebarButtons = new[] { btnDashboard, btnRooms, btnBookings, btnInvoices, btnPayments, btnUsers, btnReports, btnSettings, btnParams };

            foreach (var btn in sidebarButtons)
            {
                btn.MouseEnter += (s, e) =>
                {
                    btn.BackColor = Color.FromArgb(55, 65, 81);
                    btn.ForeColor = Color.White;
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn.Tag?.ToString() != "active")
                    {
                        btn.BackColor = Color.Transparent;
                        btn.ForeColor = Color.FromArgb(209, 213, 219);
                    }
                };
            }
        }

        private void OpenChildForm(Form childForm)
        {
            _currentChildForm?.Close(); // Close existing child form
            _currentChildForm = childForm; // Update current child form reference

            childForm.TopLevel = false; // Set as non-top-level form
            childForm.FormBorderStyle = FormBorderStyle.None; // Remove borders
            childForm.Dock = DockStyle.Fill; // Fill the panel

            pnlContent.Controls.Clear(); // Clear existing controls
            pnlContent.Controls.Add(childForm); // Add new child form
            childForm.Show(); // Show the child form

            ResetSidebarButtonStates(); // Reset all button states
        }

        private void ResetSidebarButtonStates()
        {
            var sidebarButtons = new[] { btnDashboard, btnRooms, btnBookings, btnInvoices, btnPayments, btnUsers, btnReports, btnSettings, btnParams };

            foreach (var btn in sidebarButtons)
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(209, 213, 219);
                btn.Tag = null;
            }
        }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            Logout?.Invoke(this, EventArgs.Empty);
        }
    }
}
