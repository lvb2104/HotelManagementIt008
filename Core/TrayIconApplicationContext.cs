
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementIt008.Core
{
    public class TrayIconApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _trayIcon;
        private readonly ContextMenuStrip _menuStrip;
        private readonly IServiceProvider _serviceProvider;
        private Form? _currentForm;
        private bool _isExiting = false;

        public TrayIconApplicationContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Application.ApplicationExit += ApplicationExitHanlder;

            _menuStrip = new ContextMenuStrip();
            _menuStrip.Items.Add("Open", null, (s, e) => ShowCurrentForm());
            _menuStrip.Items.Add("Exit", null, ExitContextMenuClickHandler);

            _trayIcon = new NotifyIcon()
            {
                ContextMenuStrip = _menuStrip,
                Text = Application.ProductName,
                Visible = true,
                Icon = Resources.Tray
            };
            _trayIcon.MouseClick += TrayIconMouseClickHandler;

            ShowLogin();
        }

        private void ShowLogin()
        {
            if (_currentForm is not null)
            {
                _currentForm.FormClosing -= OnFormClosing; // Unsubscribe to avoid triggering hiding
                _currentForm.Close();
            }

            var loginForm = ActivatorUtilities.CreateInstance<LoginForm>(_serviceProvider);

            // If Login in LoginForm is successful, invoke ShowMainDashBoard function
            loginForm.LoginSuccess += (s, response) => ShowMainDashBoard(response);

            // If the login form is closed by the user, hide the current form
            loginForm.FormClosing += OnFormClosing;

            _currentForm = loginForm;
            _currentForm.Show();
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_isExiting)
            {
                // Cancel the close operation
                e.Cancel = true;

                // Hide the form instead
                if (sender is Form form)
                {
                    form.Hide();
                }
            }
        }

        private void ShowMainDashBoard(LoginResponseDto response)
        {
            if (_currentForm != null)
            {
                _currentForm.FormClosing -= OnFormClosing; // Unsubscribe to avoid triggering hiding
                _currentForm.Close();
            }

            var mainDashBoardForm = ActivatorUtilities.CreateInstance<MainDashboardForm>(_serviceProvider, response);

            // If Logout is triggered in MainDashBoardForm, invoke ShowLogin function
            mainDashBoardForm.Logout += (s, e) => ShowLogin();

            // If the main dashboard form is closed by the user, hide the current form
            mainDashBoardForm.FormClosing += OnFormClosing;

            _currentForm = mainDashBoardForm;
            _currentForm.Show();
        }

        private void ExitContextMenuClickHandler(object? sender, EventArgs e)
        {
            // Set the exiting flag to true to indicate the application is exiting
            _isExiting = true;

            // Kill the application
            ExitThread();
        }

        private void TrayIconMouseClickHandler(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _currentForm is not null)
            {
                ShowCurrentForm();
            }
            // Right-click is handled by ContextMenuStrip automatically
        }

        private void ShowCurrentForm()
        {
            if (_currentForm != null && !_currentForm.IsDisposed)
            {
                _currentForm.Show();
                if (_currentForm.WindowState == FormWindowState.Minimized)
                    _currentForm.WindowState = FormWindowState.Normal;
                _currentForm.Activate();
            }
        }

        // Clean up any resources
        private void ApplicationExitHanlder(object? sender, EventArgs e)
        {
            if (_trayIcon is not null)
            {
                _trayIcon.Visible = false;
                _trayIcon.Dispose();
            }

            if (_menuStrip is not null)
            {
                _menuStrip.Dispose();
            }

            if (_currentForm is not null)
            {
                _currentForm.FormClosing -= OnFormClosing;
                _currentForm.Close();
                _currentForm.Dispose();
            }
        }
    }
}
