namespace HotelManagementIt008.Dtos.Responses
{
    public class ReportSummaryDto
    {
        public decimal TotalRevenue { get; set; }
        public int TotalBookings { get; set; }
        public decimal OccupancyRate { get; set; }
        public int TotalCustomers { get; set; }
    }

    public class RevenueStatsDto
    {
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
    }

    public class RoomPopularityDto
    {
        public string RoomType { get; set; } = string.Empty;
        public int BookingCount { get; set; }
    }
}
