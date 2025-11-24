namespace HotelManagementIt008.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            LoadStatCards();
        }

        private void LoadStatCards()
        {
            flpStats.Controls.Clear();
            flpStats.Controls.Add(CreateStatCard("Total Rooms", "120", Color.FromArgb(59, 130, 246)));
            flpStats.Controls.Add(CreateStatCard("Occupied", "85", Color.FromArgb(16, 185, 129)));
            flpStats.Controls.Add(CreateStatCard("Available", "35", Color.FromArgb(245, 158, 11)));
            flpStats.Controls.Add(CreateStatCard("Revenue (Month)", "$45,230", Color.FromArgb(239, 68, 68)));
        }

        private Panel CreateStatCard(string title, string value, Color accentColor)
        {
            var card = new Panel
            {
                Width = 280,
                Height = 120,
                BackColor = Color.White,
                Margin = new Padding(10),
                Padding = new Padding(20)
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(107, 114, 128),
                Dock = DockStyle.Top,
                Height = 25
            };

            var lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = accentColor,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);

            return card;
        }
    }
}