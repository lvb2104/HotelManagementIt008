using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementIt008.Forms
{
    public partial class MainDashboardForm : BaseForm
    {
        private Form? _currentChildForm; // To keep track of the currently opened child form
        private readonly LoginResponseDto _currentUser; // Store current user info
        private readonly IServiceProvider _serviceProvider;
        public event EventHandler? Logout;

        // Active Style Colors
        private readonly Color _activeBackColor = ColorTranslator.FromHtml("#2d3748");
        private readonly Color _accentColor = ColorTranslator.FromHtml("#3b82f6");

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
            OpenChildForm(ActivatorUtilities.CreateInstance<DashboardForm>(_serviceProvider), btnDashboard);
        }

        private void SetupUserInfo()
        {
            lblUsername.Text = $"Welcome, {_currentUser.Username}";
            lblRole.Text = $"Role: {_currentUser.Role}";
        }

        private void SetupButtonEvents()
        {
            btnDashboard.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<DashboardForm>(_serviceProvider), s);
            btnRooms.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<RoomManagementForm>(_serviceProvider), s);
            btnBookings.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<BookingManagementForm>(_serviceProvider, _currentUser.Id), s);
            btnInvoices.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<InvoiceManagementForm>(_serviceProvider, _currentUser.Id), s);
            btnPayments.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<PaymentManagementForm>(_serviceProvider), s);
            btnUsers.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<UserManagementForm>(_serviceProvider), s);
            btnReports.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<ReportsForm>(_serviceProvider), s);
            btnSettings.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<SettingsForm>(_serviceProvider), s);
            btnParams.Click += (s, e) => OpenChildForm(ActivatorUtilities.CreateInstance<ParamForm>(_serviceProvider), s);

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

        private void OpenChildForm(Form childForm, object? sender)
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
            
            if (sender is Button btn)
            {
                btn.BackColor = _activeBackColor;
                btn.ForeColor = Color.White;
                btn.Tag = "active";
                btn.Paint += Button_Paint_Active; // Subscribe to paint event for custom border
            }
        }

        private void Button_Paint_Active(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                // Draw left border
                using (var brush = new SolidBrush(_accentColor))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, 5, btn.Height);
                }
            }
        }

        private void ResetSidebarButtonStates()
        {
            var sidebarButtons = new[] { btnDashboard, btnRooms, btnBookings, btnInvoices, btnPayments, btnUsers, btnReports, btnSettings, btnParams };

            foreach (var btn in sidebarButtons)
            {
                if (btn.Tag?.ToString() == "active")
                {
                    btn.Paint -= Button_Paint_Active; // Unsubscribe to avoid memory leaks or double drawing
                    btn.Invalidate(); // Force redraw to remove border
                }

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
