namespace HotelManagementIt008.Forms
{
    partial class RoomManagementForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblTitle = new Label();
            pnlFilters = new Panel();
            grpFilters = new GroupBox();
            label3 = new Label();
            lblFilterRoomType = new Label();
            lblFilterRoomNumber = new Label();
            nudPriceTo = new NumericUpDown();
            lblPriceTo = new Label();
            lblPriceRange = new Label();
            nudPriceFrom = new NumericUpDown();
            btnClearFilters = new Button();
            btnSearch = new Button();
            cboFilterStatus = new ComboBox();
            cboFilterRoomType = new ComboBox();
            txtFilterRoomNumber = new TextBox();
            pnlActions = new Panel();
            btnNext = new Button();
            lblPageInfo = new Label();
            btnPrevious = new Button();
            btnExportPDF = new Button();
            btnDeleteRoom = new Button();
            btnEditRoom = new Button();
            btnAddRoom = new Button();
            dgvRooms = new DataGridView();
            pnlTop.SuspendLayout();
            pnlFilters.SuspendLayout();
            grpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriceTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceFrom).BeginInit();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1110, 60);
            pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(63, 81, 181);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(271, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Room Management";
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.FromArgb(240, 244, 248);
            pnlFilters.Controls.Add(grpFilters);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 60);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(10);
            pnlFilters.Size = new Size(1110, 120);
            pnlFilters.TabIndex = 0;
            // 
            // grpFilters
            // 
            grpFilters.Controls.Add(label3);
            grpFilters.Controls.Add(lblFilterRoomType);
            grpFilters.Controls.Add(lblFilterRoomNumber);
            grpFilters.Controls.Add(nudPriceTo);
            grpFilters.Controls.Add(lblPriceTo);
            grpFilters.Controls.Add(lblPriceRange);
            grpFilters.Controls.Add(nudPriceFrom);
            grpFilters.Controls.Add(btnClearFilters);
            grpFilters.Controls.Add(btnSearch);
            grpFilters.Controls.Add(cboFilterStatus);
            grpFilters.Controls.Add(cboFilterRoomType);
            grpFilters.Controls.Add(txtFilterRoomNumber);
            grpFilters.Font = new Font("Segoe UI", 10F);
            grpFilters.Location = new Point(10, 10);
            grpFilters.Name = "grpFilters";
            grpFilters.Size = new Size(1070, 100);
            grpFilters.TabIndex = 1;
            grpFilters.TabStop = false;
            grpFilters.Text = "Search Filters";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(335, 35);
            label3.Name = "label3";
            label3.Size = new Size(47, 19);
            label3.TabIndex = 11;
            label3.Text = "Status";
            // 
            // lblFilterRoomType
            // 
            lblFilterRoomType.AutoSize = true;
            lblFilterRoomType.Location = new Point(186, 35);
            lblFilterRoomType.Name = "lblFilterRoomType";
            lblFilterRoomType.Size = new Size(77, 19);
            lblFilterRoomType.TabIndex = 10;
            lblFilterRoomType.Text = "Room Type";
            // 
            // lblFilterRoomNumber
            // 
            lblFilterRoomNumber.AutoSize = true;
            lblFilterRoomNumber.Location = new Point(15, 35);
            lblFilterRoomNumber.Name = "lblFilterRoomNumber";
            lblFilterRoomNumber.Size = new Size(97, 19);
            lblFilterRoomNumber.TabIndex = 9;
            lblFilterRoomNumber.Text = "Room number";
            // 
            // nudPriceTo
            // 
            nudPriceTo.BorderStyle = BorderStyle.FixedSingle;
            nudPriceTo.DecimalPlaces = 2;
            nudPriceTo.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            nudPriceTo.Location = new Point(642, 65);
            nudPriceTo.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPriceTo.Name = "nudPriceTo";
            nudPriceTo.Size = new Size(120, 25);
            nudPriceTo.TabIndex = 8;
            nudPriceTo.TextAlign = HorizontalAlignment.Right;
            nudPriceTo.ThousandsSeparator = true;
            nudPriceTo.Value = new decimal(new int[] { 10000000, 0, 0, 0 });
            // 
            // lblPriceTo
            // 
            lblPriceTo.AutoSize = true;
            lblPriceTo.ForeColor = Color.FromArgb(70, 70, 70);
            lblPriceTo.Location = new Point(605, 71);
            lblPriceTo.Name = "lblPriceTo";
            lblPriceTo.Size = new Size(22, 19);
            lblPriceTo.TabIndex = 7;
            lblPriceTo.Text = "to";
            // 
            // lblPriceRange
            // 
            lblPriceRange.AutoSize = true;
            lblPriceRange.ForeColor = Color.FromArgb(70, 70, 70);
            lblPriceRange.Location = new Point(542, 35);
            lblPriceRange.Name = "lblPriceRange";
            lblPriceRange.Size = new Size(83, 19);
            lblPriceRange.TabIndex = 6;
            lblPriceRange.Text = "Price Range:";
            // 
            // nudPriceFrom
            // 
            nudPriceFrom.BorderStyle = BorderStyle.FixedSingle;
            nudPriceFrom.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            nudPriceFrom.Location = new Point(642, 30);
            nudPriceFrom.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPriceFrom.Name = "nudPriceFrom";
            nudPriceFrom.Size = new Size(120, 25);
            nudPriceFrom.TabIndex = 5;
            nudPriceFrom.TextAlign = HorizontalAlignment.Right;
            nudPriceFrom.ThousandsSeparator = true;
            // 
            // btnClearFilters
            // 
            btnClearFilters.BackColor = Color.FromArgb(158, 158, 158);
            btnClearFilters.Cursor = Cursors.Hand;
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.Location = new Point(947, 35);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(100, 35);
            btnClearFilters.TabIndex = 4;
            btnClearFilters.Text = "Clear Filters";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(33, 150, 243);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(841, 35);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 35);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Items.AddRange(new object[] { "(All)", "Available", "Occupied" });
            cboFilterStatus.Location = new Point(335, 65);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new Size(150, 25);
            cboFilterStatus.TabIndex = 2;
            // 
            // cboFilterRoomType
            // 
            cboFilterRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterRoomType.FormattingEnabled = true;
            cboFilterRoomType.Items.AddRange(new object[] { "(All)", "A", "B", "C" });
            cboFilterRoomType.Location = new Point(175, 65);
            cboFilterRoomType.Name = "cboFilterRoomType";
            cboFilterRoomType.Size = new Size(150, 25);
            cboFilterRoomType.TabIndex = 1;
            // 
            // txtFilterRoomNumber
            // 
            txtFilterRoomNumber.Location = new Point(15, 65);
            txtFilterRoomNumber.Name = "txtFilterRoomNumber";
            txtFilterRoomNumber.Size = new Size(150, 25);
            txtFilterRoomNumber.TabIndex = 0;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.White;
            pnlActions.Controls.Add(btnNext);
            pnlActions.Controls.Add(lblPageInfo);
            pnlActions.Controls.Add(btnPrevious);
            pnlActions.Controls.Add(btnExportPDF);
            pnlActions.Controls.Add(btnDeleteRoom);
            pnlActions.Controls.Add(btnEditRoom);
            pnlActions.Controls.Add(btnAddRoom);
            pnlActions.Dock = DockStyle.Top;
            pnlActions.Location = new Point(0, 180);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10);
            pnlActions.Size = new Size(1110, 60);
            pnlActions.TabIndex = 2;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(957, 17);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(100, 30);
            btnNext.TabIndex = 6;
            btnNext.Text = "Next ▶";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Location = new Point(851, 25);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(71, 15);
            lblPageInfo.TabIndex = 5;
            lblPageInfo.Text = "Page 1 of 10";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrevious
            // 
            btnPrevious.Enabled = false;
            btnPrevious.Location = new Point(717, 17);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(100, 30);
            btnPrevious.TabIndex = 4;
            btnPrevious.Text = "◀ Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnExportPDF
            // 
            btnExportPDF.BackColor = Color.FromArgb(63, 81, 181);
            btnExportPDF.FlatStyle = FlatStyle.Flat;
            btnExportPDF.ForeColor = Color.White;
            btnExportPDF.Location = new Point(410, 15);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(120, 35);
            btnExportPDF.TabIndex = 3;
            btnExportPDF.Text = "📄 Export CSV";
            btnExportPDF.UseVisualStyleBackColor = false;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.BackColor = Color.FromArgb(244, 67, 54);
            btnDeleteRoom.Enabled = false;
            btnDeleteRoom.FlatStyle = FlatStyle.Flat;
            btnDeleteRoom.ForeColor = Color.White;
            btnDeleteRoom.Location = new Point(280, 15);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(120, 35);
            btnDeleteRoom.TabIndex = 2;
            btnDeleteRoom.Text = "🗑️ Delete";
            btnDeleteRoom.UseVisualStyleBackColor = false;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // btnEditRoom
            // 
            btnEditRoom.BackColor = Color.FromArgb(255, 152, 0);
            btnEditRoom.Enabled = false;
            btnEditRoom.FlatStyle = FlatStyle.Flat;
            btnEditRoom.ForeColor = Color.White;
            btnEditRoom.Location = new Point(150, 15);
            btnEditRoom.Name = "btnEditRoom";
            btnEditRoom.Size = new Size(120, 35);
            btnEditRoom.TabIndex = 1;
            btnEditRoom.Text = "✏️ Edit Room";
            btnEditRoom.UseVisualStyleBackColor = false;
            btnEditRoom.Click += btnEditRoom_Click;
            // 
            // btnAddRoom
            // 
            btnAddRoom.BackColor = Color.FromArgb(76, 175, 80);
            btnAddRoom.FlatStyle = FlatStyle.Flat;
            btnAddRoom.ForeColor = Color.White;
            btnAddRoom.Location = new Point(20, 15);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(120, 35);
            btnAddRoom.TabIndex = 0;
            btnAddRoom.Text = "➕ Add Room";
            btnAddRoom.UseVisualStyleBackColor = false;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvRooms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.BackgroundColor = Color.White;
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Dock = DockStyle.Fill;
            dgvRooms.Location = new Point(0, 240);
            dgvRooms.MultiSelect = false;
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(1110, 420);
            dgvRooms.TabIndex = 3;
            // 
            // RoomManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            ClientSize = new Size(1110, 660);
            Controls.Add(dgvRooms);
            Controls.Add(pnlActions);
            Controls.Add(pnlFilters);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RoomManagementForm";
            Text = "Room Management";
            Load += RoomManagementForm_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlFilters.ResumeLayout(false);
            grpFilters.ResumeLayout(false);
            grpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriceTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceFrom).EndInit();
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilters;
        private GroupBox grpFilters;
        private ComboBox cboFilterRoomType;
        private TextBox txtFilterRoomNumber;
        private Button btnSearch;
        private ComboBox cboFilterStatus;
        private Button btnClearFilters;
        private Panel pnlActions;
        private Button btnEditRoom;
        private Button btnAddRoom;
        private Button btnExportPDF;
        private Button btnDeleteRoom;
        private DataGridView dgvRooms;
        private Button btnPrevious;
        private Button btnNext;
        private Label lblPageInfo;
        private NumericUpDown nudPriceFrom;
        private Label lblPriceRange;
        private Label lblPriceTo;
        private NumericUpDown nudPriceTo;
        private Label label3;
        private Label lblFilterRoomType;
        private Label lblFilterRoomNumber;
        private Panel pnlTop;
        private Label lblTitle;
    }
}
