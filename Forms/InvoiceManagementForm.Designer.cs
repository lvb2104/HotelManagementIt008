namespace HotelManagementIt008.Forms
{
    partial class InvoiceManagementForm
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
            dtpFilterDate = new DateTimePicker();
            lblFilterDate = new Label();
            cboFilterStatus = new ComboBox();
            lblFilterStatus = new Label();
            btnClearFilters = new Button();
            btnSearch = new Button();
            pnlActions = new Panel();
            btnNext = new Button();
            lblPageInfo = new Label();
            btnPrevious = new Button();
            btnPrintInvoice = new Button();
            btnExportCSV = new Button();
            btnMarkAsPaid = new Button();
            dgvInvoices = new DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1090, 60);
            pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(63, 81, 181);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(283, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Invoice Management";
            // 
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.FromArgb(240, 244, 248);
            pnlFilters.Controls.Add(grpFilters);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 60);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(10);
            pnlFilters.Size = new Size(1090, 120);
            pnlFilters.TabIndex = 1;
            // 
            // grpFilters
            // 
            grpFilters.Controls.Add(dtpFilterDate);
            grpFilters.Controls.Add(lblFilterDate);
            grpFilters.Controls.Add(cboFilterStatus);
            grpFilters.Controls.Add(lblFilterStatus);
            grpFilters.Controls.Add(btnClearFilters);
            grpFilters.Controls.Add(btnSearch);
            grpFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFilters.Font = new Font("Segoe UI", 10F);
            grpFilters.Location = new Point(10, 10);
            grpFilters.Name = "grpFilters";
            grpFilters.Size = new Size(1070, 100);
            grpFilters.TabIndex = 1;
            grpFilters.TabStop = false;
            grpFilters.Text = "Search Filters";
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.Format = DateTimePickerFormat.Short;
            dtpFilterDate.Location = new Point(186, 65);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(150, 25);
            dtpFilterDate.TabIndex = 5;
            // 
            // lblFilterDate
            // 
            lblFilterDate.AutoSize = true;
            lblFilterDate.Location = new Point(186, 35);
            lblFilterDate.Name = "lblFilterDate";
            lblFilterDate.Size = new Size(37, 19);
            lblFilterDate.TabIndex = 4;
            lblFilterDate.Text = "Date";
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Location = new Point(15, 65);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new Size(150, 25);
            cboFilterStatus.TabIndex = 3;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Location = new Point(15, 35);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new Size(45, 19);
            lblFilterStatus.TabIndex = 2;
            lblFilterStatus.Text = "Status";
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
            btnClearFilters.TabIndex = 1;
            btnClearFilters.Text = "Clear Filters";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += btnClearFilters_Click;
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
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.White;
            pnlActions.Controls.Add(btnNext);
            pnlActions.Controls.Add(lblPageInfo);
            pnlActions.Controls.Add(btnPrevious);
            pnlActions.Controls.Add(btnExportCSV);
            pnlActions.Controls.Add(btnPrintInvoice);
            pnlActions.Controls.Add(btnMarkAsPaid);
            pnlActions.Dock = DockStyle.Top;
            pnlActions.Location = new Point(0, 180);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10);
            pnlActions.Size = new Size(1090, 60);
            pnlActions.TabIndex = 2;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Location = new Point(970, 15);
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
            lblPageInfo.Location = new Point(860, 23);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(71, 15);
            lblPageInfo.TabIndex = 5;
            lblPageInfo.Text = "Page 1 of 1";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Location = new Point(730, 15);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(100, 30);
            btnPrevious.TabIndex = 4;
            btnPrevious.Text = "◀ Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnPrintInvoice
            // 
            btnPrintInvoice.BackColor = Color.FromArgb(63, 81, 181);
            btnPrintInvoice.FlatStyle = FlatStyle.Flat;
            btnPrintInvoice.ForeColor = Color.White;
            btnPrintInvoice.Location = new Point(150, 15);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Size = new Size(120, 35);
            btnPrintInvoice.TabIndex = 3;
            btnPrintInvoice.Text = "📄 Print";
            btnPrintInvoice.UseVisualStyleBackColor = false;
            btnPrintInvoice.Click += btnPrintInvoice_Click;
            // 
            // btnExportCSV
            // 
            btnExportCSV.BackColor = Color.FromArgb(63, 81, 181);
            btnExportCSV.FlatStyle = FlatStyle.Flat;
            btnExportCSV.ForeColor = Color.White;
            btnExportCSV.Location = new Point(280, 15);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(120, 35);
            btnExportCSV.TabIndex = 4;
            btnExportCSV.Text = "📊 Export CSV";
            btnExportCSV.UseVisualStyleBackColor = false;
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // btnMarkAsPaid
            // 
            btnMarkAsPaid.BackColor = Color.FromArgb(76, 175, 80);
            btnMarkAsPaid.FlatStyle = FlatStyle.Flat;
            btnMarkAsPaid.ForeColor = Color.White;
            btnMarkAsPaid.Location = new Point(20, 15);
            btnMarkAsPaid.Name = "btnMarkAsPaid";
            btnMarkAsPaid.Size = new Size(120, 35);
            btnMarkAsPaid.TabIndex = 0;
            btnMarkAsPaid.Text = "✅ Mark as Paid";
            btnMarkAsPaid.UseVisualStyleBackColor = false;
            btnMarkAsPaid.Click += btnMarkAsPaid_Click;
            // 
            // 
            // dgvInvoices
            // 
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AllowUserToDeleteRows = false;
            dgvInvoices.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvInvoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoices.BackgroundColor = Color.White;
            dgvInvoices.BorderStyle = BorderStyle.None;
            dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoices.Dock = DockStyle.Fill;
            dgvInvoices.Location = new Point(0, 240);
            dgvInvoices.MultiSelect = false;
            dgvInvoices.Name = "dgvInvoices";
            dgvInvoices.ReadOnly = true;
            dgvInvoices.RowHeadersVisible = false;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.Size = new Size(1090, 360);
            dgvInvoices.TabIndex = 3;
            // 
            // InvoiceManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            ClientSize = new Size(1090, 660);
            Controls.Add(dgvInvoices);
            Controls.Add(pnlActions);
            Controls.Add(pnlFilters);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InvoiceManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Invoice Management";
            Load += InvoiceManagementForm_Load;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private Panel pnlFilters;
        private GroupBox grpFilters;
        private Button btnClearFilters;
        private Button btnSearch;
        private DataGridView dgvInvoices;
        private Panel pnlActions;
        private Button btnPrintInvoice;
        private Button btnExportCSV;
        private Button btnMarkAsPaid;
        private Button btnNext;
        private Button btnPrevious;
        private Label lblPageInfo;
        private ComboBox cboFilterStatus;
        private Label lblFilterStatus;
        private DateTimePicker dtpFilterDate;
        private Label lblFilterDate;
    }
}