using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Services.Interfaces;
using HotelManagementIt008.Types;
using System.Data;
using System.Drawing.Printing;

namespace HotelManagementIt008.Forms
{
    public partial class InvoiceManagementForm : BaseForm
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ICurrentUserService _currentUserService;
        private List<InvoiceResponseDto> _allInvoices = new();
        private int _currentPage = 1;
        private readonly int _pageSize = 20;
        private int _totalPages = 1;

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
                // Assuming we fetch all for the user/admin and filter client-side
                // We don't have the role here, but maybe we can infer or pass it. 
                // For now, let's pass empty role or handle it in service if possible.
                // Actually, IInvoiceService.GetInvoicesAsync takes (role, userId).
                // I'll assume "Admin" if I can't determine, or just pass userId and let service handle.
                // But wait, I don't know the role. I'll pass "User" or "Admin" based on context if I had it.
                // Let's try passing the userId and a placeholder role, or maybe the service ignores role if userId is admin?
                // I'll pass "Admin" for now as this form seems to be for management. 
                // TODO: Pass correct role.
                
                var result = await _invoiceService.GetInvoicesAsync(_currentUserService.Role.ToString(), _currentUserService.UserId.ToString());

                if (result.IsSuccess && result.Value != null)
                {
                    _allInvoices = result.Value.ToList();
                    ApplyFiltersAndBind();
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

        private void ApplyFiltersAndBind()
        {
            var filtered = _allInvoices.AsEnumerable();

            // Status Filter
            if (cboFilterStatus.SelectedItem is string statusStr && statusStr != "All")
            {
                if (Enum.TryParse<InvoiceStatus>(statusStr, out var status))
                {
                    filtered = filtered.Where(i => i.Status == status);
                }
            }

            // Date Filter
            if (dtpFilterDate.Checked)
            {
                filtered = filtered.Where(i => i.CreatedAt.Date == dtpFilterDate.Value.Date);
            }

            // Map to ViewModel for Display
            var viewModels = filtered.Select(i => new InvoiceViewModel
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
            }).OrderByDescending(i => i.CreatedAt).ToList();

            // Pagination
            _totalPages = (int)Math.Ceiling((decimal)viewModels.Count / _pageSize);
            if (_totalPages == 0) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = _totalPages;

            var pagedList = viewModels
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            dgvInvoices.DataSource = pagedList;
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
            cboFilterStatus.SelectedIndex = 0;
            dtpFilterDate.Checked = false;
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
