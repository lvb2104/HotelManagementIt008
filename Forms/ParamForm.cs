using HotelManagementIt008.Services.Interfaces;
using HotelManagementIt008.Dtos.Requests;

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
                    dgvParams.DataSource = result.Value.Select(p => new
                    {
                        p.Key,
                        p.Value,
                        p.Description,
                        p.UpdatedAt
                    }).ToList();

                    // Make Key read-only
                    if (dgvParams.Columns["Key"] != null)
                        dgvParams.Columns["Key"].ReadOnly = true;
                    
                    if (dgvParams.Columns["Description"] != null)
                        dgvParams.Columns["Description"].ReadOnly = true;

                    if (dgvParams.Columns["UpdatedAt"] != null)
                        dgvParams.Columns["UpdatedAt"].ReadOnly = true;
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvParams.CurrentRow == null) return;

                var key = dgvParams.CurrentRow.Cells["Key"].Value?.ToString();
                var value = dgvParams.CurrentRow.Cells["Value"].Value?.ToString();

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
                    LoadParams(); // Refresh
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
    }
}
