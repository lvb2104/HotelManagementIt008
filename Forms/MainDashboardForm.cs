using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementIt008.Forms
{
    public partial class MainDashboardForm : BaseForm
    {
        private Form? _currentChildForm; // To keep track of the currently opened child form
        private readonly List<IServiceScope> _scopes = []; // Track all scopes for disposal when form closes
        private readonly ICurrentUserService _currentUserService;
        private readonly IServiceProvider _serviceProvider;
        public event EventHandler? Logout;

        // Active Style Colors
        private readonly Color _activeBackColor = ColorTranslator.FromHtml("#2d3748");
        private readonly Color _accentColor = ColorTranslator.FromHtml("#3b82f6");

        public MainDashboardForm(ICurrentUserService currentUserService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _currentUserService = currentUserService;
            _serviceProvider = serviceProvider;

            SetupUserInfo();
            SetupButtonEvents();
            SetupButtonHoverEffects();

            // Apply Role-Based Access Control (RBAC)
            switch (_currentUserService.Role)
            {
                case RoleType.Admin:
                    // Admin has full access
                    break;
                case RoleType.Staff:
                    // Staff has everything except Params
                    btnParams.Visible = false;
                    break;
                case RoleType.Customer:
                default:
                    // Customer only sees Dashboard
                    btnRooms.Visible = false;
                    btnRoomTypes.Visible = false;
                    btnBookings.Visible = false;
                    btnInvoices.Visible = false;
                    btnPayments.Visible = false;
                    btnUsers.Visible = false;
                    btnReports.Visible = false;
                    btnSettings.Visible = false;
                    btnParams.Visible = false;
                    break;
            }

            // Dispose all scopes when this form closes
            this.FormClosed += (s, e) =>
            {
                foreach (var scope in _scopes)
                {
                    scope?.Dispose();
                }
                _scopes.Clear();
            };

            // Load dashboard by default
            OpenChildForm<DashboardForm>(btnDashboard);
        }

        private void SetupUserInfo()
        {
            lblUsername.Text = $"Welcome, {_currentUserService.Username}";
            lblRole.Text = $"Role: {_currentUserService.Role}";
        }

        private void SetupButtonEvents()
        {
            btnDashboard.Click += (s, e) => OpenChildForm<DashboardForm>(s);
            btnRooms.Click += (s, e) => OpenChildForm<RoomManagementForm>(s);
            btnRoomTypes.Click += (s, e) => OpenChildForm<RoomTypeManagementForm>(s);
            btnBookings.Click += (s, e) => OpenChildForm<BookingManagementForm>(s);
            btnInvoices.Click += (s, e) => OpenChildForm<InvoiceManagementForm>(s);
            btnPayments.Click += (s, e) => OpenChildForm<PaymentManagementForm>(s);
            btnUsers.Click += (s, e) => OpenChildForm<UserManagementForm>(s);
            btnReports.Click += (s, e) => OpenChildForm<ReportsForm>(s);
            btnSettings.Click += (s, e) => OpenChildForm<SettingsForm>(s);
            btnParams.Click += (s, e) => OpenChildForm<ParamForm>(s);

            btnLogout.Click += btnLogout_Click;
        }

        private void SetupButtonHoverEffects()
        {
            var sidebarButtons = new[] { btnDashboard, btnRooms, btnRoomTypes, btnBookings, btnInvoices, btnPayments, btnUsers, btnReports, btnSettings, btnParams };

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

        private void OpenChildForm<T>(object? sender) where T : Form
        {
            // Close existing child form
            _currentChildForm?.Close();

            // Create a new scope for the new form
            var newScope = _serviceProvider.CreateScope();
            _scopes.Add(newScope); // Track scope for disposal when MainDashboardForm closes

            var childForm = newScope.ServiceProvider.GetRequiredService<T>();
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
            var sidebarButtons = new[] { btnDashboard, btnRooms, btnRoomTypes, btnBookings, btnInvoices, btnPayments, btnUsers, btnReports, btnSettings, btnParams };

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
