using System.Data;
using System.Drawing.Printing;

using Gridify;

namespace HotelManagementIt008.Forms
{
    public partial class InvoiceManagementForm : BaseForm
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ICurrentUserService _currentUserService;
        private int _currentPage = 1;
        private readonly int _pageSize = 20;
        private int _totalPages = 1;
        private int _totalCount = 0;

        public InvoiceManagementForm(IInvoiceService invoiceService, ICurrentUserService currentUserService)
        {
            InitializeComponent();
            _invoiceService = invoiceService;
            _currentUserService = currentUserService;
            ConfigureDataGridView();
        }

        private async void InvoiceManagementForm_Load(object sender, EventArgs e)
        {
            // Initialize Status Filter
            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.Add("All");
            foreach (var status in Enum.GetValues<InvoiceStatus>())
            {
                cboFilterStatus.Items.Add(status.ToString());
            }
            cboFilterStatus.SelectedIndex = 0;

            // Initialize Date Filter
            dtpFilterDate.ShowCheckBox = true;
            dtpFilterDate.Checked = false;

            await LoadInvoices();
        }

        private void ConfigureDataGridView()
        {
            dgvInvoices.AutoGenerateColumns = false;
            dgvInvoices.Columns.Clear();

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRoom",
                DataPropertyName = "RoomNumber", // Custom property or mapped
                HeaderText = "Room Number",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBooker",
                DataPropertyName = "BookerEmail", // Custom property or mapped
                HeaderText = "Booker Email",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBasePrice",
                DataPropertyName = "BasePrice",
                HeaderText = "Base Price",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAmount",
                DataPropertyName = "TotalPrice",
                HeaderText = "Total Price",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDays",
                DataPropertyName = "DaysStayed",
                HeaderText = "Days",
                Width = 60
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                DataPropertyName = "Status",
                HeaderText = "Status",
                Width = 100
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                DataPropertyName = "CreatedAt",
                HeaderText = "Created At",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                Width = 100
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUpdated",
                DataPropertyName = "UpdatedAt",
                HeaderText = "Updated At",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                Width = 100
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDeleted",
                DataPropertyName = "DeletedAt",
                HeaderText = "Deleted At",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                Width = 100
            });

            dgvInvoices.SelectionChanged += DgvInvoices_SelectionChanged;
        }

        private void DgvInvoices_SelectionChanged(object? sender, EventArgs e)
        {
            bool hasSelection = dgvInvoices.SelectedRows.Count > 0;
            btnPrintInvoice.Enabled = hasSelection;
            btnMarkAsPaid.Enabled = hasSelection;

            if (hasSelection)
            {
                var row = dgvInvoices.SelectedRows[0];
                if (row.DataBoundItem is InvoiceViewModel vm)
                {
                    btnMarkAsPaid.Enabled = vm.Status != InvoiceStatus.Paid && vm.Status != InvoiceStatus.Cancelled;
                }
            }
        }

        private async Task LoadInvoices()
        {
            try
            {
                var gridifyQuery = new GridifyQuery
                {
                    Page = _currentPage,
                    PageSize = _pageSize,
                    OrderBy = "createdAt desc"
                };

                var result = await _invoiceService.GetInvoicesAsync(_currentUserService.Role.ToString(), _currentUserService.UserId.ToString(), gridifyQuery);

                if (result.IsSuccess && result.Value != null)
                {
                    _totalCount = result.Value.Count;
                    _totalPages = (int)Math.Ceiling((decimal)_totalCount / _pageSize);
                    if (_totalPages == 0) _totalPages = 1;

                    // Map to ViewModel for Display
                    var viewModels = result.Value.Data.Select(i => new InvoiceViewModel
                    {
                        Id = i.Id,
                        RoomNumber = i.Booking?.Room?.RoomNumber ?? "N/A",
                        BookerEmail = i.Booking?.User?.Email ?? "Admin",
                        BasePrice = i.BasePrice,
                        TotalPrice = i.TotalPrice,
                        DaysStayed = i.DaysStayed,
                        Status = i.Status,
                        CreatedAt = i.CreatedAt,
                        UpdatedAt = i.UpdatedAt,
                        DeletedAt = i.DeletedAt,
                        OriginalDto = i
                    }).ToList();

                    dgvInvoices.DataSource = viewModels;
                    UpdatePaginationControls();
                }
                else
                {
                    MessageBox.Show("Failed to load invoices: " + (result.ErrorMessage ?? "Unknown error"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoices: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ApplyFiltersAndBind()
        {
            try
            {
                // Build filter string for Gridify
                var filters = new List<string>();

                // Status Filter
                if (cboFilterStatus.SelectedItem is string statusStr && statusStr != "All")
                {
                    filters.Add($"status={statusStr}");
                }

                // Date Filter
                if (dtpFilterDate.Checked)
                {
                    var filterDate = DateTime.SpecifyKind(dtpFilterDate.Value.Date, DateTimeKind.Utc);
                    filters.Add($"createdAt>={filterDate:yyyy-MM-ddTHH:mm:ss}");
                }

                var filterString = filters.Any() ? string.Join(",", filters) : string.Empty;

                var gridifyQuery = new GridifyQuery
                {
                    Page = _currentPage,
                    PageSize = _pageSize,
                    Filter = filterString,
                    OrderBy = "createdAt desc"
                };

                var result = await _invoiceService.GetInvoicesAsync(_currentUserService.Role.ToString(), _currentUserService.UserId.ToString(), gridifyQuery);

                if (result.IsSuccess && result.Value != null)
                {
                    _totalCount = result.Value.Count;
                    _totalPages = (int)Math.Ceiling((decimal)_totalCount / _pageSize);
                    if (_totalPages == 0) _totalPages = 1;

                    // Map to ViewModel for Display
                    var viewModels = result.Value.Data.Select(i => new InvoiceViewModel
                    {
                        Id = i.Id,
                        RoomNumber = i.Booking?.Room?.RoomNumber ?? "N/A",
                        BookerEmail = i.Booking?.User?.Email ?? "Admin",
                        BasePrice = i.BasePrice,
                        TotalPrice = i.TotalPrice,
                        DaysStayed = i.DaysStayed,
                        Status = i.Status,
                        CreatedAt = i.CreatedAt,
                        UpdatedAt = i.UpdatedAt,
                        DeletedAt = i.DeletedAt,
                        OriginalDto = i
                    }).ToList();

                    dgvInvoices.DataSource = viewModels;
                    UpdatePaginationControls();
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
            cboFilterStatus.SelectedIndex = 0;
            dtpFilterDate.Checked = false;
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

        private async void btnMarkAsPaid_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count > 0)
            {
                var row = dgvInvoices.SelectedRows[0];
                if (row.DataBoundItem is InvoiceViewModel vm)
                {
                    if (vm.Status == InvoiceStatus.Paid) return;

                    if (MessageBox.Show("Mark this invoice as PAID?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var result = await _invoiceService.UpdateInvoiceStatusAsync(vm.Id.ToString(), InvoiceStatus.Paid);
                        if (result.IsSuccess)
                        {
                            MessageBox.Show("Invoice marked as paid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadInvoices();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update status: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count > 0)
            {
                var row = dgvInvoices.SelectedRows[0];
                if (row.DataBoundItem is InvoiceViewModel vm)
                {
                    PrintInvoiceDetails(vm.OriginalDto);
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
                    FileName = $"Invoices_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Export Invoices to CSV",
                    DefaultExt = "csv"
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                var csv = new System.Text.StringBuilder();

                // Add headers
                foreach (DataGridViewColumn col in dgvInvoices.Columns)
                {
                    if (col.Visible)
                        csv.Append(col.HeaderText + ",");
                }
                csv.AppendLine();

                // Add rows
                foreach (DataGridViewRow row in dgvInvoices.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (dgvInvoices.Columns[cell.ColumnIndex].Visible)
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

        private void PrintInvoiceDetails(InvoiceResponseDto invoice)
        {
            var printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) => PrintPageHandler(sender, e, invoice);

            var previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600
            };
            previewDialog.ShowDialog();
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e, InvoiceResponseDto invoice)
        {
            var g = e.Graphics;
            if (g == null) return;

            // Styles
            var hotelNameFont = new Font("Arial", 28, FontStyle.Bold);
            var hotelInfoFont = new Font("Arial", 10, FontStyle.Regular);
            var titleFont = new Font("Arial", 24, FontStyle.Bold);
            var sectionFont = new Font("Arial", 16, FontStyle.Bold);
            var labelFont = new Font("Arial", 11, FontStyle.Bold);
            var valueFont = new Font("Arial", 11, FontStyle.Regular);
            var totalFont = new Font("Arial", 16, FontStyle.Bold);

            var brush = Brushes.Black;
            var grayBrush = Brushes.Gray;
            float yPos = 40;
            float leftMargin = 60;
            float rightMargin = e.PageBounds.Width - 60;

            // Hotel Header Section
            g.DrawString("GRAND HOTEL", hotelNameFont, brush, leftMargin, yPos);
            yPos += 40;
            g.DrawString("123 Main Street, City, Country", hotelInfoFont, grayBrush, leftMargin, yPos);
            yPos += 18;
            g.DrawString("Tel: +84 123 456 789 | Email: info@grandhotel.com", hotelInfoFont, grayBrush, leftMargin, yPos);
            yPos += 30;

            // Title
            var title = "INVOICE";
            var titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, brush, (e.PageBounds.Width - titleSize.Width) / 2, yPos);
            yPos += 50;

            // Invoice Info (Left) and Date (Right)
            float columnWidth = (rightMargin - leftMargin) / 2;
            
            g.DrawString("Invoice Details", sectionFont, brush, leftMargin, yPos);
            yPos += 35;

            DrawSummaryRow(g, "Invoice No:", $"INV-{invoice.Id.ToString().Substring(0, 8).ToUpper()}", leftMargin, ref yPos, labelFont, valueFont);
            var tempY = yPos;
            yPos -= 25; // Reset to previous line for right column
            DrawSummaryRow(g, "Date Issued:", invoice.CreatedAt.ToString("MMM dd, yyyy"), leftMargin + columnWidth, ref yPos, labelFont, valueFont);
            yPos = Math.Max(yPos, tempY); // Use the larger yPos
            DrawSummaryRow(g, "Status:", GetStatusWithColor(g, invoice.Status, leftMargin + 150, yPos - 25), leftMargin, ref yPos, labelFont, valueFont);
            yPos -= 25; // Compensate for the color status

            yPos += 15;
            g.DrawLine(Pens.LightGray, leftMargin, yPos, rightMargin, yPos);
            yPos += 25;

            // Booking & Customer Information
            g.DrawString("Booking Information", sectionFont, brush, leftMargin, yPos);
            yPos += 35;

            if (invoice.Booking != null)
            {
                DrawSummaryRow(g, "Room Number:", invoice.Booking.Room?.RoomNumber ?? "N/A", leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Room Type:", invoice.Booking.Room?.RoomType?.Name ?? "N/A", leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Price/Night:", (invoice.Booking.Room?.RoomType?.PricePerNight ?? 0).ToString("C2"), leftMargin, ref yPos, labelFont, valueFont);
                yPos += 10;
                DrawSummaryRow(g, "Check-In:", invoice.Booking.CheckInDate.ToString("MMM dd, yyyy"), leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Check-Out:", invoice.Booking.CheckOutDate.ToString("MMM dd, yyyy"), leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Nights Stayed:", invoice.DaysStayed.ToString(), leftMargin, ref yPos, labelFont, valueFont);
                yPos += 10;
                DrawSummaryRow(g, "Booked By:", invoice.Booking.User?.Username ?? "N/A", leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Contact:", invoice.Booking.User?.Email ?? "N/A", leftMargin, ref yPos, labelFont, valueFont);
            }

            yPos += 15;
            g.DrawLine(Pens.LightGray, leftMargin, yPos, rightMargin, yPos);
            yPos += 25;

            // Payment Summary Section
            g.DrawString("Payment Summary", sectionFont, brush, leftMargin, yPos);
            yPos += 35;

            // Itemized breakdown
            DrawSummaryRow(g, "Room Charges:", $"{invoice.DaysStayed} nights × {(invoice.BasePrice / invoice.DaysStayed):C2}", leftMargin, ref yPos, labelFont, valueFont);
            var baseAmount = invoice.BasePrice;
            g.DrawString(baseAmount.ToString("C2"), valueFont, brush, rightMargin - 100, yPos - 25);
            
            DrawSummaryRow(g, "Tax & Service:", $"{((invoice.TaxPrice / invoice.BasePrice) * 100):F1}%", leftMargin, ref yPos, labelFont, valueFont);
            g.DrawString(invoice.TaxPrice.ToString("C2"), valueFont, brush, rightMargin - 100, yPos - 25);

            yPos += 10;
            g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 15;

            // Total
            g.DrawString("TOTAL AMOUNT:", totalFont, brush, leftMargin, yPos);
            g.DrawString(invoice.TotalPrice.ToString("C2"), totalFont, brush, rightMargin - 120, yPos);
            yPos += 40;

            // Payment Information
            if (invoice.Payment != null)
            {
                g.DrawLine(Pens.LightGray, leftMargin, yPos, rightMargin, yPos);
                yPos += 25;
                
                g.DrawString("Payment Information", sectionFont, brush, leftMargin, yPos);
                yPos += 35;

                DrawSummaryRow(g, "Payment Method:", invoice.Payment.Method.ToString(), leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Payment Status:", invoice.Payment.Status.ToString(), leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Amount Paid:", invoice.Payment.Amount.ToString("C2"), leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Payment Date:", invoice.Payment.CreatedAt.ToString("MMM dd, yyyy HH:mm"), leftMargin, ref yPos, labelFont, valueFont);
            }

            // Footer
            yPos = e.PageBounds.Height - 100;
            g.DrawLine(Pens.LightGray, leftMargin, yPos, rightMargin, yPos);
            yPos += 15;
            var footerFont = new Font("Arial", 9, FontStyle.Italic);
            g.DrawString("Thank you for choosing Grand Hotel!", footerFont, grayBrush, leftMargin, yPos);
            yPos += 15;
            g.DrawString("For any inquiries, please contact our front desk.", footerFont, grayBrush, leftMargin, yPos);
        }

        private string GetStatusWithColor(Graphics g, InvoiceStatus status, float x, float y)
        {
            var statusFont = new Font("Arial", 11, FontStyle.Bold);
            var brush = status switch
            {
                InvoiceStatus.Paid => Brushes.Green,
                InvoiceStatus.Pending => Brushes.Orange,
                InvoiceStatus.Cancelled => Brushes.Red,
                _ => Brushes.Black
            };
            
            g.DrawString(status.ToString(), statusFont, brush, x, y);
            return ""; // Return empty since we drew it directly
        }

        private void DrawSummaryRow(Graphics g, string label, string value, float x, ref float y, Font labelFont, Font valueFont)
        {
            g.DrawString(label, labelFont, Brushes.Black, x, y);
            g.DrawString(value, valueFont, Brushes.Black, x + 150, y);
            y += 25;
        }

        // ViewModel for DataGridView
        private class InvoiceViewModel
        {
            public Guid Id { get; set; }
            public string RoomNumber { get; set; } = string.Empty;
            public string BookerEmail { get; set; } = string.Empty;
            public decimal BasePrice { get; set; }
            public decimal TotalPrice { get; set; }
            public int DaysStayed { get; set; }
            public InvoiceStatus Status { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public DateTime? DeletedAt { get; set; }
            public InvoiceResponseDto OriginalDto { get; set; } = default!;
        }
    }
}
