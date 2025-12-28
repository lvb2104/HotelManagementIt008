using Gridify;

using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementIt008.Forms
{
    public partial class BookingManagementForm : BaseForm
    {
        private readonly IBookingService _bookingService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICurrentUserService _currentUserService;
        private int _currentPage = 1;
        private readonly int _pageSize = 20;
        private int _totalPages = 1;
        private int _totalCount = 0;

        public BookingManagementForm(IBookingService bookingService, IServiceProvider serviceProvider, ICurrentUserService currentUserService)
        {
            InitializeComponent();
            _bookingService = bookingService;
            _serviceProvider = serviceProvider;
            _currentUserService = currentUserService;
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
                DataPropertyName = "BookerUsername",
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
            dgvBookings.CellDoubleClick += DgvBookings_CellDoubleClickAsync;
        }

        private void DgvBookings_SelectionChanged(object? sender, EventArgs e)
        {
            bool hasSelection = dgvBookings.SelectedRows.Count > 0;
            btnEditBooking.Enabled = hasSelection;
            btnDeleteBooking.Enabled = hasSelection;
            btnPrintBooking.Enabled = hasSelection;
        }

        private void DgvBookings_CellDoubleClickAsync(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditBooking_ClickAsync(sender, e);
            }
        }

        private async Task LoadBookings()
        {
            try
            {
                var gridifyQuery = new GridifyQuery
                {
                    Page = _currentPage,
                    PageSize = _pageSize,
                    OrderBy = "createdAt desc" // Default sorting
                };

                var result = await _bookingService.GetBookingSummariesAsync(_currentUserService.UserId.ToString(), gridifyQuery);

                if (result.IsSuccess && result.Value != null)
                {
                    _totalCount = result.Value.Count;
                    _totalPages = (int)Math.Ceiling((decimal)_totalCount / _pageSize);
                    if (_totalPages == 0) _totalPages = 1;

                    dgvBookings.DataSource = result.Value.Data;
                    UpdatePaginationControls();
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

        private async Task ApplyFiltersAndBind()
        {
            try
            {
                // Build filter string for Gridify
                var filters = new List<string>();

                if (!string.IsNullOrWhiteSpace(txtFilterRoomNumber.Text))
                {
                    filters.Add($"roomNumber=*{txtFilterRoomNumber.Text.Trim()}");
                }

                if (dtpFilterCheckIn.Checked)
                {
                    var checkInDate = DateTime.SpecifyKind(dtpFilterCheckIn.Value.Date, DateTimeKind.Utc);
                    filters.Add($"checkInDate>={checkInDate:yyyy-MM-ddTHH:mm:ss}");
                }

                if (dtpFilterCheckOut.Checked)
                {
                    var checkOutDate = DateTime.SpecifyKind(dtpFilterCheckOut.Value.Date.AddDays(1).AddSeconds(-1), DateTimeKind.Utc); // End of day
                    filters.Add($"checkOutDate<={checkOutDate:yyyy-MM-ddTHH:mm:ss}");
                }

                var filterString = filters.Any() ? string.Join(",", filters) : string.Empty;

                var gridifyQuery = new GridifyQuery
                {
                    Page = _currentPage,
                    PageSize = _pageSize,
                    Filter = filterString,
                    OrderBy = "createdAt desc"
                };

                var result = await _bookingService.GetBookingSummariesAsync(_currentUserService.UserId.ToString(), gridifyQuery);

                if (result.IsSuccess && result.Value != null)
                {
                    _totalCount = result.Value.Count;
                    _totalPages = (int)Math.Ceiling((decimal)_totalCount / _pageSize);
                    if (_totalPages == 0) _totalPages = 1;

                    dgvBookings.DataSource = result.Value.Data;
                    UpdatePaginationControls();
                }
                else
                {
                    // Debug: Show error message
                    System.Diagnostics.Debug.WriteLine($"Filter failed: {result.ErrorMessage}");
                    MessageBox.Show($"Filter error: {result.ErrorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying filters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            await ApplyFiltersAndBind();
        }

        private async void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtFilterRoomNumber.Clear();
            dtpFilterCheckIn.Checked = false;
            dtpFilterCheckOut.Checked = false;
            _currentPage = 1;
            await ApplyFiltersAndBind();
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await ApplyFiltersAndBind();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await ApplyFiltersAndBind();
            }
        }

        private async void btnAddBooking_ClickAsync(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<BookingDetailForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadBookings(); // Reload after add
            }
        }

        private async void btnEditBooking_ClickAsync(object? sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                try
                {
                    var idCell = dgvBookings.SelectedRows[0].Cells["colId"];
                    if (idCell.Value is Guid id)
                    {
                        var form = _serviceProvider.GetRequiredService<BookingDetailForm>();
                        form.BookingId = id;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            await LoadBookings(); // Reload after edit
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
                        var idCell = dgvBookings.SelectedRows[0].Cells["colId"];
                        if (idCell.Value is Guid id)
                        {
                            var result = await _bookingService.RemoveBookingAsync(id.ToString(), _currentUserService.UserId.ToString());

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
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnPrintBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                try
                {
                    var idCell = dgvBookings.SelectedRows[0].Cells["colId"];
                    if (idCell.Value is Guid id)
                    {
                        // Fetch full booking details including participants
                        var result = await _bookingService.GetBookingByIdAsync(id.ToString(), _currentUserService.UserId.ToString());

                        if (result.IsSuccess && result.Value != null)
                        {
                            PrintBookingDetails(result.Value);
                        }
                        else
                        {
                            MessageBox.Show("Failed to retrieve booking details for printing: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error printing booking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                using var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                    FilterIndex = 1,
                    FileName = $"Bookings_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Export Bookings to CSV",
                    DefaultExt = "csv"
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                var csv = new System.Text.StringBuilder();

                // Add headers
                foreach (DataGridViewColumn col in dgvBookings.Columns)
                {
                    if (col.Visible)
                        csv.Append(col.HeaderText + ",");
                }
                csv.AppendLine();

                // Add rows
                foreach (DataGridViewRow row in dgvBookings.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (dgvBookings.Columns[cell.ColumnIndex].Visible)
                        {
                            var value = cell.Value?.ToString()?.Replace(",", ";") ?? string.Empty;
                            csv.Append(value + ",");
                        }
                    }
                    csv.AppendLine();
                }

                File.WriteAllText(saveFileDialog.FileName, csv.ToString());
                MessageBox.Show($"Successfully exported to:\n{saveFileDialog.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintBookingDetails(BookingResponseDto booking)
        {
            var printDoc = new System.Drawing.Printing.PrintDocument();
            printDoc.PrintPage += (sender, e) => PrintPageHandler(sender, e, booking);

            var previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600
            };
            previewDialog.ShowDialog();
        }

        private void PrintPageHandler(object sender, System.Drawing.Printing.PrintPageEventArgs e, BookingResponseDto booking)
        {
            var g = e.Graphics;
            if (g == null) return;

            // Styles
            var titleFont = new Font("Arial", 24, FontStyle.Bold);
            var sectionFont = new Font("Arial", 18, FontStyle.Bold);
            var labelFont = new Font("Arial", 12, FontStyle.Bold);
            var valueFont = new Font("Arial", 12, FontStyle.Regular);
            var headerFont = new Font("Arial", 10, FontStyle.Bold);
            var cellFont = new Font("Arial", 10, FontStyle.Regular);

            var brush = Brushes.Black;
            float yPos = 50;
            float leftMargin = 50;
            float rightMargin = e.PageBounds.Width - 50;
            float contentWidth = rightMargin - leftMargin;

            // Title
            var title = "Booking Details";
            var titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, brush, (e.PageBounds.Width - titleSize.Width) / 2, yPos);
            yPos += 50;

            // Section: Booking Information
            g.DrawString("Booking Information", sectionFont, brush, leftMargin, yPos);
            yPos += 30;

            // Summary Rows
            DrawSummaryRow(g, "Room Number:", booking.RoomNumber, leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Check In Date:", booking.CheckInDate.ToString("yyyy-MM-dd"), leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Check Out Date:", booking.CheckOutDate.ToString("yyyy-MM-dd"), leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Booker Username:", booking.User?.Username ?? "N/A", leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Created At:", booking.CreatedAt.ToString("yyyy-MM-dd"), leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Updated At:", booking.UpdatedAt.ToString("yyyy-MM-dd"), leftMargin, ref yPos, labelFont, valueFont);

            yPos += 20;

            // Section: Participants
            g.DrawString("Participants", sectionFont, brush, leftMargin, yPos);
            yPos += 30;

            // Table Header
            float[] colWidths = { 150, 150, 200, 100 }; // Email, Name, Address, Identity
            string[] headers = { "Email", "Full Name", "Address", "Identity Number" };
            float currentX = leftMargin;

            // Draw Header Background
            var headerRect = new RectangleF(leftMargin, yPos, contentWidth, 25);
            g.FillRectangle(Brushes.LightGray, headerRect);

            for (int i = 0; i < headers.Length; i++)
            {
                g.DrawString(headers[i], headerFont, brush, currentX + 5, yPos + 5);
                currentX += colWidths[i];
            }
            yPos += 25;

            // Table Rows
            if (booking.Participants != null)
            {
                foreach (var p in booking.Participants)
                {
                    currentX = leftMargin;

                    // Calculate max height for this row
                    string[] cellValues = {
                        p.Email,
                        p.Profile?.FullName ?? "",
                        p.Profile?.Address ?? "",
                        p.Profile?.IdentityNumber ?? ""
                    };

                    float maxRowHeight = 25; // Minimum height
                    for (int i = 0; i < cellValues.Length; i++)
                    {
                        var size = g.MeasureString(cellValues[i], cellFont, (int)colWidths[i]);
                        if (size.Height > maxRowHeight)
                        {
                            maxRowHeight = size.Height;
                        }
                    }
                    maxRowHeight += 10; // Add some padding

                    // Draw Cells
                    for (int i = 0; i < cellValues.Length; i++)
                    {
                        var rect = new RectangleF(currentX + 5, yPos + 5, colWidths[i], maxRowHeight - 5);
                        g.DrawString(cellValues[i], cellFont, brush, rect);
                        currentX += colWidths[i];
                    }

                    // Draw bottom border
                    g.DrawLine(Pens.Black, leftMargin, yPos + maxRowHeight, leftMargin + contentWidth, yPos + maxRowHeight);

                    yPos += maxRowHeight;
                }
            }
        }

        private void DrawSummaryRow(Graphics g, string label, string value, float x, ref float y, Font labelFont, Font valueFont)
        {
            g.DrawString(label, labelFont, Brushes.Black, x, y);
            g.DrawString(value, valueFont, Brushes.Black, x + 150, y);
            y += 20;
        }
    }
}
