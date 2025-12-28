namespace HotelManagementIt008.Forms
{
    partial class ReportsForm
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
            pnlTop = new Panel();
            lblTitle = new Label();
            pnlFilters = new Panel();
            grpFilters = new GroupBox();
            btnGenerate = new Button();
            lblTo = new Label();
            dtpEnd = new DateTimePicker();
            lblFrom = new Label();
            dtpStart = new DateTimePicker();
            pnlActions = new Panel();
            btnExport = new Button();
            pnlContent = new Panel();
            tlpCharts = new TableLayoutPanel();
            chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartRoomTypes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            flpStats = new FlowLayoutPanel();
            cardRevenue = new HotelManagementIt008.UserControls.StatCardControl();
            cardBookings = new HotelManagementIt008.UserControls.StatCardControl();
            cardOccupancy = new HotelManagementIt008.UserControls.StatCardControl();
            cardCustomers = new HotelManagementIt008.UserControls.StatCardControl();
            pnlTop.SuspendLayout();
            pnlFilters.SuspendLayout();
            grpFilters.SuspendLayout();
            pnlActions.SuspendLayout();
            pnlContent.SuspendLayout();
            tlpCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartRoomTypes).BeginInit();
            flpStats.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1116, 60);
            pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(63, 81, 181);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reports & Analytics";
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.FromArgb(240, 244, 248);
            pnlFilters.Controls.Add(grpFilters);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 60);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(10);
            pnlFilters.Size = new Size(1116, 100);
            pnlFilters.TabIndex = 1;
            // 
            // grpFilters
            // 
            grpFilters.Controls.Add(btnGenerate);
            grpFilters.Controls.Add(lblTo);
            grpFilters.Controls.Add(dtpEnd);
            grpFilters.Controls.Add(lblFrom);
            grpFilters.Controls.Add(dtpStart);
            grpFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFilters.Font = new Font("Segoe UI", 10F);
            grpFilters.Location = new Point(10, 10);
            grpFilters.Name = "grpFilters";
            grpFilters.Size = new Size(1090, 80);
            grpFilters.TabIndex = 0;
            grpFilters.TabStop = false;
            grpFilters.Text = "Date Range";
            // 
            // btnGenerate
            // 
            btnGenerate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGenerate.BackColor = Color.FromArgb(33, 150, 243);
            btnGenerate.Cursor = Cursors.Hand;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(947, 30);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(120, 35);
            btnGenerate.TabIndex = 4;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(210, 38);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(26, 19);
            lblTo.TabIndex = 3;
            lblTo.Text = "To:";
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(240, 35);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(120, 25);
            dtpEnd.TabIndex = 2;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(20, 38);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(44, 19);
            lblFrom.TabIndex = 1;
            lblFrom.Text = "From:";
            // 
            // dtpStart
            // 
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(70, 35);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(120, 25);
            dtpStart.TabIndex = 0;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.White;
            pnlActions.Controls.Add(btnExport);
            pnlActions.Dock = DockStyle.Top;
            pnlActions.Location = new Point(0, 160);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10);
            pnlActions.Size = new Size(1116, 60);
            pnlActions.TabIndex = 2;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(63, 81, 181);
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(20, 12);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(161, 36);
            btnExport.TabIndex = 0;
            btnExport.Text = "📊 Export CSV";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(tlpCharts);
            pnlContent.Controls.Add(flpStats);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 220);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1116, 501);
            pnlContent.TabIndex = 3;
            // 
            // tlpCharts
            // 
            tlpCharts.ColumnCount = 2;
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpCharts.Controls.Add(chartRevenue, 0, 0);
            tlpCharts.Controls.Add(chartRoomTypes, 1, 0);
            tlpCharts.Dock = DockStyle.Fill;
            tlpCharts.Location = new Point(0, 160);
            tlpCharts.Name = "tlpCharts";
            tlpCharts.Padding = new Padding(10);
            tlpCharts.RowCount = 1;
            tlpCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCharts.Size = new Size(1116, 341);
            tlpCharts.TabIndex = 1;
            // 
            // chartRevenue
            // 
            var chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartArea1.Name = "ChartArea1";
            chartRevenue.ChartAreas.Add(chartArea1);
            
            var legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            legend1.Name = "Legend1";
            chartRevenue.Legends.Add(legend1);
            
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Legend = "Legend1";
            series1.Name = "Revenue";
            chartRevenue.Series.Add(series1);
            
            chartRevenue.Dock = DockStyle.Fill;
            chartRevenue.Location = new Point(13, 13);
            chartRevenue.Name = "chartRevenue";
            chartRevenue.Size = new Size(651, 315);
            chartRevenue.TabIndex = 0;
            
            var title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            title1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Revenue Trends";
            chartRevenue.Titles.Add(title1);
            // 
            // chartRoomTypes
            // 
            var chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartArea2.Name = "ChartArea2";
            chartRoomTypes.ChartAreas.Add(chartArea2);
            
            var legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            legend2.Name = "Legend1";
            chartRoomTypes.Legends.Add(legend2);
            
            var series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "RoomTypes";
            chartRoomTypes.Series.Add(series2);
            
            chartRoomTypes.Dock = DockStyle.Fill;
            chartRoomTypes.Location = new Point(670, 13);
            chartRoomTypes.Name = "chartRoomTypes";
            chartRoomTypes.Size = new Size(433, 315);
            chartRoomTypes.TabIndex = 1;
            
            var title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            title2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "Room Popularity";
            chartRoomTypes.Titles.Add(title2);
            // 
            // flpStats
            // 
            flpStats.AutoSize = true;
            flpStats.Controls.Add(cardRevenue);
            flpStats.Controls.Add(cardBookings);
            flpStats.Controls.Add(cardOccupancy);
            flpStats.Controls.Add(cardCustomers);
            flpStats.Dock = DockStyle.Top;
            flpStats.Location = new Point(0, 0);
            flpStats.Name = "flpStats";
            flpStats.Padding = new Padding(10);
            flpStats.Size = new Size(1116, 160);
            flpStats.TabIndex = 0;
            // 
            // cardRevenue
            // 
            cardRevenue.AccentColor = Color.FromArgb(16, 185, 129);
            cardRevenue.BackColor = Color.White;
            cardRevenue.Location = new Point(20, 20);
            cardRevenue.Margin = new Padding(10);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Padding = new Padding(20);
            cardRevenue.Size = new Size(250, 120);
            cardRevenue.TabIndex = 0;
            cardRevenue.TitleText = "Total Revenue";
            cardRevenue.ValueText = "$0.00";
            // 
            // cardBookings
            // 
            cardBookings.AccentColor = Color.Blue;
            cardBookings.BackColor = Color.White;
            cardBookings.Location = new Point(290, 20);
            cardBookings.Margin = new Padding(10);
            cardBookings.Name = "cardBookings";
            cardBookings.Padding = new Padding(20);
            cardBookings.Size = new Size(250, 120);
            cardBookings.TabIndex = 1;
            cardBookings.TitleText = "Total Bookings";
            cardBookings.ValueText = "0";
            // 
            // cardOccupancy
            // 
            cardOccupancy.AccentColor = Color.Orange;
            cardOccupancy.BackColor = Color.White;
            cardOccupancy.Location = new Point(560, 20);
            cardOccupancy.Margin = new Padding(10);
            cardOccupancy.Name = "cardOccupancy";
            cardOccupancy.Padding = new Padding(20);
            cardOccupancy.Size = new Size(250, 120);
            cardOccupancy.TabIndex = 2;
            cardOccupancy.TitleText = "Avg. Occupancy";
            cardOccupancy.ValueText = "0%";
            // 
            // cardCustomers
            // 
            cardCustomers.AccentColor = Color.Purple;
            cardCustomers.BackColor = Color.White;
            cardCustomers.Location = new Point(830, 20);
            cardCustomers.Margin = new Padding(10);
            cardCustomers.Name = "cardCustomers";
            cardCustomers.Padding = new Padding(20);
            cardCustomers.Size = new Size(250, 120);
            cardCustomers.TabIndex = 3;
            cardCustomers.TitleText = "New Customers";
            cardCustomers.ValueText = "0";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            ClientSize = new Size(1116, 721);
            Controls.Add(pnlContent);
            Controls.Add(pnlActions);
            Controls.Add(pnlFilters);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            Text = "Reports";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlFilters.ResumeLayout(false);
            grpFilters.ResumeLayout(false);
            grpFilters.PerformLayout();
            pnlActions.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            tlpCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartRoomTypes).EndInit();
            flpStats.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.FlowLayoutPanel flpStats;
        private HotelManagementIt008.UserControls.StatCardControl cardRevenue;
        private HotelManagementIt008.UserControls.StatCardControl cardBookings;
        private HotelManagementIt008.UserControls.StatCardControl cardOccupancy;
        private HotelManagementIt008.UserControls.StatCardControl cardCustomers;
        private System.Windows.Forms.TableLayoutPanel tlpCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRoomTypes;
    }
}