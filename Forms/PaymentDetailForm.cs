using System.ComponentModel;

namespace HotelManagementIt008.Forms
{
    public partial class PaymentDetailForm : Form
    {
        private readonly IPaymentService _paymentService;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid? PaymentId { get; set; }
        
        private PaymentStatus _currentStatus;

        public PaymentDetailForm(IPaymentService paymentService)
        {
            InitializeComponent();
            _paymentService = paymentService;
            LoadPaymentMethods();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (PaymentId == null)
            {
                MessageBox.Show("Invalid payment ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            await LoadPaymentDetails();
        }

        private void LoadPaymentMethods()
        {
            cboMethod.DataSource = Enum.GetValues(typeof(PaymentMethod));
        }



        private async Task LoadPaymentDetails()
        {
            if (!PaymentId.HasValue)
                return;

            var result = await _paymentService.GetPaymentByIdAsync(PaymentId.Value.ToString());

            if (!result.IsSuccess || result.Value == null)
            {
                MessageBox.Show(result.ErrorMessage ?? "Failed to load payment details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var payment = result.Value;
            lblAmount.Text = payment.Amount.ToString("C"); // Format as currency
            cboMethod.SelectedItem = payment.Method;
            _currentStatus = payment.Status;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (cboMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment method", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMethod.Focus();
                return;
            }



            if (!PaymentId.HasValue)
            {
                MessageBox.Show("Invalid payment ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var updateDto = new UpdatePaymentDto
            {
                Method = (PaymentMethod)cboMethod.SelectedItem,
                Status = _currentStatus
            };

            var result = await _paymentService.UpdatePaymentAsync(PaymentId.Value.ToString(), updateDto);
            if (result.IsSuccess)
            {
                MessageBox.Show("Payment updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage ?? "Failed to update payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
