using System.ComponentModel;

namespace HotelManagementIt008.Forms
{
    public partial class PaymentMergeForm : Form
    {
        private readonly IPaymentService _paymentService;
        private decimal _targetAmount = 0;
        private List<PaymentViewModel> _allPayments = new();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid TargetPaymentId { get; set; }

        public PaymentMergeForm(IPaymentService paymentService)
        {
            InitializeComponent();
            _paymentService = paymentService;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (TargetPaymentId == Guid.Empty)
            {
                MessageBox.Show("Invalid target payment ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            await LoadTargetPayment();
            await LoadAvailablePayments();
        }

        private async Task LoadTargetPayment()
        {
            var result = await _paymentService.GetPaymentByIdAsync(TargetPaymentId.ToString());

            if (!result.IsSuccess || result.Value == null)
            {
                MessageBox.Show(result.ErrorMessage ?? "Failed to load target payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var payment = result.Value;
            _targetAmount = payment.Amount;

            lblTargetId.Text = payment.Id.ToString();
            lblTargetMethod.Text = payment.Method.ToString();
            lblTargetAmount.Text = payment.Amount.ToString("C");
            lblTargetStatus.Text = payment.Status.ToString();

            lblCurrentAmount.Text = _targetAmount.ToString("C");
            UpdateTotalAmount();
        }

        private async Task LoadAvailablePayments()
        {
            var result = await _paymentService.GetAllPaymentsAsync();

            if (!result.IsSuccess || result.Value == null)
            {
                MessageBox.Show(result.ErrorMessage ?? "Failed to load payments", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Filter out target payment and deleted payments
            _allPayments = result.Value
                .Where(p => p.Id != TargetPaymentId && p.DeletedAt == null)
                .Select(p => new PaymentViewModel
                {
                    Select = false,
                    Id = p.Id,
                    Method = p.Method.ToString(),
                    Amount = p.Amount,
                    Status = p.Status.ToString(),
                    CreatedAt = p.CreatedAt
                })
                .ToList();

            ConfigureDataGridView();
            dgvPayments.DataSource = _allPayments;
        }

        private void ConfigureDataGridView()
        {
            dgvPayments.Columns.Clear();

            // Checkbox column
            var selectColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Select",
                HeaderText = "Select",
                DataPropertyName = "Select",
                Width = 60,
                ReadOnly = false
            };
            dgvPayments.Columns.Add(selectColumn);

            // Other columns
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Payment ID",
                DataPropertyName = "Id",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Method",
                HeaderText = "Method",
                DataPropertyName = "Method",
                ReadOnly = true,
                Width = 120
            });

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "Amount",
                DataPropertyName = "Amount",
                ReadOnly = true,
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C" }
            });

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                ReadOnly = true,
                Width = 100
            });

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedAt",
                HeaderText = "Created",
                DataPropertyName = "CreatedAt",
                ReadOnly = true,
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "g" }
            });
        }

        private void dgvPayments_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvPayments.IsCurrentCellDirty)
            {
                dgvPayments.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvPayments_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPayments.Columns[e.ColumnIndex].Name == "Select")
            {
                UpdateTotalAmount();
            }
        }

        private void UpdateTotalAmount()
        {
            var selectedPayments = _allPayments.Where(p => p.Select).ToList();
            var mergeAmount = selectedPayments.Sum(p => p.Amount);
            var totalAmount = _targetAmount + mergeAmount;

            lblTotalAmount.Text = totalAmount.ToString("C");
            btnMerge.Enabled = selectedPayments.Count > 0;
        }

        private async void btnMerge_Click(object sender, EventArgs e)
        {
            var selectedPayments = _allPayments.Where(p => p.Select).ToList();

            if (selectedPayments.Count == 0)
            {
                MessageBox.Show("Please select at least one payment to merge", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmation dialog
            var confirmMessage = $"This will merge {selectedPayments.Count} payment(s) into the target payment.\n\n" +
                                $"Current amount: {_targetAmount:C}\n" +
                                $"Total after merge: {lblTotalAmount.Text}\n\n" +
                                $"⚠️ This action cannot be undone.\n\nContinue?";

            var confirmResult = MessageBox.Show(
                confirmMessage,
                "Confirm Merge",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult != DialogResult.Yes)
                return;

            var mergeDto = new MergePaymentsDto
            {
                TargetPaymentId = TargetPaymentId,
                PaymentIdsToMerge = selectedPayments.Select(p => p.Id).ToList()
            };

            var result = await _paymentService.MergePaymentsAsync(mergeDto);

            if (result.IsSuccess)
            {
                MessageBox.Show($"Successfully merged {selectedPayments.Count} payment(s)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage ?? "Failed to merge payments", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // ViewModel for DataGridView
        private class PaymentViewModel
        {
            public bool Select { get; set; }
            public Guid Id { get; set; }
            public string Method { get; set; } = string.Empty;
            public decimal Amount { get; set; }
            public string Status { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; }
        }
    }
}
