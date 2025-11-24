using Gridify;

namespace HotelManagementIt008.Forms
{
    public partial class RoomManagementForm : Form
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomService _roomService;
        private readonly IGridifyMapper<Room> _mapper;
        private int _currentPage = 1;
        private readonly int _pageSize = 20;
        private int _totalPages = 1;

        public RoomManagementForm(IRoomTypeService roomTypeService, IRoomService roomService, IGridifyMapper<Room> mapper)
        {
            InitializeComponent();
            _roomTypeService = roomTypeService;
            _roomService = roomService;
            _mapper = mapper;
            ConfigureDataGridView();
        }

        private async void RoomManagementForm_Load(object sender, EventArgs e)
        {
            await InitializeFilters();
            await LoadRooms();
        }

        private void ConfigureDataGridView()
        {
            dgvRooms.AutoGenerateColumns = false;
            dgvRooms.Columns.Clear();

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRoomId",
                DataPropertyName = nameof(RoomResponseDto.Id),
                HeaderText = "ID",
                Visible = false
            });
            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRoomNumber",
                DataPropertyName = nameof(RoomResponseDto.RoomNumber),
                HeaderText = "Room Number",
            });
            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRoomType",
                DataPropertyName = nameof(RoomResponseDto.RoomTypeName),
                HeaderText = "Room Type",
            });
            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                DataPropertyName = nameof(RoomResponseDto.PricePerNight),
                HeaderText = "Price Per Night",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                DataPropertyName = nameof(RoomResponseDto.Status),
                HeaderText = "Status",
            });
            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNote",
                DataPropertyName = nameof(RoomResponseDto.Note),
                HeaderText = "Note",
            });

        }

        private async Task LoadRooms()
        {
            var filterString = BuildFilterString();
            var gridifyQuery = new GridifyQuery
            {
                Filter = filterString,
                Page = _currentPage,
                PageSize = _pageSize,
                OrderBy = "room"
            };

            var roomsResult = await _roomService.GetAllRoomsAsync(gridifyQuery);

            if (roomsResult.IsSuccess && roomsResult.Value is not null)
            {
                // Bind data to DataGridView
                dgvRooms.DataSource = roomsResult.Value.Data;

                // _totalPages calculation
                _totalPages = (int)Math.Ceiling((decimal)roomsResult.Value.Count / _pageSize);
                UpdatePaginationControls();
            }
            else
            {
                MessageBox.Show("Failed to load rooms: " + roomsResult.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task InitializeFilters()
        {
            // Room Type Filter
            cboFilterRoomType.Items.Clear();
            cboFilterRoomType.Items.Add("All");

            var roomTypeResult = await _roomTypeService.GetAllRoomTypesAsync();
            if (roomTypeResult.IsSuccess && roomTypeResult.Value != null)
            {
                foreach (var roomType in roomTypeResult.Value)
                {
                    cboFilterRoomType.Items.Add(roomType.Name);
                }

                // Price Range - Set min and max based on room types
                if (roomTypeResult.Value.Count != 0)
                {
                    var minPrice = (decimal)roomTypeResult.Value.Min(t => t.PricePerNight);
                    var maxPrice = (decimal)roomTypeResult.Value.Max(t => t.PricePerNight);

                    // Set NumericUpDown ranges
                    nudPriceFrom.Minimum = 0;
                    nudPriceFrom.Maximum = maxPrice;
                    nudPriceFrom.Value = 0; // Start from 0

                    nudPriceTo.Minimum = 0;
                    nudPriceTo.Maximum = maxPrice * 2; // Allow higher for surcharges
                    nudPriceTo.Value = maxPrice * 2; // Default to max
                }
                else
                {
                    // Default values if no room types exist
                    nudPriceFrom.Minimum = 0;
                    nudPriceFrom.Maximum = 10000000;
                    nudPriceFrom.Value = 0;

                    nudPriceTo.Minimum = 0;
                    nudPriceTo.Maximum = 10000000;
                    nudPriceTo.Value = 10000000;
                }

                // Add event handlers for validation
                nudPriceFrom.ValueChanged += ValidatePriceRange;
                nudPriceTo.ValueChanged += ValidatePriceRange;
            }
            cboFilterRoomType.SelectedIndex = 0;

            // Status Filter
            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.Add("All");
            foreach (var status in Enum.GetValues<RoomStatus>())
            {
                cboFilterStatus.Items.Add(status.ToString());
            }
            cboFilterStatus.SelectedIndex = 0;
        }

        private void ValidatePriceRange(object? sender, EventArgs e)
        {
            // Ensure "From" is not greater than "To"
            if (nudPriceFrom.Value > nudPriceTo.Value)
            {
                if (sender == nudPriceFrom)
                {
                    // User changed "From", adjust "To"
                    nudPriceTo.Value = nudPriceFrom.Value;
                }
                else
                {
                    // User changed "To", adjust "From"
                    nudPriceFrom.Value = nudPriceTo.Value;
                }
            }
        }

        private string BuildFilterString()
        {
            var parts = new List<string>();

            if (!string.IsNullOrWhiteSpace(txtFilterRoomNumber.Text))
                parts.Add($"room=*{txtFilterRoomNumber.Text.Trim()}");

            if (cboFilterRoomType.SelectedItem is string t && t != "All")
                parts.Add($"type={t}");

            if (cboFilterStatus.SelectedItem is string s && s != "All")
                parts.Add($"status={s}");

            if (nudPriceFrom.Value > 0)
                parts.Add($"price>={nudPriceFrom.Value}");

            if (nudPriceTo.Value > 0)
                parts.Add($"price<={nudPriceTo.Value}");

            return parts.Count > 0 ? string.Join(",", parts) : string.Empty;
        }

        private void UpdatePaginationControls()
        {
            btnPrevious.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;
            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadRooms();
        }

        private async void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtFilterRoomNumber.Clear();
            cboFilterRoomType.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
            nudPriceFrom.Value = 0;
            nudPriceTo.Value = 1000000;
            _currentPage = 1;
            await LoadRooms();
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadRooms();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadRooms();
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {

        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {

        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {

        }
    }
}
