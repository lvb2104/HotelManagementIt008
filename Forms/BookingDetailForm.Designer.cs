namespace HotelManagementIt008.Forms
{
    partial class BookingDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpBookingDetails = new GroupBox();
            lblRoom = new Label();
            cboRooms = new ComboBox();
            lblCheckIn = new Label();
            dtpCheckIn = new DateTimePicker();
            lblCheckOut = new Label();
            dtpCheckOut = new DateTimePicker();
            grpParticipants = new GroupBox();
            dgvParticipants = new DataGridView();
            pnlParticipantActions = new Panel();
            rbSelectExisting = new RadioButton();
            rbCreateNew = new RadioButton();
            lblCustomer = new Label();
            cboCustomers = new ComboBox();
            btnAddParticipant = new Button();
            btnRemoveParticipant = new Button();
            pnlActions = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            grpBookingDetails.SuspendLayout();
            grpParticipants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).BeginInit();
            pnlParticipantActions.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // grpBookingDetails
            // 
            grpBookingDetails.Controls.Add(lblRoom);
            grpBookingDetails.Controls.Add(cboRooms);
            grpBookingDetails.Controls.Add(lblCheckIn);
            grpBookingDetails.Controls.Add(dtpCheckIn);
            grpBookingDetails.Controls.Add(lblCheckOut);
            grpBookingDetails.Controls.Add(dtpCheckOut);
            grpBookingDetails.Dock = DockStyle.Top;
            grpBookingDetails.Location = new Point(10, 10);
            grpBookingDetails.Name = "grpBookingDetails";
            grpBookingDetails.Size = new Size(780, 100);
            grpBookingDetails.TabIndex = 0;
            grpBookingDetails.TabStop = false;
            grpBookingDetails.Text = "Booking Details";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Location = new Point(20, 30);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(39, 15);
            lblRoom.TabIndex = 0;
            lblRoom.Text = "Room";
            // 
            // cboRooms
            // 
            cboRooms.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboRooms.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboRooms.FormattingEnabled = true;
            cboRooms.Location = new Point(20, 50);
            cboRooms.Name = "cboRooms";
            cboRooms.Size = new Size(200, 23);
            cboRooms.TabIndex = 1;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Location = new Point(250, 30);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(53, 15);
            lblCheckIn.TabIndex = 2;
            lblCheckIn.Text = "Check In";
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(250, 50);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(120, 23);
            dtpCheckIn.TabIndex = 3;
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Location = new Point(400, 30);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(63, 15);
            lblCheckOut.TabIndex = 4;
            lblCheckOut.Text = "Check Out";
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(400, 50);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(120, 23);
            dtpCheckOut.TabIndex = 5;
            // 
            // grpParticipants
            // 
            grpParticipants.Controls.Add(dgvParticipants);
            grpParticipants.Controls.Add(pnlParticipantActions);
            grpParticipants.Dock = DockStyle.Fill;
            grpParticipants.Location = new Point(10, 110);
            grpParticipants.Name = "grpParticipants";
            grpParticipants.Size = new Size(780, 280);
            grpParticipants.TabIndex = 1;
            grpParticipants.TabStop = false;
            grpParticipants.Text = "Participants";
            // 
            // dgvParticipants
            // 
            dgvParticipants.AllowUserToAddRows = false;
            dgvParticipants.AllowUserToDeleteRows = false;
            dgvParticipants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParticipants.BackgroundColor = Color.White;
            dgvParticipants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParticipants.Dock = DockStyle.Fill;
            dgvParticipants.Location = new Point(3, 19);
            dgvParticipants.Name = "dgvParticipants";
            dgvParticipants.RowHeadersVisible = false;
            dgvParticipants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParticipants.Size = new Size(774, 178);
            dgvParticipants.TabIndex = 0;
            // 
            // pnlParticipantActions
            // 
            pnlParticipantActions.Controls.Add(rbSelectExisting);
            pnlParticipantActions.Controls.Add(rbCreateNew);
            pnlParticipantActions.Controls.Add(lblCustomer);
            pnlParticipantActions.Controls.Add(cboCustomers);
            pnlParticipantActions.Controls.Add(btnAddParticipant);
            pnlParticipantActions.Controls.Add(btnRemoveParticipant);
            pnlParticipantActions.Dock = DockStyle.Bottom;
            pnlParticipantActions.Location = new Point(3, 197);
            pnlParticipantActions.Name = "pnlParticipantActions";
            pnlParticipantActions.Size = new Size(774, 80);
            pnlParticipantActions.TabIndex = 1;
            // 
            // rbSelectExisting
            // 
            rbSelectExisting.AutoSize = true;
            rbSelectExisting.Checked = true;
            rbSelectExisting.Location = new Point(10, 10);
            rbSelectExisting.Name = "rbSelectExisting";
            rbSelectExisting.Size = new Size(154, 19);
            rbSelectExisting.TabIndex = 0;
            rbSelectExisting.TabStop = true;
            rbSelectExisting.Text = "Select Existing Customer";
            rbSelectExisting.UseVisualStyleBackColor = true;
            rbSelectExisting.CheckedChanged += rbSelectExisting_CheckedChanged;
            // 
            // rbCreateNew
            // 
            rbCreateNew.AutoSize = true;
            rbCreateNew.Location = new Point(182, 10);
            rbCreateNew.Name = "rbCreateNew";
            rbCreateNew.Size = new Size(141, 19);
            rbCreateNew.TabIndex = 1;
            rbCreateNew.Text = "Create New Customer";
            rbCreateNew.UseVisualStyleBackColor = true;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(10, 35);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(59, 15);
            lblCustomer.TabIndex = 2;
            lblCustomer.Text = "Customer";
            // 
            // cboCustomers
            // 
            cboCustomers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCustomers.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCustomers.FormattingEnabled = true;
            cboCustomers.Location = new Point(75, 32);
            cboCustomers.Name = "cboCustomers";
            cboCustomers.Size = new Size(350, 23);
            cboCustomers.TabIndex = 3;
            // 
            // btnAddParticipant
            // 
            btnAddParticipant.Location = new Point(435, 30);
            btnAddParticipant.Name = "btnAddParticipant";
            btnAddParticipant.Size = new Size(120, 30);
            btnAddParticipant.TabIndex = 4;
            btnAddParticipant.Text = "Add Participant";
            btnAddParticipant.UseVisualStyleBackColor = true;
            btnAddParticipant.Click += btnAddParticipant_Click;
            // 
            // btnRemoveParticipant
            // 
            btnRemoveParticipant.Location = new Point(565, 30);
            btnRemoveParticipant.Name = "btnRemoveParticipant";
            btnRemoveParticipant.Size = new Size(120, 30);
            btnRemoveParticipant.TabIndex = 5;
            btnRemoveParticipant.Text = "Remove Selected";
            btnRemoveParticipant.UseVisualStyleBackColor = true;
            btnRemoveParticipant.Click += btnRemoveParticipant_Click;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnSave);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(10, 390);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(780, 50);
            pnlActions.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(610, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(700, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // BookingDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(grpParticipants);
            Controls.Add(pnlActions);
            Controls.Add(grpBookingDetails);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookingDetailForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Booking Detail";
            Load += BookingDetailForm_Load;
            grpBookingDetails.ResumeLayout(false);
            grpBookingDetails.PerformLayout();
            grpParticipants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).EndInit();
            pnlParticipantActions.ResumeLayout(false);
            pnlParticipantActions.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBookingDetails;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cboRooms;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.GroupBox grpParticipants;
        private System.Windows.Forms.DataGridView dgvParticipants;
        private System.Windows.Forms.Panel pnlParticipantActions;
        private System.Windows.Forms.RadioButton rbSelectExisting;
        private System.Windows.Forms.RadioButton rbCreateNew;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomers;
        private System.Windows.Forms.Button btnAddParticipant;
        private System.Windows.Forms.Button btnRemoveParticipant;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
