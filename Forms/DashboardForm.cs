namespace HotelManagementIt008.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly IRoomService _roomService;
        private readonly IUserService _userService;

        public DashboardForm(IRoomService roomService, IUserService userService)
        {
            _roomService = roomService;
            _userService = userService;
            InitializeComponent();
            LoadStatCards();
        }

        private void LoadStatCards()
        {
            var totalRooms = _roomService.CountRoomsByStatus().Value;
            var occupiedRooms = _roomService.CountRoomsByStatus(RoomStatus.Occupied).Value;
            var availableRooms = _roomService.CountRoomsByStatus(RoomStatus.Available).Value;
            var reservedRooms = _roomService.CountRoomsByStatus(RoomStatus.Reserved).Value;
            var outOfServiceRooms = _roomService.CountRoomsByStatus(RoomStatus.OutOfService).Value;
            var numberOfCustomers = _userService.CountByRoleType(RoleType.Customer).Value;

            statTotalRoomsCard.ValueText = totalRooms.ToString();
            statOccupiedRoomsCard.ValueText = occupiedRooms.ToString();
            statAvailableRoomsCard.ValueText = availableRooms.ToString();
            statReservedRoomsCard.ValueText = reservedRooms.ToString();
            statOutOfServiceRoomsCard.ValueText = outOfServiceRooms.ToString();
            statNumberOfCustomersCard.ValueText = numberOfCustomers.ToString();
            statRevenueMonthCard.ValueText = "$456.789";
            statRevenueYearCard.ValueText = "$456.789";
        }
    }
}