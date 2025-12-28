using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace HotelManagementIt008.Forms
{
    public partial class ReportsForm : BaseForm
    {
        private readonly IReportService _reportService;

        public ReportsForm(IReportService reportService)
        {
            InitializeComponent();
            _reportService = reportService;

            // Set default date range (Current Month)
            var now = DateTime.Now;
            dtpStart.Value = new DateTime(now.Year, now.Month, 1);
            dtpEnd.Value = now;

            // Wire up events
            btnGenerate.Click += async (s, e) => await LoadDataAsync();
            btnExport.Click += async (s, e) => await ExportToCsvAsync();
            
            // Only load data on first show, not on every Load event
            this.VisibleChanged += async (s, e) =>
            {
                if (this.Visible && !_isDataLoaded)
                {
                    _isDataLoaded = true;
                    await LoadDataAsync();
                }
            };
        }

        private bool _isDataLoaded = false;

        private async Task LoadDataAsync()
        {
            try
            {
                // Null check for required controls
                if (cardRevenue == null || cardBookings == null || cardCustomers == null || cardOccupancy == null)
                {
                    // Controls not initialized yet, skip
                    return;
                }

                // Convert to UTC for PostgreSQL compatibility
                var start = DateTime.SpecifyKind(dtpStart.Value.Date, DateTimeKind.Utc);
                var end = DateTime.SpecifyKind(dtpEnd.Value.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc);

                // 1. Load Summary Stats
                var summaryResult = await _reportService.GetSummaryStatsAsync(start, end);
                if (summaryResult.IsSuccess && summaryResult.Value != null)
                {
                    var summary = summaryResult.Value;
                    cardRevenue.ValueText = summary.TotalRevenue.ToString("C0");
                    cardBookings.ValueText = summary.TotalBookings.ToString("N0");
                    cardCustomers.ValueText = summary.TotalCustomers.ToString("N0");
                    cardOccupancy.ValueText = $"{summary.OccupancyRate:F1}%";
                }
                else
                {
                    ShowError("Failed to load summary stats: " + summaryResult.ErrorMessage);
                }

                // 2. Load Revenue Chart
                var revenueResult = await _reportService.GetRevenueStatsAsync(start, end);
                if (revenueResult.IsSuccess && revenueResult.Value != null)
                {
                    UpdateRevenueChart(revenueResult.Value);
                }
                else
                {
                    ShowError("Failed to load revenue chart: " + revenueResult.ErrorMessage);
                }

                // 3. Load Room Type Popularity Chart
                var roomResult = await _reportService.GetRoomTypePopularityAsync(start, end);
                if (roomResult.IsSuccess && roomResult.Value != null)
                {
                    UpdateRoomTypeChart(roomResult.Value);
                }
                else
                {
                    ShowError("Failed to load room popularity chart: " + roomResult.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Unexpected error: {ex.Message}");
            }
        }

        private void UpdateRevenueChart(List<RevenueStatsDto> data)
        {
            // Defensive null checks
            if (chartRevenue == null)
            {
                ShowError("Revenue chart control is null.");
                return;
            }

            if (chartRevenue.Series.Count == 0 || chartRevenue.Series.FindByName("Revenue") == null)
            {
                ShowError("Revenue chart series is not properly initialized.");
                return;
            }

            chartRevenue.Series["Revenue"].Points.Clear();

            if (data != null && data.Any())
            {
                // Ensure the chart shows the full range even if there are gaps
                var minDate = dtpStart.Value.Date;
                var maxDate = dtpEnd.Value.Date;
                var revenueMap = data.ToDictionary(x => x.Date.Date, x => x.Revenue);

                for (var date = minDate; date <= maxDate; date = date.AddDays(1))
                {
                    decimal val = revenueMap.ContainsKey(date) ? revenueMap[date] : 0;
                    chartRevenue.Series["Revenue"].Points.AddXY(date.ToString("dd/MM"), val);
                }
            }

            chartRevenue.ChartAreas[0].AxisX.Interval = 1; // Can assume daily for small ranges, might need dynamic logic for large ranges
            if ((dtpEnd.Value - dtpStart.Value).TotalDays > 14)
                chartRevenue.ChartAreas[0].AxisX.Interval = 0; // Automatic interval for large ranges

            chartRevenue.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
        }

        private void UpdateRoomTypeChart(List<RoomPopularityDto> data)
        {
            // Defensive null checks
            if (chartRoomTypes == null)
            {
                ShowError("Room types chart control is null.");
                return;
            }

            if (chartRoomTypes.Series.Count == 0 || chartRoomTypes.Series.FindByName("RoomTypes") == null)
            {
                ShowError("Room types chart series is not properly initialized.");
                return;
            }

            chartRoomTypes.Series["RoomTypes"].Points.Clear();

            if (data != null && data.Any())
            {
                foreach (var item in data)
                {
                    int index = chartRoomTypes.Series["RoomTypes"].Points.AddY(item.BookingCount);
                    DataPoint point = chartRoomTypes.Series["RoomTypes"].Points[index];
                    point.Label = $"{item.RoomType} ({item.BookingCount})";
                    point.LegendText = item.RoomType;
                }
            }
        }

        private async Task ExportToCsvAsync()
        {
            try
            {
                using var sfd = new SaveFileDialog();
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var sb = new StringBuilder();
                    // Convert to UTC for PostgreSQL compatibility
                    var start = DateTime.SpecifyKind(dtpStart.Value.Date, DateTimeKind.Utc);
                    var end = DateTime.SpecifyKind(dtpEnd.Value.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc);

                    // Fetch data again to ensure export matches current filters
                    var summaryResult = await _reportService.GetSummaryStatsAsync(start, end);
                    var revenueResult = await _reportService.GetRevenueStatsAsync(start, end);
                    var roomResult = await _reportService.GetRoomTypePopularityAsync(start, end);

                    if (!summaryResult.IsSuccess || !revenueResult.IsSuccess || !roomResult.IsSuccess)
                    {
                        ShowError("Failed to fetch data for export.");
                        return;
                    }

                    // Header Info
                    sb.AppendLine($"Report Generated: {DateTime.Now}");
                    sb.AppendLine($"Range: {start:d} - {end:d}");
                    sb.AppendLine();

                    // Summary Section
                    sb.AppendLine("SUMMARY");
                    sb.AppendLine("Metric,Value");
                    sb.AppendLine($"Total Revenue,{summaryResult.Value?.TotalRevenue:C2}");
                    sb.AppendLine($"Total Bookings,{summaryResult.Value?.TotalBookings}");
                    sb.AppendLine($"Occupancy Rate,{summaryResult.Value?.OccupancyRate:F2}%");
                    sb.AppendLine($"New Customers,{summaryResult.Value?.TotalCustomers}");
                    sb.AppendLine();

                    // Revenue Details
                    sb.AppendLine("DAILY REVENUE");
                    sb.AppendLine("Date,Amount");
                    if (revenueResult.Value != null)
                    {
                        foreach (var item in revenueResult.Value)
                        {
                            sb.AppendLine($"{item.Date:d},{item.Revenue}");
                        }
                    }
                    sb.AppendLine();

                    // Room Type Details
                    sb.AppendLine("ROOM TYPE POPULARITY");
                    sb.AppendLine("Room Type,Bookings");
                    if (roomResult.Value != null)
                    {
                        foreach (var item in roomResult.Value)
                        {
                            sb.AppendLine($"{item.RoomType},{item.BookingCount}");
                        }
                    }

                    await File.WriteAllTextAsync(sfd.FileName, sb.ToString());
                    MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Failed to export: {ex.Message}");
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
