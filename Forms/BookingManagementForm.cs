using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementIt008.Forms
{
    public partial class BookingManagementForm : BaseForm
    {
        private readonly IBookingService _bookingService;
        private readonly IServiceProvider _serviceProvider;
        private List<BookingResponseDto> _allBookings = new();
        private int _currentPage = 1;
        private readonly int _pageSize = 20;
        private int _totalPages = 1;

        public BookingManagementForm(IBookingService bookingService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _bookingService = bookingService;
            _serviceProvider = serviceProvider;
            ConfigureDataGridView();
        }

        private async void BookingManagementForm_Load(object sender, EventArgs e)
        {
            await LoadBookings();
        }

        private void ConfigureDataGridView()
        {
            dgvBookings.AutoGenerateColumns = false;
            dgvBookings.Columns.Clear();

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRoomNumber",
                DataPropertyName = "RoomNumber",
                HeaderText = "Room Number",
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCheckIn",
                DataPropertyName = "CheckInDate",
                HeaderText = "Check In",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCheckOut",
                DataPropertyName = "CheckOutDate",
                HeaderText = "Check Out",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotalPrice",
                DataPropertyName = "TotalPrice",
                HeaderText = "Total Price",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBooker",
                DataPropertyName = "BookerEmail",
                HeaderText = "Booker",
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCreatedAt",
                DataPropertyName = "CreatedAt",
                HeaderText = "Created At",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });

            dgvBookings.SelectionChanged += DgvBookings_SelectionChanged;
        }

        private void DgvBookings_SelectionChanged(object? sender, EventArgs e)
        {
            bool hasSelection = dgvBookings.SelectedRows.Count > 0;
            btnEditBooking.Enabled = hasSelection;
            btnDeleteBooking.Enabled = hasSelection;
            btnPrintBooking.Enabled = hasSelection;
        }

        private async Task LoadBookings()
        {
            // Since API doesn't support filtering/pagination yet, we fetch all and do it in memory
            // In a real app with many records, this should be done on server side
            var result = await _bookingService.GetAllBookingsAsync(null!); // Assuming userId is not needed for admin or handled in service

            if (result.IsSuccess && result.Value != null)
            {
                _allBookings = result.Value.ToList();
                ApplyFiltersAndBind();
            }
            else
            {
                MessageBox.Show("Failed to load bookings: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFiltersAndBind()
        {
            var filtered = _allBookings.AsEnumerable();

            // Filter by Room Number
            if (!string.IsNullOrWhiteSpace(txtFilterRoomNumber.Text))
            {
                filtered = filtered.Where(b => b.Room.RoomNumber.Contains(txtFilterRoomNumber.Text.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            // Filter by Check In
            if (dtpFilterCheckIn.Checked)
            {
                filtered = filtered.Where(b => b.CheckInDate.Date >= dtpFilterCheckIn.Value.Date);
            }

            // Filter by Check Out
            if (dtpFilterCheckOut.Checked)
            {
                filtered = filtered.Where(b => b.CheckOutDate.Date <= dtpFilterCheckOut.Value.Date);
            }

            var filteredList = filtered.ToList();

            // Pagination
            _totalPages = (int)Math.Ceiling((decimal)filteredList.Count / _pageSize);
            if (_totalPages == 0) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = _totalPages;

            var pagedList = filteredList
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .Select(b => new
                {
                    b.Id,
                    RoomNumber = b.Room.RoomNumber,
                    b.CheckInDate,
                    b.CheckOutDate,
                    b.TotalPrice,
                    BookerEmail = b.User.Email,
                    b.CreatedAt
                })
                .ToList();

            dgvBookings.DataSource = pagedList;
            UpdatePaginationControls();
        }

        private void UpdatePaginationControls()
        {
            btnPrevious.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;
            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            ApplyFiltersAndBind();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtFilterRoomNumber.Clear();
            dtpFilterCheckIn.Checked = false;
            dtpFilterCheckOut.Checked = false;
            _currentPage = 1;
            ApplyFiltersAndBind();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                ApplyFiltersAndBind();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                ApplyFiltersAndBind();
            }
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<BookingDetailForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadBookings(); // Reload after add
            }
        }

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                var id = (Guid)dgvBookings.SelectedRows[0].Cells["colId"].Value;
                var form = _serviceProvider.GetRequiredService<BookingDetailForm>();
                form.BookingId = id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBookings(); // Reload after edit
                }
            }
        }

        private async void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var id = (Guid)dgvBookings.SelectedRows[0].Cells["colId"].Value;
                    var result = await _bookingService.RemoveBookingAsync(id.ToString(), null!); // userId?

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Booking deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadBookings();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete booking: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPrintBooking_Click(object sender, EventArgs e)
        {
             MessageBox.Show("Print functionality is not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
