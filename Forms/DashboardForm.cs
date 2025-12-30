namespace HotelManagementIt008.Forms
{
    public partial class DashboardForm : BaseForm
    {
        private readonly IRoomService _roomService;
        private readonly IUserService _userService;
        private readonly IReportService _reportService;

        public DashboardForm(IRoomService roomService, IUserService userService, IReportService reportService)
        {
            _roomService = roomService;
            _userService = userService;
            _reportService = reportService;
            InitializeComponent();
            this.Load += async (s, e) => await LoadStatCards();
        }

        private async Task LoadStatCards()
        {
            var totalRooms = _roomService.CountRoomsByStatus().Value;
            var occupiedRooms = _roomService.CountRoomsByStatus(RoomStatus.Occupied).Value;
            var availableRooms = _roomService.CountRoomsByStatus(RoomStatus.Available).Value;
            var reservedRooms = _roomService.CountRoomsByStatus(RoomStatus.Reserved).Value;
            var outOfServiceRooms = _roomService.CountRoomsByStatus(RoomStatus.OutOfService).Value;
            //var numberOfCustomers = _userService.CountByRoleType(RoleType.Customer).Value;
            var customerResult = await _userService.CountByRoleTypeAsync(RoleType.Customer);
            int numberOfCustomers = customerResult.IsSuccess ? customerResult.Value : 0;

            // Calculate monthly revenue (current month)
            var startOfMonth = DateTime.SpecifyKind(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTimeKind.Utc);
            var endOfToday = DateTime.SpecifyKind(DateTime.Now.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc);
            var monthlyResult = await _reportService.GetSummaryStatsAsync(startOfMonth, endOfToday);
            decimal monthlyRevenue = monthlyResult.IsSuccess && monthlyResult.Value is not null ? monthlyResult.Value.TotalRevenue : 0;

            // Calculate yearly revenue (current year)
            var startOfYear = DateTime.SpecifyKind(new DateTime(DateTime.Now.Year, 1, 1), DateTimeKind.Utc);
            var yearlyResult = await _reportService.GetSummaryStatsAsync(startOfYear, endOfToday);
            decimal yearlyRevenue = yearlyResult.IsSuccess && yearlyResult.Value is not null ? yearlyResult.Value.TotalRevenue : 0;

            statTotalRoomsCard.ValueText = totalRooms.ToString();
            statOccupiedRoomsCard.ValueText = occupiedRooms.ToString();
            statAvailableRoomsCard.ValueText = availableRooms.ToString();
            statReservedRoomsCard.ValueText = reservedRooms.ToString();
            statOutOfServiceRoomsCard.ValueText = outOfServiceRooms.ToString();
            statNumberOfCustomersCard.ValueText = numberOfCustomers.ToString();
            statRevenueMonthCard.ValueText = monthlyRevenue.ToString("C0");
            statRevenueYearCard.ValueText = yearlyRevenue.ToString("C0");
        }
    }
}