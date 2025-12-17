using HotelManagementIt008.Dtos.Requests;
using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Services.Interfaces;
using HotelManagementIt008.Types;
using System.ComponentModel;

namespace HotelManagementIt008.Forms
{
    public partial class BookingDetailForm : Form
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        private readonly ICurrentUserService _currentUserService;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid? BookingId { get; set; }

        private BindingList<CreateParticipantDto> _participants = new BindingList<CreateParticipantDto>();

        public BookingDetailForm(IBookingService bookingService, IRoomService roomService, ICurrentUserService currentUserService)
        {
            InitializeComponent();
            _bookingService = bookingService;
            _roomService = roomService;
            _currentUserService = currentUserService;
            ConfigureParticipantsGrid();
        }

        private async void BookingDetailForm_Load(object sender, EventArgs e)
        {
            await LoadRooms();

            if (BookingId.HasValue)
            {
                this.Text = "Edit Booking";
                cboRooms.Enabled = false;
                dtpCheckIn.Enabled = false;
                dtpCheckOut.Enabled = false;
                await LoadBookingDetails();
            }
            else
            {
                this.Text = "Create Booking";
                dtpCheckIn.Value = DateTime.Today;
                dtpCheckOut.Value = DateTime.Today.AddDays(1);
            }
        }

        private void ConfigureParticipantsGrid()
        {
            dgvParticipants.AutoGenerateColumns = false;
            dgvParticipants.DataSource = _participants;
            dgvParticipants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParticipants.MultiSelect = false;

            dgvParticipants.Columns.Clear();


            dgvParticipants.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Width = 150
            });
            dgvParticipants.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Address",
                Width = 150
            });
            dgvParticipants.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdentityNumber",
                HeaderText = "Identity Number",
                Width = 120
            });

            var userTypeColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "UserType",
                HeaderText = "User Type",
                DataSource = Enum.GetValues(typeof(UserTypeType)),
                Width = 120
            };
            dgvParticipants.Columns.Add(userTypeColumn);
        }

        private async Task LoadRooms()
        {
            try
            {
                // Load all rooms for selection. Ideally filter by availability but for now load all.
                // Using GridifyQuery to get all (empty filter)
                var result = await _roomService.GetAllRoomsAsync(new Gridify.GridifyQuery { PageSize = 1000 });
                if (result.IsSuccess && result.Value != null)
                {
                    cboRooms.DataSource = result.Value.Data;
                    cboRooms.DisplayMember = "RoomNumber";
                    cboRooms.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show("Failed to load rooms: " + (result.ErrorMessage ?? "Unknown error"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading rooms: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadBookingDetails()
        {
            if (!BookingId.HasValue) return;

            try
            {
                var result = await _bookingService.GetBookingByIdAsync(BookingId.Value.ToString(), _currentUserService.UserId.ToString());
                if (result.IsSuccess && result.Value != null)
                {
                    var booking = result.Value;
                    
                    // Select room safely
                    if (booking.Room != null)
                    {
                        cboRooms.SelectedValue = booking.Room.Id;
                    }

                    dtpCheckIn.Value = booking.CheckInDate;
                    dtpCheckOut.Value = booking.CheckOutDate;

                    _participants.Clear();
                    if (booking.Participants != null)
                    {
                        foreach (var p in booking.Participants)
                        {
                            UserTypeType userType = UserTypeType.Local;
                            if (p.UserType != null && !string.IsNullOrEmpty(p.UserType.TypeName))
                            {
                                Enum.TryParse(p.UserType.TypeName, true, out userType);
                            }

                            _participants.Add(new CreateParticipantDto
                            {
                                FullName = p.Profile?.FullName ?? string.Empty,
                                Email = p.Email,
                                Address = p.Profile?.Address ?? string.Empty,
                                IdentityNumber = p.Profile?.IdentityNumber ?? string.Empty,
                                UserType = userType
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load booking details: " + (result.ErrorMessage ?? "Unknown error"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading booking details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            _participants.Add(new CreateParticipantDto { UserType = UserTypeType.Local }); // Default
        }

        private void btnRemoveParticipant_Click(object sender, EventArgs e)
        {
            if (dgvParticipants.SelectedRows.Count > 0)
            {
                var itemsToRemove = new List<CreateParticipantDto>();
                foreach (DataGridViewRow row in dgvParticipants.SelectedRows)
                {
                    if (row.DataBoundItem is CreateParticipantDto item)
                    {
                        itemsToRemove.Add(item);
                    }
                }
                
                foreach (var item in itemsToRemove)
                {
                    _participants.Remove(item);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cboRooms.SelectedValue == null)
            {
                MessageBox.Show("Please select a room.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpCheckIn.Value.Date >= dtpCheckOut.Value.Date)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_participants.Count == 0)
            {
                MessageBox.Show("Please add at least one participant.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate participants
            foreach (var p in _participants)
            {
                if (string.IsNullOrWhiteSpace(p.Email))
                {
                    MessageBox.Show("All participants must have an Email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                if (BookingId.HasValue)
                {
                    // Update
                    var dto = new UpdateBookingDto
                    {
                        RoomId = (Guid)cboRooms.SelectedValue,
                        CheckInDate = dtpCheckIn.Value,
                        CheckOutDate = dtpCheckOut.Value,
                        Participants = _participants.ToList()
                    };

                    var result = await _bookingService.UpdateBookingAsync(BookingId.Value.ToString(), dto, _currentUserService.UserId.ToString());
                    if (result.IsSuccess)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update booking: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Create
                    var dto = new CreateBookingDto
                    {
                        RoomId = (Guid)cboRooms.SelectedValue,
                        CheckInDate = dtpCheckIn.Value,
                        CheckOutDate = dtpCheckOut.Value,
                        Participants = _participants.ToList()
                    };

                    var result = await _bookingService.CreateBookingAsync(dto, _currentUserService.UserId.ToString());
                    if (result.IsSuccess)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create booking: " + result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
