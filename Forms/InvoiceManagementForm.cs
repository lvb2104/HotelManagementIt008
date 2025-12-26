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
            var titleFont = new Font("Arial", 24, FontStyle.Bold);
            var sectionFont = new Font("Arial", 18, FontStyle.Bold);
            var labelFont = new Font("Arial", 12, FontStyle.Bold);
            var valueFont = new Font("Arial", 12, FontStyle.Regular);

            var brush = Brushes.Black;
            float yPos = 50;
            float leftMargin = 50;

            // Title
            var title = "INVOICE";
            var titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, brush, (e.PageBounds.Width - titleSize.Width) / 2, yPos);
            yPos += 60;

            // Invoice Info
            DrawSummaryRow(g, "Invoice ID:", invoice.Id.ToString(), leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Date:", invoice.CreatedAt.ToString("yyyy-MM-dd"), leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Status:", invoice.Status.ToString(), leftMargin, ref yPos, labelFont, valueFont);

            yPos += 20;
            g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - 50, yPos);
            yPos += 20;

            // Booking Info
            g.DrawString("Booking Details", sectionFont, brush, leftMargin, yPos);
            yPos += 30;

            if (invoice.Booking != null)
            {
                DrawSummaryRow(g, "Room:", invoice.Booking.Room?.RoomNumber ?? "N/A", leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Check In:", invoice.Booking.CheckInDate.ToString("yyyy-MM-dd"), leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Check Out:", invoice.Booking.CheckOutDate.ToString("yyyy-MM-dd"), leftMargin, ref yPos, labelFont, valueFont);
                DrawSummaryRow(g, "Booker:", invoice.Booking.User?.Email ?? "N/A", leftMargin, ref yPos, labelFont, valueFont);
            }

            yPos += 20;
            g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - 50, yPos);
            yPos += 20;

            // Payment Info
            g.DrawString("Payment Summary", sectionFont, brush, leftMargin, yPos);
            yPos += 30;

            DrawSummaryRow(g, "Base Price:", invoice.BasePrice.ToString("C2"), leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Days Stayed:", invoice.DaysStayed.ToString(), leftMargin, ref yPos, labelFont, valueFont);

            yPos += 10;
            var totalFont = new Font("Arial", 14, FontStyle.Bold);
            g.DrawString($"Total: {invoice.TotalPrice:C2}", totalFont, brush, leftMargin, yPos);
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
