namespace HotelManagementIt008.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            flpStats = new FlowLayoutPanel();
            statTotalRoomsCard = new HotelManagementIt008.UserControls.StatCardControl();
            statOccupiedRoomsCard = new HotelManagementIt008.UserControls.StatCardControl();
            statAvailableRoomsCard = new HotelManagementIt008.UserControls.StatCardControl();
            statRevenueMonthCard = new HotelManagementIt008.UserControls.StatCardControl();
            statReservedRoomsCard = new HotelManagementIt008.UserControls.StatCardControl();
            statOutOfServiceRoomsCard = new HotelManagementIt008.UserControls.StatCardControl();
            statNumberOfCustomersCard = new HotelManagementIt008.UserControls.StatCardControl();
            statRevenueYearCard = new HotelManagementIt008.UserControls.StatCardControl();
            flpStats.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(331, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 Dashboard Overview";
            // 
            // flpStats
            // 
            flpStats.AutoSize = true;
            flpStats.Controls.Add(statTotalRoomsCard);
            flpStats.Controls.Add(statOccupiedRoomsCard);
            flpStats.Controls.Add(statAvailableRoomsCard);
            flpStats.Controls.Add(statRevenueMonthCard);
            flpStats.Controls.Add(statReservedRoomsCard);
            flpStats.Controls.Add(statOutOfServiceRoomsCard);
            flpStats.Controls.Add(statNumberOfCustomersCard);
            flpStats.Controls.Add(statRevenueYearCard);
            flpStats.Dock = DockStyle.Top;
            flpStats.Location = new Point(0, 37);
            flpStats.Name = "flpStats";
            flpStats.Size = new Size(1094, 280);
            flpStats.TabIndex = 1;
            // 
            // statTotalRoomsCard
            // 
            statTotalRoomsCard.AccentColor = Color.Blue;
            statTotalRoomsCard.BackColor = Color.White;
            statTotalRoomsCard.Location = new Point(10, 10);
            statTotalRoomsCard.Margin = new Padding(10);
            statTotalRoomsCard.Name = "statTotalRoomsCard";
            statTotalRoomsCard.Padding = new Padding(20);
            statTotalRoomsCard.Size = new Size(250, 120);
            statTotalRoomsCard.TabIndex = 0;
            statTotalRoomsCard.TitleText = "Total Rooms";
            statTotalRoomsCard.ValueText = "123";
            // 
            // statOccupiedRoomsCard
            // 
            statOccupiedRoomsCard.AccentColor = Color.Green;
            statOccupiedRoomsCard.BackColor = Color.White;
            statOccupiedRoomsCard.Location = new Point(280, 10);
            statOccupiedRoomsCard.Margin = new Padding(10);
            statOccupiedRoomsCard.Name = "statOccupiedRoomsCard";
            statOccupiedRoomsCard.Padding = new Padding(20);
            statOccupiedRoomsCard.Size = new Size(250, 120);
            statOccupiedRoomsCard.TabIndex = 1;
            statOccupiedRoomsCard.TitleText = "Occupied";
            statOccupiedRoomsCard.ValueText = "123";
            // 
            // statAvailableRoomsCard
            // 
            statAvailableRoomsCard.AccentColor = Color.Orange;
            statAvailableRoomsCard.BackColor = Color.White;
            statAvailableRoomsCard.Location = new Point(550, 10);
            statAvailableRoomsCard.Margin = new Padding(10);
            statAvailableRoomsCard.Name = "statAvailableRoomsCard";
            statAvailableRoomsCard.Padding = new Padding(20);
            statAvailableRoomsCard.Size = new Size(250, 120);
            statAvailableRoomsCard.TabIndex = 2;
            statAvailableRoomsCard.TitleText = "Available";
            statAvailableRoomsCard.ValueText = "123";
            // 
            // statRevenueMonthCard
            // 
            statRevenueMonthCard.AccentColor = Color.Red;
            statRevenueMonthCard.BackColor = Color.White;
            statRevenueMonthCard.Location = new Point(820, 10);
            statRevenueMonthCard.Margin = new Padding(10);
            statRevenueMonthCard.Name = "statRevenueMonthCard";
            statRevenueMonthCard.Padding = new Padding(20);
            statRevenueMonthCard.Size = new Size(250, 120);
            statRevenueMonthCard.TabIndex = 3;
            statRevenueMonthCard.TitleText = "Revenue (Month)";
            statRevenueMonthCard.ValueText = "123";
            // 
            // statReservedRoomsCard
            // 
            statReservedRoomsCard.AccentColor = Color.FromArgb(139, 92, 246);
            statReservedRoomsCard.BackColor = Color.White;
            statReservedRoomsCard.Location = new Point(10, 150);
            statReservedRoomsCard.Margin = new Padding(10);
            statReservedRoomsCard.Name = "statReservedRoomsCard";
            statReservedRoomsCard.Padding = new Padding(20);
            statReservedRoomsCard.Size = new Size(250, 120);
            statReservedRoomsCard.TabIndex = 4;
            statReservedRoomsCard.TitleText = "Reserved";
            statReservedRoomsCard.ValueText = "123";
            // 
            // statOutOfServiceRoomsCard
            // 
            statOutOfServiceRoomsCard.AccentColor = Color.FromArgb(245, 158, 11);
            statOutOfServiceRoomsCard.BackColor = Color.White;
            statOutOfServiceRoomsCard.Location = new Point(280, 150);
            statOutOfServiceRoomsCard.Margin = new Padding(10);
            statOutOfServiceRoomsCard.Name = "statOutOfServiceRoomsCard";
            statOutOfServiceRoomsCard.Padding = new Padding(20);
            statOutOfServiceRoomsCard.Size = new Size(250, 120);
            statOutOfServiceRoomsCard.TabIndex = 5;
            statOutOfServiceRoomsCard.TitleText = "Out Of Service";
            statOutOfServiceRoomsCard.ValueText = "123";
            // 
            // statNumberOfCustomersCard
            // 
            statNumberOfCustomersCard.AccentColor = Color.FromArgb(244, 63, 94);
            statNumberOfCustomersCard.BackColor = Color.White;
            statNumberOfCustomersCard.Location = new Point(550, 150);
            statNumberOfCustomersCard.Margin = new Padding(10);
            statNumberOfCustomersCard.Name = "statNumberOfCustomersCard";
            statNumberOfCustomersCard.Padding = new Padding(20);
            statNumberOfCustomersCard.Size = new Size(250, 120);
            statNumberOfCustomersCard.TabIndex = 6;
            statNumberOfCustomersCard.TitleText = "Number of customers";
            statNumberOfCustomersCard.ValueText = "123";
            // 
            // statRevenueYearCard
            // 
            statRevenueYearCard.AccentColor = Color.FromArgb(6, 182, 212);
            statRevenueYearCard.BackColor = Color.White;
            statRevenueYearCard.Location = new Point(820, 150);
            statRevenueYearCard.Margin = new Padding(10);
            statRevenueYearCard.Name = "statRevenueYearCard";
            statRevenueYearCard.Padding = new Padding(20);
            statRevenueYearCard.Size = new Size(250, 120);
            statRevenueYearCard.TabIndex = 7;
            statRevenueYearCard.TitleText = "Revenue (Year)";
            statRevenueYearCard.ValueText = "123";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            ClientSize = new Size(1094, 621);
            Controls.Add(flpStats);
            Controls.Add(lblTitle);
            Name = "DashboardForm";
            Text = "DashboardForm";
            flpStats.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private FlowLayoutPanel flpStats;
        private UserControls.StatCardControl statTotalRoomsCard;
        private UserControls.StatCardControl statOccupiedRoomsCard;
        private UserControls.StatCardControl statAvailableRoomsCard;
        private UserControls.StatCardControl statRevenueMonthCard;
        private UserControls.StatCardControl statReservedRoomsCard;
        private UserControls.StatCardControl statOutOfServiceRoomsCard;
        private UserControls.StatCardControl statNumberOfCustomersCard;
        private UserControls.StatCardControl statRevenueYearCard;
    }
}