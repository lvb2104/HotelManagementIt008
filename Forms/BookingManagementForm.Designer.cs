namespace HotelManagementIt008.Forms
{
    partial class BookingManagementForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.lblFilterCheckOut = new System.Windows.Forms.Label();
            this.dtpFilterCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblFilterCheckIn = new System.Windows.Forms.Label();
            this.dtpFilterCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblFilterRoomNumber = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFilterRoomNumber = new System.Windows.Forms.TextBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnPrintBooking = new System.Windows.Forms.Button();
            this.btnDeleteBooking = new System.Windows.Forms.Button();
            this.btnEditBooking = new System.Windows.Forms.Button();
            this.btnAddBooking = new System.Windows.Forms.Button();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1110, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(283, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Booking Management";
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlFilters.Controls.Add(this.grpFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFilters.Size = new System.Drawing.Size(1110, 120);
            this.pnlFilters.TabIndex = 0;
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.lblFilterCheckOut);
            this.grpFilters.Controls.Add(this.dtpFilterCheckOut);
            this.grpFilters.Controls.Add(this.lblFilterCheckIn);
            this.grpFilters.Controls.Add(this.dtpFilterCheckIn);
            this.grpFilters.Controls.Add(this.lblFilterRoomNumber);
            this.grpFilters.Controls.Add(this.btnClearFilters);
            this.grpFilters.Controls.Add(this.btnSearch);
            this.grpFilters.Controls.Add(this.txtFilterRoomNumber);
            this.grpFilters.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpFilters.Location = new System.Drawing.Point(10, 10);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(1070, 100);
            this.grpFilters.TabIndex = 1;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Search Filters";
            // 
            // lblFilterCheckOut
            // 
            this.lblFilterCheckOut.AutoSize = true;
            this.lblFilterCheckOut.Location = new System.Drawing.Point(370, 35);
            this.lblFilterCheckOut.Name = "lblFilterCheckOut";
            this.lblFilterCheckOut.Size = new System.Drawing.Size(73, 19);
            this.lblFilterCheckOut.TabIndex = 13;
            this.lblFilterCheckOut.Text = "Check Out";
            // 
            // dtpFilterCheckOut
            // 
            this.dtpFilterCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterCheckOut.Location = new System.Drawing.Point(370, 65);
            this.dtpFilterCheckOut.Name = "dtpFilterCheckOut";
            this.dtpFilterCheckOut.ShowCheckBox = true;
            this.dtpFilterCheckOut.Size = new System.Drawing.Size(150, 25);
            this.dtpFilterCheckOut.TabIndex = 12;
            // 
            // lblFilterCheckIn
            // 
            this.lblFilterCheckIn.AutoSize = true;
            this.lblFilterCheckIn.Location = new System.Drawing.Point(186, 35);
            this.lblFilterCheckIn.Name = "lblFilterCheckIn";
            this.lblFilterCheckIn.Size = new System.Drawing.Size(61, 19);
            this.lblFilterCheckIn.TabIndex = 11;
            this.lblFilterCheckIn.Text = "Check In";
            // 
            // dtpFilterCheckIn
            // 
            this.dtpFilterCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterCheckIn.Location = new System.Drawing.Point(186, 65);
            this.dtpFilterCheckIn.Name = "dtpFilterCheckIn";
            this.dtpFilterCheckIn.ShowCheckBox = true;
            this.dtpFilterCheckIn.Size = new System.Drawing.Size(150, 25);
            this.dtpFilterCheckIn.TabIndex = 10;
            // 
            // lblFilterRoomNumber
            // 
            this.lblFilterRoomNumber.AutoSize = true;
            this.lblFilterRoomNumber.Location = new System.Drawing.Point(15, 35);
            this.lblFilterRoomNumber.Name = "lblFilterRoomNumber";
            this.lblFilterRoomNumber.Size = new System.Drawing.Size(97, 19);
            this.lblFilterRoomNumber.TabIndex = 9;
            this.lblFilterRoomNumber.Text = "Room number";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnClearFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(947, 35);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(100, 35);
            this.btnClearFilters.TabIndex = 4;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(841, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFilterRoomNumber
            // 
            this.txtFilterRoomNumber.Location = new System.Drawing.Point(15, 65);
            this.txtFilterRoomNumber.Name = "txtFilterRoomNumber";
            this.txtFilterRoomNumber.Size = new System.Drawing.Size(150, 25);
            this.txtFilterRoomNumber.TabIndex = 0;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.Controls.Add(this.btnNext);
            this.pnlActions.Controls.Add(this.lblPageInfo);
            this.pnlActions.Controls.Add(this.btnPrevious);
            this.pnlActions.Controls.Add(this.btnPrintBooking);
            this.pnlActions.Controls.Add(this.btnDeleteBooking);
            this.pnlActions.Controls.Add(this.btnEditBooking);
            this.pnlActions.Controls.Add(this.btnAddBooking);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 120);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActions.Size = new System.Drawing.Size(1110, 60);
            this.pnlActions.TabIndex = 2;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(957, 17);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 30);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next ▶";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(851, 25);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(71, 15);
            this.lblPageInfo.TabIndex = 5;
            this.lblPageInfo.Text = "Page 1 of 10";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.Location = new System.Drawing.Point(717, 17);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 30);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "◀ Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnPrintBooking
            // 
            this.btnPrintBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnPrintBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBooking.ForeColor = System.Drawing.Color.White;
            this.btnPrintBooking.Location = new System.Drawing.Point(410, 15);
            this.btnPrintBooking.Name = "btnPrintBooking";
            this.btnPrintBooking.Size = new System.Drawing.Size(120, 35);
            this.btnPrintBooking.TabIndex = 3;
            this.btnPrintBooking.Text = "📄 Print";
            this.btnPrintBooking.UseVisualStyleBackColor = false;
            this.btnPrintBooking.Click += new System.EventHandler(this.btnPrintBooking_Click);
            // 
            // btnDeleteBooking
            // 
            this.btnDeleteBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnDeleteBooking.Enabled = false;
            this.btnDeleteBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBooking.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBooking.Location = new System.Drawing.Point(280, 15);
            this.btnDeleteBooking.Name = "btnDeleteBooking";
            this.btnDeleteBooking.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteBooking.TabIndex = 2;
            this.btnDeleteBooking.Text = "🗑️ Delete";
            this.btnDeleteBooking.UseVisualStyleBackColor = false;
            this.btnDeleteBooking.Click += new System.EventHandler(this.btnDeleteBooking_Click);
            // 
            // btnEditBooking
            // 
            this.btnEditBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnEditBooking.Enabled = false;
            this.btnEditBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBooking.ForeColor = System.Drawing.Color.White;
            this.btnEditBooking.Location = new System.Drawing.Point(150, 15);
            this.btnEditBooking.Name = "btnEditBooking";
            this.btnEditBooking.Size = new System.Drawing.Size(120, 35);
            this.btnEditBooking.TabIndex = 1;
            this.btnEditBooking.Text = "✏️ Edit";
            this.btnEditBooking.UseVisualStyleBackColor = false;
            this.btnEditBooking.Click += new System.EventHandler(this.btnEditBooking_Click);
            // 
            // btnAddBooking
            // 
            this.btnAddBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnAddBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBooking.ForeColor = System.Drawing.Color.White;
            this.btnAddBooking.Location = new System.Drawing.Point(20, 15);
            this.btnAddBooking.Name = "btnAddBooking";
            this.btnAddBooking.Size = new System.Drawing.Size(120, 35);
            this.btnAddBooking.TabIndex = 0;
            this.btnAddBooking.Text = "➕ Add Booking";
            this.btnAddBooking.UseVisualStyleBackColor = false;
            this.btnAddBooking.Click += new System.EventHandler(this.btnAddBooking_Click);
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.BackgroundColor = System.Drawing.Color.White;
            this.dgvBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookings.Location = new System.Drawing.Point(0, 180);
            this.dgvBookings.MultiSelect = false;
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.RowHeadersVisible = false;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(1110, 480);
            this.dgvBookings.TabIndex = 3;
            // 
            // BookingManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1110, 660);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookingManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking Management";
            this.Load += new System.EventHandler(this.BookingManagementForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.TextBox txtFilterRoomNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnEditBooking;
        private System.Windows.Forms.Button btnAddBooking;
        private System.Windows.Forms.Button btnPrintBooking;
        private System.Windows.Forms.Button btnDeleteBooking;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblFilterRoomNumber;
        private System.Windows.Forms.Label lblFilterCheckIn;
        private System.Windows.Forms.DateTimePicker dtpFilterCheckIn;
        private System.Windows.Forms.Label lblFilterCheckOut;
        private System.Windows.Forms.DateTimePicker dtpFilterCheckOut;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
    }
}