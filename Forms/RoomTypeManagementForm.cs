using System.Text;

using Gridify;

using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementIt008.Forms
{
    public partial class RoomTypeManagementForm : BaseForm
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly IGridifyMapper<RoomType> _mapper;
        private readonly IServiceProvider _serviceProvider;
        private int _currentPage = 1;
        private readonly int _pageSize = 20;
        private int _totalPages = 1;

        public RoomTypeManagementForm(IRoomTypeService roomTypeService, IGridifyMapper<RoomType> mapper, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _roomTypeService = roomTypeService;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
            ConfigureDataGridView();
        }

        private async void RoomTypeManagementForm_Load(object sender, EventArgs e)
        {
            await InitializeFilters();
            await LoadRoomTypes();
        }

        private void ConfigureDataGridView()
        {
            dgvRoomTypes.AutoGenerateColumns = false;
            dgvRoomTypes.Columns.Clear();

            dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                DataPropertyName = nameof(RoomTypeResponseDto.Id),
                HeaderText = "ID",
                Visible = false
            });

            dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                DataPropertyName = nameof(RoomTypeResponseDto.Name),
                HeaderText = "Name",
                Width = 200
            });

            dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescription",
                DataPropertyName = nameof(RoomTypeResponseDto.Description),
                HeaderText = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                DataPropertyName = nameof(RoomTypeResponseDto.PricePerNight),
                HeaderText = "Price Per Night",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCreatedAt",
                DataPropertyName = nameof(RoomTypeResponseDto.CreatedAt),
                HeaderText = "Created At",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "g" }
            });

            dgvRoomTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUpdatedAt",
                DataPropertyName = nameof(RoomTypeResponseDto.UpdatedAt),
                HeaderText = "Updated At",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "g" }
            });

            // Wire up event handler to enable/disable buttons based on selection
            dgvRoomTypes.SelectionChanged += DgvRoomTypes_SelectionChanged;
        }

        private async Task LoadRoomTypes()
        {
            var filterString = BuildFilterString();
            var gridifyQuery = new GridifyQuery
            {
                Filter = filterString,
                Page = _currentPage,
                PageSize = _pageSize,
                OrderBy = "name"
            };

            var roomTypesResult = await _roomTypeService.GetAllRoomTypesAsync(gridifyQuery);

            if (roomTypesResult.IsSuccess && roomTypesResult.Value is not null)
            {
                // Bind data to DataGridView
                dgvRoomTypes.DataSource = roomTypesResult.Value.Data;

                // _totalPages calculation
                _totalPages = (int)Math.Ceiling((decimal)roomTypesResult.Value.Count / _pageSize);
                UpdatePaginationControls();
            }
            else
            {
                MessageBox.Show("Failed to load room types: " + roomTypesResult.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task InitializeFilters()
        {
            // No filters needed initially for room types
            // Just set up price range
            nudPriceFrom.Minimum = 0;
            nudPriceFrom.Maximum = 10000;
            nudPriceFrom.Value = 0;

            nudPriceTo.Minimum = 0;
            nudPriceTo.Maximum = 10000;
            nudPriceTo.Value = 10000;

            // Add event handlers for validation
            nudPriceFrom.ValueChanged += ValidatePriceRange;
            nudPriceTo.ValueChanged += ValidatePriceRange;
        }

        private void ValidatePriceRange(object? sender, EventArgs e)
        {
            // Ensure "From" is not greater than "To"
            if (nudPriceFrom.Value > nudPriceTo.Value)
            {
                if (sender == nudPriceFrom)
                {
                    // User changed "From", adjust "To"
                    nudPriceTo.Value = nudPriceFrom.Value;
                }
                else
                {
                    // User changed "To", adjust "From"
                    nudPriceFrom.Value = nudPriceTo.Value;
                }
            }
        }

        private string BuildFilterString()
        {
            var parts = new List<string>();

            if (!string.IsNullOrWhiteSpace(txtFilterName.Text))
                parts.Add($"name=*{txtFilterName.Text.Trim()}");

            if (nudPriceFrom.Value > 0)
                parts.Add($"price>={nudPriceFrom.Value}");

            if (nudPriceTo.Value > 0 && nudPriceTo.Value < nudPriceTo.Maximum)
                parts.Add($"price<={nudPriceTo.Value}");

            return parts.Count > 0 ? string.Join(",", parts) : string.Empty;
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
            await LoadRoomTypes();
        }

        private async void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtFilterName.Clear();
            nudPriceFrom.Value = nudPriceFrom.Minimum;
            nudPriceTo.Value = nudPriceTo.Maximum;
            _currentPage = 1;
            await LoadRoomTypes();
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadRoomTypes();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadRoomTypes();
            }
        }

        private async void btnAddRoomType_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<RoomTypeDetailForm>();
            form.RoomTypeId = null; // null means create new
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadRoomTypes();
            }
        }

        private async void btnEditRoomType_Click(object sender, EventArgs e)
        {
            if (dgvRoomTypes.CurrentRow == null)
            {
                MessageBox.Show("Please select a room type to edit", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvRoomTypes.CurrentRow.Cells["colId"].Value is not Guid roomTypeId)
                return;

            using var scope = _serviceProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<RoomTypeDetailForm>();
            form.RoomTypeId = roomTypeId;
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadRoomTypes();
            }
        }

        private async void btnDeleteRoomType_Click(object sender, EventArgs e)
        {
            if (dgvRoomTypes.CurrentRow == null)
            {
                MessageBox.Show("Please select a room type to delete", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvRoomTypes.CurrentRow.Cells["colId"].Value is not Guid roomTypeId)
                return;

            var roomTypeName = dgvRoomTypes.CurrentRow.Cells["colName"].Value?.ToString() ?? "this room type";

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete '{roomTypeName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
                return;

            var result = await _roomTypeService.DeleteRoomTypeAsync(roomTypeId);
            if (result.IsSuccess)
            {
                MessageBox.Show("Room type deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadRoomTypes();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage ?? "Failed to delete room type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                    FilterIndex = 1,
                    FileName = $"RoomTypes_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Export Room Types to CSV",
                    DefaultExt = "csv"
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                var csv = new StringBuilder();

                // Add headers
                foreach (DataGridViewColumn col in dgvRoomTypes.Columns)
                {
                    if (col.Visible)
                        csv.Append(col.HeaderText + ",");
                }
                csv.AppendLine();

                // Add rows
                foreach (DataGridViewRow row in dgvRoomTypes.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (dgvRoomTypes.Columns[cell.ColumnIndex].Visible)
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

        private void DgvRoomTypes_SelectionChanged(object? sender, EventArgs e)
        {
            bool hasSelection = dgvRoomTypes.SelectedRows.Count > 0;
            btnEditRoomType.Enabled = hasSelection;
            btnDeleteRoomType.Enabled = hasSelection;
        }
    }
}
