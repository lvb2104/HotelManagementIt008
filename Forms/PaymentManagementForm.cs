using System.Text;

using Gridify;

using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementIt008.Forms
{
    public partial class PaymentManagementForm : BaseForm
    {
        private readonly IPaymentService _paymentService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICurrentUserService _currentUserService;
        private int _currentPage = 1;
        private readonly int _pageSize = 20;
        private int _totalPages = 1;
        private int _totalCount = 0;

        public PaymentManagementForm(IPaymentService paymentService, IServiceProvider serviceProvider, ICurrentUserService currentUserService)
        {
            InitializeComponent();
            _paymentService = paymentService;
            _serviceProvider = serviceProvider;
            _currentUserService = currentUserService;
            ConfigureDataGridView();
        }

        private async void PaymentManagementForm_Load(object sender, EventArgs e)
        {
            // Initialize filters
            cboFilterMethod.Items.Clear();
            cboFilterMethod.Items.Add("All");
            foreach (var method in Enum.GetValues<PaymentMethod>())
            {
                cboFilterMethod.Items.Add(method.ToString());
            }
            cboFilterMethod.SelectedIndex = 0;

            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.Add("All");
            foreach (var status in Enum.GetValues<PaymentStatus>())
            {
                cboFilterStatus.Items.Add(status.ToString());
            }
            cboFilterStatus.SelectedIndex = 0;

            dtpFilterDate.ShowCheckBox = true;
            dtpFilterDate.Checked = false;

            await LoadPayments();
        }

        private void ConfigureDataGridView()
        {
            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.Columns.Clear();
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.MultiSelect = false;
            dgvPayments.ReadOnly = true;

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMethod",
                DataPropertyName = "Method",
                HeaderText = "Payment Method",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAmount",
                DataPropertyName = "Amount",
                HeaderText = "Amount",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 120
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                DataPropertyName = "Status",
                HeaderText = "Status",
                Width = 100
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colInvoiceCount",
                DataPropertyName = "InvoiceCount",
                HeaderText = "Invoices",
                Width = 80
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCreatedAt",
                DataPropertyName = "CreatedAt",
                HeaderText = "Created At",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                Width = 100
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUpdatedAt",
                DataPropertyName = "UpdatedAt",
                HeaderText = "Updated At",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                Width = 100
            });

            dgvPayments.SelectionChanged += DgvPayments_SelectionChanged;
            dgvPayments.CellDoubleClick += DgvPayments_CellDoubleClick;
        }

        private void DgvPayments_SelectionChanged(object? sender, EventArgs e)
        {
            bool hasSelection = dgvPayments.SelectedRows.Count > 0;
            btnEditPayment.Enabled = hasSelection;
            btnDeletePayment.Enabled = hasSelection;
            btnMergePayments.Enabled = hasSelection;
            btnPrintPayment.Enabled = hasSelection;

            if (hasSelection)
            {
                var row = dgvPayments.SelectedRows[0];
                if (row.DataBoundItem is PaymentViewModel vm)
                {
                    btnMarkAsPaid.Enabled = vm.Status != PaymentStatus.Paid && vm.Status != PaymentStatus.Canceled && vm.Status != PaymentStatus.Failed;
                    btnMarkAsPending.Enabled = vm.Status != PaymentStatus.Pending && vm.Status != PaymentStatus.Canceled && vm.Status != PaymentStatus.Failed;
                }
            }
            else
            {
                btnMarkAsPaid.Enabled = false;
                btnMarkAsPending.Enabled = false;
            }
        }

        private void DgvPayments_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditPayment_Click(sender, e);
            }
        }

        private async Task LoadPayments()
        {
            try
            {
                var gridifyQuery = new GridifyQuery
                {
                    Page = _currentPage,
                    PageSize = _pageSize,
                    OrderBy = "createdAt desc"
                };

                var result = await _paymentService.GetPaymentsAsync(gridifyQuery);

                if (result.IsSuccess && result.Value != null)
                {
                    _totalCount = result.Value.Count;
                    _totalPages = (int)Math.Ceiling((decimal)_totalCount / _pageSize);
                    if (_totalPages == 0) _totalPages = 1;

                    var viewModels = result.Value.Data.Select(p => new PaymentViewModel
                    {
                        Id = p.Id,
                        Method = p.Method,
                        Amount = p.Amount,
                        Status = p.Status,
                        InvoiceCount = p.Invoices?.Count ?? 0,
                        CreatedAt = p.CreatedAt,
                        UpdatedAt = p.UpdatedAt,
                        OriginalDto = p
                    }).ToList();

                    dgvPayments.DataSource = viewModels;
                    UpdatePaginationControls();
                }
                else
                {
                    MessageBox.Show("Failed to load payments: " + (result.ErrorMessage ?? "Unknown error"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ApplyFiltersAndBind()
        {
            try
            {
                var filters = new List<string>();

                if (cboFilterMethod.SelectedItem is string methodStr && methodStr != "All")
                {
                    filters.Add($"method={methodStr}");
                }

                if (cboFilterStatus.SelectedItem is string statusStr && statusStr != "All")
                {
                    filters.Add($"status={statusStr}");
                }

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

                var result = await _paymentService.GetPaymentsAsync(gridifyQuery);

                if (result.IsSuccess && result.Value != null)
                {
                    _totalCount = result.Value.Count;
                    _totalPages = (int)Math.Ceiling((decimal)_totalCount / _pageSize);
                    if (_totalPages == 0) _totalPages = 1;

                    var viewModels = result.Value.Data.Select(p => new PaymentViewModel
                    {
                        Id = p.Id,
                        Method = p.Method,
                        Amount = p.Amount,
                        Status = p.Status,
                        InvoiceCount = p.Invoices?.Count ?? 0,
                        CreatedAt = p.CreatedAt,
                        UpdatedAt = p.UpdatedAt,
                        OriginalDto = p
                    }).ToList();

                    dgvPayments.DataSource = viewModels;
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
            cboFilterMethod.SelectedIndex = 0;
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

        private async void btnEditPayment_Click(object? sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                var row = dgvPayments.SelectedRows[0];
                if (row.DataBoundItem is PaymentViewModel vm)
                {
                    var form = _serviceProvider.GetRequiredService<PaymentDetailForm>();
                    form.PaymentId = vm.Id;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await LoadPayments();
                    }
                }
            }
        }

        private async void btnDeletePayment_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                var row = dgvPayments.SelectedRows[0];
                if (row.DataBoundItem is PaymentViewModel vm)
                {
                    if (MessageBox.Show($"Are you sure you want to delete this payment?\\n\\nNote: Payments with linked invoices cannot be deleted.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var result = await _paymentService.DeletePaymentAsync(vm.Id.ToString());
                        if (result.IsSuccess)
                        {
                            MessageBox.Show("Payment deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadPayments();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete payment: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async void btnMergePayments_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                var row = dgvPayments.SelectedRows[0];
                if (row.DataBoundItem is PaymentViewModel vm)
                {
                    var form = _serviceProvider.GetRequiredService<PaymentMergeForm>();
                    form.TargetPaymentId = vm.Id;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await LoadPayments();
                    }
                }
            }
        }

        private void btnPrintPayment_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                var row = dgvPayments.SelectedRows[0];
                if (row.DataBoundItem is PaymentViewModel vm)
                {
                    PrintPaymentDetails(vm.OriginalDto);
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
                    FileName = $"Payments_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Export Payments to CSV",
                    DefaultExt = "csv"
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                var csv = new StringBuilder();

                // Add headers
                foreach (DataGridViewColumn col in dgvPayments.Columns)
                {
                    if (col.Visible)
                        csv.Append(col.HeaderText + ",");
                }
                csv.AppendLine();

                // Add rows
                foreach (DataGridViewRow row in dgvPayments.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (dgvPayments.Columns[cell.ColumnIndex].Visible)
                        {
                            var value = cell.Value?.ToString()?.Replace(",", ";") ?? string.Empty;
                            csv.Append(value + ",");
                        }
                    }
                    csv.AppendLine();
                }

                File.WriteAllText(saveFileDialog.FileName, csv.ToString());
                MessageBox.Show($"Successfully exported to:\\n{saveFileDialog.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnMarkAsPaid_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                var row = dgvPayments.SelectedRows[0];
                if (row.DataBoundItem is PaymentViewModel vm)
                {
                    if (vm.Status == PaymentStatus.Paid) return;

                    if (MessageBox.Show("Mark this payment as PAID?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var updateDto = new UpdatePaymentDto
                        {
                            Method = vm.Method,
                            Status = PaymentStatus.Paid
                        };
                        var result = await _paymentService.UpdatePaymentAsync(vm.Id.ToString(), updateDto);
                        if (result.IsSuccess)
                        {
                            MessageBox.Show("Payment marked as paid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadPayments();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update status: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async void btnMarkAsPending_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                var row = dgvPayments.SelectedRows[0];
                if (row.DataBoundItem is PaymentViewModel vm)
                {
                    if (vm.Status == PaymentStatus.Pending) return;

                    if (MessageBox.Show("Mark this payment as PENDING?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var updateDto = new UpdatePaymentDto
                        {
                            Method = vm.Method,
                            Status = PaymentStatus.Pending
                        };
                        var result = await _paymentService.UpdatePaymentAsync(vm.Id.ToString(), updateDto);
                        if (result.IsSuccess)
                        {
                            MessageBox.Show("Payment marked as pending.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadPayments();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update status: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void PrintPaymentDetails(PaymentResponseDto payment)
        {
            var printDoc = new System.Drawing.Printing.PrintDocument();
            printDoc.PrintPage += (sender, e) => PrintPageHandler(sender, e, payment);

            var previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600
            };
            previewDialog.ShowDialog();
        }

        private void PrintPageHandler(object sender, System.Drawing.Printing.PrintPageEventArgs e, PaymentResponseDto payment)
        {
            var g = e.Graphics;
            if (g == null) return;

            var titleFont = new Font("Arial", 24, FontStyle.Bold);
            var sectionFont = new Font("Arial", 18, FontStyle.Bold);
            var labelFont = new Font("Arial", 12, FontStyle.Bold);
            var valueFont = new Font("Arial", 12, FontStyle.Regular);

            var brush = Brushes.Black;
            float yPos = 50;
            float leftMargin = 50;

            // Title
            var title = "PAYMENT RECEIPT";
            var titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, brush, (e.PageBounds.Width - titleSize.Width) / 2, yPos);
            yPos += 60;

            // Payment Info
            DrawSummaryRow(g, "Payment ID:", payment.Id.ToString().Substring(0, 8).ToUpper(), leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Date:", payment.CreatedAt.ToString("yyyy-MM-dd"), leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Method:", payment.Method.ToString(), leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Status:", payment.Status.ToString(), leftMargin, ref yPos, labelFont, valueFont);
            DrawSummaryRow(g, "Amount:", payment.Amount.ToString("C2"), leftMargin, ref yPos, labelFont, valueFont);

            yPos += 20;
            g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - 50, yPos);
            yPos += 20;

            // Linked Invoices
            g.DrawString("Linked Invoices", sectionFont, brush, leftMargin, yPos);
            yPos += 30;

            if (payment.Invoices != null && payment.Invoices.Any())
            {
                foreach (var invoice in payment.Invoices)
                {
                    DrawSummaryRow(g, $"Invoice {invoice.Id.ToString().Substring(0, 8)}:", $"{invoice.RoomNumber} - {invoice.TotalPrice:C2} ({invoice.Status})", leftMargin, ref yPos, labelFont, valueFont);
                }
            }
            else
            {
                g.DrawString("No linked invoices", valueFont, brush, leftMargin, yPos);
            }
        }

        private void DrawSummaryRow(Graphics g, string label, string value, float x, ref float y, Font labelFont, Font valueFont)
        {
            g.DrawString(label, labelFont, Brushes.Black, x, y);
            g.DrawString(value, valueFont, Brushes.Black, x + 150, y);
            y += 25;
        }

        // ViewModel for DataGridView
        private class PaymentViewModel
        {
            public Guid Id { get; set; }
            public PaymentMethod Method { get; set; }
            public decimal Amount { get; set; }
            public PaymentStatus Status { get; set; }
            public int InvoiceCount { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public PaymentResponseDto OriginalDto { get; set; } = default!;
        }
    }
}
