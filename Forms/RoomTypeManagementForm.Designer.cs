namespace HotelManagementIt008.Forms
{
    partial class RoomTypeManagementForm
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
            lblFilterName = new Label();
            txtFilterName = new TextBox();
            lblPriceRange = new Label();
            nudPriceFrom = new NumericUpDown();
            lblPriceTo = new Label();
            nudPriceTo = new NumericUpDown();
            btnSearch = new Button();
            btnClearFilters = new Button();
            pnlActions = new Panel();
            btnNext = new Button();
            lblPageInfo = new Label();
            btnPrevious = new Button();
            btnExport = new Button();
            btnDeleteRoomType = new Button();
            btnEditRoomType = new Button();
            btnAddRoomType = new Button();
            dgvRoomTypes = new DataGridView();
            pnlTop.SuspendLayout();
            pnlFilters.SuspendLayout();
            grpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriceFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceTo).BeginInit();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomTypes).BeginInit();
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
            lblTitle.Size = new Size(340, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Room Type Management";
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
            pnlFilters.TabIndex = 1;
            // 
            // grpFilters
            // 
            grpFilters.Controls.Add(lblFilterName);
            grpFilters.Controls.Add(txtFilterName);
            grpFilters.Controls.Add(lblPriceRange);
            grpFilters.Controls.Add(nudPriceFrom);
            grpFilters.Controls.Add(lblPriceTo);
            grpFilters.Controls.Add(nudPriceTo);
            grpFilters.Controls.Add(btnSearch);
            grpFilters.Controls.Add(btnClearFilters);
            grpFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFilters.Font = new Font("Segoe UI", 10F);
            grpFilters.Location = new Point(10, 10);
            grpFilters.Name = "grpFilters";
            grpFilters.Size = new Size(1070, 100);
            grpFilters.TabIndex = 0;
            grpFilters.TabStop = false;
            grpFilters.Text = "Search Filters";
            // 
            // lblFilterName
            // 
            lblFilterName.AutoSize = true;
            lblFilterName.Location = new Point(15, 35);
            lblFilterName.Name = "lblFilterName";
            lblFilterName.Size = new Size(45, 19);
            lblFilterName.TabIndex = 0;
            lblFilterName.Text = "Name";
            // 
            // txtFilterName
            // 
            txtFilterName.Location = new Point(15, 65);
            txtFilterName.Name = "txtFilterName";
            txtFilterName.Size = new Size(200, 25);
            txtFilterName.TabIndex = 1;
            // 
            // lblPriceRange
            // 
            lblPriceRange.AutoSize = true;
            lblPriceRange.ForeColor = Color.FromArgb(70, 70, 70);
            lblPriceRange.Location = new Point(250, 35);
            lblPriceRange.Name = "lblPriceRange";
            lblPriceRange.Size = new Size(83, 19);
            lblPriceRange.TabIndex = 2;
            lblPriceRange.Text = "Price Range:";
            // 
            // nudPriceFrom
            // 
            nudPriceFrom.BorderStyle = BorderStyle.FixedSingle;
            nudPriceFrom.DecimalPlaces = 2;
            nudPriceFrom.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            nudPriceFrom.Location = new Point(350, 30);
            nudPriceFrom.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPriceFrom.Name = "nudPriceFrom";
            nudPriceFrom.Size = new Size(120, 25);
            nudPriceFrom.TabIndex = 3;
            nudPriceFrom.TextAlign = HorizontalAlignment.Right;
            nudPriceFrom.ThousandsSeparator = true;
            // 
            // lblPriceTo
            // 
            lblPriceTo.AutoSize = true;
            lblPriceTo.ForeColor = Color.FromArgb(70, 70, 70);
            lblPriceTo.Location = new Point(490, 36);
            lblPriceTo.Name = "lblPriceTo";
            lblPriceTo.Size = new Size(22, 19);
            lblPriceTo.TabIndex = 4;
            lblPriceTo.Text = "to";
            // 
            // nudPriceTo
            // 
            nudPriceTo.BorderStyle = BorderStyle.FixedSingle;
            nudPriceTo.DecimalPlaces = 2;
            nudPriceTo.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            nudPriceTo.Location = new Point(350, 65);
            nudPriceTo.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPriceTo.Name = "nudPriceTo";
            nudPriceTo.Size = new Size(120, 25);
            nudPriceTo.TabIndex = 5;
            nudPriceTo.TextAlign = HorizontalAlignment.Right;
            nudPriceTo.ThousandsSeparator = true;
            nudPriceTo.Value = new decimal(new int[] { 10000000, 0, 0, 0 });
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(33, 150, 243);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(841, 35);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 35);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClearFilters
            // 
            btnClearFilters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearFilters.BackColor = Color.FromArgb(158, 158, 158);
            btnClearFilters.Cursor = Cursors.Hand;
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.Location = new Point(947, 35);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(100, 35);
            btnClearFilters.TabIndex = 7;
            btnClearFilters.Text = "Clear Filters";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.White;
            pnlActions.Controls.Add(btnNext);
            pnlActions.Controls.Add(lblPageInfo);
            pnlActions.Controls.Add(btnPrevious);
            pnlActions.Controls.Add(btnExport);
            pnlActions.Controls.Add(btnDeleteRoomType);
            pnlActions.Controls.Add(btnEditRoomType);
            pnlActions.Controls.Add(btnAddRoomType);
            pnlActions.Dock = DockStyle.Top;
            pnlActions.Location = new Point(0, 180);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10);
            pnlActions.Size = new Size(1110, 60);
            pnlActions.TabIndex = 2;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            lblPageInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPageInfo.AutoSize = true;
            lblPageInfo.Location = new Point(851, 25);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(65, 15);
            lblPageInfo.TabIndex = 5;
            lblPageInfo.Text = "Page 1 of 1";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Enabled = false;
            btnPrevious.Location = new Point(717, 17);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(100, 30);
            btnPrevious.TabIndex = 4;
            btnPrevious.Text = "◀ Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(63, 81, 181);
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(428, 15);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(120, 35);
            btnExport.TabIndex = 3;
            btnExport.Text = "📄 Export CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnDeleteRoomType
            // 
            btnDeleteRoomType.BackColor = Color.FromArgb(244, 67, 54);
            btnDeleteRoomType.Enabled = false;
            btnDeleteRoomType.FlatStyle = FlatStyle.Flat;
            btnDeleteRoomType.ForeColor = Color.White;
            btnDeleteRoomType.Location = new Point(302, 15);
            btnDeleteRoomType.Name = "btnDeleteRoomType";
            btnDeleteRoomType.Size = new Size(120, 35);
            btnDeleteRoomType.TabIndex = 2;
            btnDeleteRoomType.Text = "🗑️ Delete";
            btnDeleteRoomType.UseVisualStyleBackColor = false;
            btnDeleteRoomType.Click += btnDeleteRoomType_Click;
            // 
            // btnEditRoomType
            // 
            btnEditRoomType.BackColor = Color.FromArgb(255, 152, 0);
            btnEditRoomType.Enabled = false;
            btnEditRoomType.FlatStyle = FlatStyle.Flat;
            btnEditRoomType.ForeColor = Color.White;
            btnEditRoomType.Location = new Point(176, 15);
            btnEditRoomType.Name = "btnEditRoomType";
            btnEditRoomType.Size = new Size(120, 35);
            btnEditRoomType.TabIndex = 1;
            btnEditRoomType.Text = "✏️ Edit";
            btnEditRoomType.UseVisualStyleBackColor = false;
            btnEditRoomType.Click += btnEditRoomType_Click;
            // 
            // btnAddRoomType
            // 
            btnAddRoomType.BackColor = Color.FromArgb(76, 175, 80);
            btnAddRoomType.FlatStyle = FlatStyle.Flat;
            btnAddRoomType.ForeColor = Color.White;
            btnAddRoomType.Location = new Point(20, 15);
            btnAddRoomType.Name = "btnAddRoomType";
            btnAddRoomType.Size = new Size(150, 35);
            btnAddRoomType.TabIndex = 0;
            btnAddRoomType.Text = "➕ Add Room Type";
            btnAddRoomType.UseVisualStyleBackColor = false;
            btnAddRoomType.Click += btnAddRoomType_Click;
            // 
            // dgvRoomTypes
            // 
            dgvRoomTypes.AllowUserToAddRows = false;
            dgvRoomTypes.AllowUserToDeleteRows = false;
            dgvRoomTypes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvRoomTypes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRoomTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoomTypes.BackgroundColor = Color.White;
            dgvRoomTypes.BorderStyle = BorderStyle.None;
            dgvRoomTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomTypes.Dock = DockStyle.Fill;
            dgvRoomTypes.Location = new Point(0, 240);
            dgvRoomTypes.MultiSelect = false;
            dgvRoomTypes.Name = "dgvRoomTypes";
            dgvRoomTypes.ReadOnly = true;
            dgvRoomTypes.RowHeadersVisible = false;
            dgvRoomTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoomTypes.Size = new Size(1110, 420);
            dgvRoomTypes.TabIndex = 3;
            // 
            // RoomTypeManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            ClientSize = new Size(1110, 660);
            Controls.Add(dgvRoomTypes);
            Controls.Add(pnlActions);
            Controls.Add(pnlFilters);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RoomTypeManagementForm";
            Text = "Room Type Management";
            Load += RoomTypeManagementForm_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlFilters.ResumeLayout(false);
            grpFilters.ResumeLayout(false);
            grpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriceFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceTo).EndInit();
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomTypes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private Panel pnlFilters;
        private GroupBox grpFilters;
        private Label lblFilterName;
        private TextBox txtFilterName;
        private Label lblPriceRange;
        private NumericUpDown nudPriceFrom;
        private Label lblPriceTo;
        private NumericUpDown nudPriceTo;
        private Button btnSearch;
        private Button btnClearFilters;
        private Panel pnlActions;
        private Button btnNext;
        private Label lblPageInfo;
        private Button btnPrevious;
        private Button btnExport;
        private Button btnDeleteRoomType;
        private Button btnEditRoomType;
        private Button btnAddRoomType;
        private DataGridView dgvRoomTypes;
    }
}