namespace HotelManagementIt008.Forms
{
    public partial class ParamForm : Form
    {
        private readonly IParamService _paramService;

        public ParamForm(IParamService paramService)
        {
            InitializeComponent();
            _paramService = paramService;
            LoadParams();
        }

        private async void LoadParams()
        {
            try
            {
                var result = await _paramService.GetAllParamsAsync();
                if (result.IsSuccess)
                {
                    if (result.Value == null) return;
                    dgvParams.DataSource = result.Value.Select(p => new
                    {
                        p.Key,
                        p.Value,
                        p.Description
                    }).ToList();

                    // Populate ComboBox
                    cbKey.Items.Clear();
                    foreach (var param in result.Value)
                    {
                        cbKey.Items.Add(param.Key);
                    }

                    // Make Key read-only
                    dgvParams.Columns["Key"]?.ReadOnly = true;

                    dgvParams.Columns["Description"]?.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading params: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var key = cbKey.Text.Trim();
                var value = txtValue.Text.Trim();

                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Key and Value cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dto = new UpdateParamDto { Value = value };
                var result = await _paramService.UpdateParamAsync(key, dto);

                if (result.IsSuccess)
                {
                    MessageBox.Show("Parameter updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadParams(); // Refresh grid
                    cbKey.Text = string.Empty;
                    txtValue.Clear();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating param: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = await _paramService.GetParamByKeyAsync(cbKey.Text);
            if (value.IsSuccess)
            {
                txtValue.Text = value.Value?.Value ?? string.Empty;
            }
        }
    }
}
