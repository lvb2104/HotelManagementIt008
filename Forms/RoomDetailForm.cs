using System.ComponentModel;

namespace HotelManagementIt008.Forms
{
    public partial class RoomDetailForm : Form
    {
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid? RoomId { get; set; }

        public RoomDetailForm(IRoomService roomService, IRoomTypeService roomTypeService)
        {
            InitializeComponent();
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            LoadRoomStatuses(); // Synchronous, no DB call
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Load room types first (async DB call)
            await LoadRoomTypes();

            if (RoomId == null)
            {
                Text = "Create Room";
                return;
            }

            Text = "Edit Room";
            await LoadRoomDetails();
        }

        private async Task LoadRoomTypes()
        {
            var result = await _roomTypeService.GetAllRoomTypesAsync();
            if (result.IsSuccess && result.Value != null)
            {
                cboRoomType.DataSource = result.Value;
                cboRoomType.DisplayMember = "Name";
                cboRoomType.ValueMember = "Id";
            }
        }

        private void LoadRoomStatuses()
        {
            cboStatus.DataSource = Enum.GetValues(typeof(RoomStatus));
        }

        private async Task LoadRoomDetails()
        {
            if (!RoomId.HasValue)
                return;

            var result = await _roomService.GetRoomByIdAsync(RoomId.Value);

            if (!result.IsSuccess || result.Value == null)
            {
                MessageBox.Show(result.ErrorMessage ?? "Failed to load room details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var room = result.Value;
            txtRoomNumber.Text = room.RoomNumber;
            txtNote.Text = room.Note ?? string.Empty;
            cboStatus.SelectedItem = room.Status;
            cboRoomType.SelectedValue = room.RoomTypeId;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                MessageBox.Show("Room number is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomNumber.Focus();
                return;
            }

            if (cboRoomType.SelectedValue == null)
            {
                MessageBox.Show("Please select a room type", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRoomType.Focus();
                return;
            }

            if (RoomId.HasValue)
            {
                // Edit room
                var updateDto = new UpdateRoomDto
                {
                    RoomNumber = txtRoomNumber.Text.Trim(),
                    Note = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim(),
                    Status = (RoomStatus)(cboStatus.SelectedItem ?? RoomStatus.Available),
                    RoomTypeId = (Guid)(cboRoomType.SelectedValue ?? Guid.Empty)
                };

                var result = await _roomService.UpdateRoomAsync(RoomId.Value, updateDto);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Room updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage ?? "Failed to update room", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Create new room
                var createDto = new CreateRoomDto
                {
                    RoomNumber = txtRoomNumber.Text.Trim(),
                    Note = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim(),
                    Status = (RoomStatus)(cboStatus.SelectedItem ?? RoomStatus.Available),
                    RoomTypeId = (Guid)(cboRoomType.SelectedValue ?? Guid.Empty)
                };

                var result = await _roomService.CreateRoomAsync(createDto);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Room created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage ?? "Failed to create room", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRoomType.SelectedItem is RoomTypeResponseDto selectedRoomType)
            {
                txtPrice.Text = selectedRoomType.PricePerNight.ToString("N2"); // Format as currency with 2 decimals
            }
            else
            {
                txtPrice.Text = "0.00";
            }
        }
    }
}
