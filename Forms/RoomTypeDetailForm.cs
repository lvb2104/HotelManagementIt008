using System.ComponentModel;

namespace HotelManagementIt008.Forms
{
    public partial class RoomTypeDetailForm : Form
    {
        private readonly IRoomTypeService _roomTypeService;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid? RoomTypeId { get; set; }

        public RoomTypeDetailForm(IRoomTypeService roomTypeService)
        {
            InitializeComponent();
            _roomTypeService = roomTypeService;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (RoomTypeId == null)
            {
                Text = "Create Room Type";
                return;
            }

            Text = "Edit Room Type";
            await LoadRoomTypeDetails();
        }

        private async Task LoadRoomTypeDetails()
        {
            if (!RoomTypeId.HasValue)
                return;

            var result = await _roomTypeService.GetRoomTypeByIdAsync(RoomTypeId.Value);

            if (!result.IsSuccess || result.Value == null)
            {
                MessageBox.Show(result.ErrorMessage ?? "Failed to load room type details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var roomType = result.Value;
            txtName.Text = roomType.Name;
            txtDescription.Text = roomType.Description ?? string.Empty;
            nudPricePerNight.Value = roomType.PricePerNight;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Room type name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (nudPricePerNight.Value <= 0)
            {
                MessageBox.Show("Price per night must be greater than zero", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudPricePerNight.Focus();
                return;
            }

            if (RoomTypeId.HasValue)
            {
                // Edit room type
                var updateDto = new UpdateRoomTypeDto
                {
                    Name = txtName.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                    PricePerNight = nudPricePerNight.Value
                };

                var result = await _roomTypeService.UpdateRoomTypeAsync(RoomTypeId.Value, updateDto);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Room type updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage ?? "Failed to update room type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Create new room type
                var createDto = new CreateRoomTypeDto
                {
                    Name = txtName.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                    PricePerNight = nudPricePerNight.Value
                };

                var result = await _roomTypeService.CreateRoomTypeAsync(createDto);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Room type created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage ?? "Failed to create room type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
