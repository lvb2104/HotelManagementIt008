using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementIt008.Forms
{
    public partial class BookingManagementForm : BaseForm
    {
        private readonly IBookingService _bookingService;
        private readonly IServiceProvider _serviceProvider;
        private List<BookingSummaryDto> _allBookings = new();
        private int _currentPage = 1;
        private readonly int _pageSize = 20;
        private int _totalPages = 1;

        private readonly Guid _userId;

        public BookingManagementForm(IBookingService bookingService, IServiceProvider serviceProvider, Guid userId)
        {
            InitializeComponent();
            _bookingService = bookingService;
            _serviceProvider = serviceProvider;
            _userId = userId;
            ConfigureDataGridView();
        }

        private async void BookingManagementForm_Load(object sender, EventArgs e)
        {
            // Enable checkboxes for optional filtering
            dtpFilterCheckIn.ShowCheckBox = true;
            dtpFilterCheckOut.ShowCheckBox = true;

            // Initialize filters to unchecked so all data shows by default
            dtpFilterCheckIn.Checked = false;
            dtpFilterCheckOut.Checked = false;
            
            await LoadBookings();
        }

        private void ConfigureDataGridView()
        {
            dgvBookings.AutoGenerateColumns = false;
            dgvBookings.Columns.Clear();
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.MultiSelect = false;
            dgvBookings.ReadOnly = true;

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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCheckIn",
                DataPropertyName = "CheckInDate",
                HeaderText = "Check In",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                Width = 100
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCheckOut",
                DataPropertyName = "CheckOutDate",
                HeaderText = "Check Out",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                Width = 100
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotalPrice",
                DataPropertyName = "TotalPrice",
                HeaderText = "Total Price",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBooker",
                DataPropertyName = "BookerEmail",
                HeaderText = "Booker",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCreatedAt",
                DataPropertyName = "CreatedAt",
                HeaderText = "Created At",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                Width = 100
            });

            dgvBookings.SelectionChanged += DgvBookings_SelectionChanged;
            dgvBookings.CellDoubleClick += DgvBookings_CellDoubleClick;
        }

        private void DgvBookings_SelectionChanged(object? sender, EventArgs e)
        {
            bool hasSelection = dgvBookings.SelectedRows.Count > 0;
            btnEditBooking.Enabled = hasSelection;
            btnDeleteBooking.Enabled = hasSelection;
            btnPrintBooking.Enabled = hasSelection;
        }

        private void DgvBookings_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditBooking_Click(sender, e);
            }
        }

        private async Task LoadBookings()
        {
            try
            {
                var result = await _bookingService.GetBookingSummariesAsync(_userId.ToString());

                if (result.IsSuccess && result.Value != null)
                {
                    _allBookings = result.Value.ToList();
                    ApplyFiltersAndBind();
                }
                else
                {
                    MessageBox.Show("Failed to load bookings: " + (result.ErrorMessage ?? "Unknown error"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading bookings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFiltersAndBind()
        {
            var filtered = _allBookings.AsEnumerable();

            // Filter by Room Number
            if (!string.IsNullOrWhiteSpace(txtFilterRoomNumber.Text))
            {
                filtered = filtered.Where(b => b.RoomNumber.Contains(txtFilterRoomNumber.Text.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            // Filter by Check In (Exact Match)
            if (dtpFilterCheckIn.Checked)
            {
                filtered = filtered.Where(b => b.CheckInDate.Date == dtpFilterCheckIn.Value.Date);
            }

            // Filter by Check Out (Exact Match)
            if (dtpFilterCheckOut.Checked)
            {
                filtered = filtered.Where(b => b.CheckOutDate.Date == dtpFilterCheckOut.Value.Date);
            }

            var filteredList = filtered.OrderByDescending(b => b.CreatedAt).ToList();

            // Pagination
            _totalPages = (int)Math.Ceiling((decimal)filteredList.Count / _pageSize);
            if (_totalPages == 0) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = _totalPages;

            var pagedList = filteredList
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
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
            form.UserId = _userId;
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadBookings(); // Reload after add
            }
        }

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                try
                {
                    var idCell = dgvBookings.SelectedRows[0].Cells["colId"];
                    if (idCell.Value != null)
                    {
                        var id = (Guid)idCell.Value;
                        var form = _serviceProvider.GetRequiredService<BookingDetailForm>();
                        form.UserId = _userId;
                        form.BookingId = id;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadBookings(); // Reload after edit
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening booking details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        var id = (Guid)dgvBookings.SelectedRows[0].Cells["colId"].Value;
                        var result = await _bookingService.RemoveBookingAsync(id.ToString(), _userId.ToString());

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
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
