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
            pnlTop = new Panel();
            lblTitle = new Label();
            pnlFilters = new Panel();
            dtpFilterDate = new DateTimePicker();
            lblFilterDate = new Label();
            cboFilterStatus = new ComboBox();
            lblFilterStatus = new Label();
            btnClearFilters = new Button();
            btnSearch = new Button();
            pnlCenter = new Panel();
            dgvInvoices = new DataGridView();
            pnlBottom = new Panel();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnPrevious = new Button();
            pnlActions = new Panel();
            btnMarkAsPaid = new Button();
            btnPrintInvoice = new Button();
            pnlTop.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
            pnlBottom.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1000, 60);
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
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.WhiteSmoke;
            pnlFilters.Controls.Add(dtpFilterDate);
            pnlFilters.Controls.Add(lblFilterDate);
            pnlFilters.Controls.Add(cboFilterStatus);
            pnlFilters.Controls.Add(lblFilterStatus);
            pnlFilters.Controls.Add(btnClearFilters);
            pnlFilters.Controls.Add(btnSearch);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 60);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1000, 70);
            pnlFilters.TabIndex = 1;
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.Format = DateTimePickerFormat.Short;
            dtpFilterDate.Location = new Point(280, 25);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(120, 23);
            dtpFilterDate.TabIndex = 5;
            // 
            // lblFilterDate
            // 
            lblFilterDate.AutoSize = true;
            lblFilterDate.Location = new Point(240, 29);
            lblFilterDate.Name = "lblFilterDate";
            lblFilterDate.Size = new Size(34, 15);
            lblFilterDate.TabIndex = 4;
            lblFilterDate.Text = "Date:";
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Location = new Point(70, 25);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new Size(150, 23);
            cboFilterStatus.TabIndex = 3;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Location = new Point(20, 29);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new Size(42, 15);
            lblFilterStatus.TabIndex = 2;
            lblFilterStatus.Text = "Status:";
            // 
            // btnClearFilters
            // 
            btnClearFilters.BackColor = Color.Gray;
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.Location = new Point(520, 20);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(80, 30);
            btnClearFilters.TabIndex = 1;
            btnClearFilters.Text = "Clear";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(63, 81, 181);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(420, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 30);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // pnlCenter
            // 
            pnlCenter.Controls.Add(dgvInvoices);
            pnlCenter.Dock = DockStyle.Fill;
            pnlCenter.Location = new Point(0, 130);
            pnlCenter.Name = "pnlCenter";
            pnlCenter.Padding = new Padding(20);
            pnlCenter.Size = new Size(1000, 410);
            pnlCenter.TabIndex = 2;
            // 
            // dgvInvoices
            // 
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AllowUserToDeleteRows = false;
            dgvInvoices.BackgroundColor = Color.White;
            dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoices.Dock = DockStyle.Fill;
            dgvInvoices.Location = new Point(20, 20);
            dgvInvoices.Name = "dgvInvoices";
            dgvInvoices.ReadOnly = true;
            dgvInvoices.RowTemplate.Height = 25;
            dgvInvoices.Size = new Size(960, 370);
            dgvInvoices.TabIndex = 0;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.White;
            pnlBottom.Controls.Add(lblPageInfo);
            pnlBottom.Controls.Add(btnNext);
            pnlBottom.Controls.Add(btnPrevious);
            pnlBottom.Controls.Add(pnlActions);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 540);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1000, 60);
            pnlBottom.TabIndex = 3;
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Location = new Point(130, 23);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(65, 15);
            lblPageInfo.TabIndex = 3;
            lblPageInfo.Text = "Page 1 of 1";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(220, 15);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(80, 30);
            btnNext.TabIndex = 2;
            btnNext.Text = "Next >";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(20, 15);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(80, 30);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "< Prev";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnMarkAsPaid);
            pnlActions.Controls.Add(btnPrintInvoice);
            pnlActions.Dock = DockStyle.Right;
            pnlActions.Location = new Point(500, 0);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(500, 60);
            pnlActions.TabIndex = 0;
            // 
            // btnMarkAsPaid
            // 
            btnMarkAsPaid.BackColor = Color.FromArgb(76, 175, 80);
            btnMarkAsPaid.FlatStyle = FlatStyle.Flat;
            btnMarkAsPaid.ForeColor = Color.White;
            btnMarkAsPaid.Location = new Point(240, 15);
            btnMarkAsPaid.Name = "btnMarkAsPaid";
            btnMarkAsPaid.Size = new Size(120, 35);
            btnMarkAsPaid.TabIndex = 1;
            btnMarkAsPaid.Text = "Mark as Paid";
            btnMarkAsPaid.UseVisualStyleBackColor = false;
            btnMarkAsPaid.Click += btnMarkAsPaid_Click;
            // 
            // btnPrintInvoice
            // 
            btnPrintInvoice.BackColor = Color.FromArgb(63, 81, 181);
            btnPrintInvoice.FlatStyle = FlatStyle.Flat;
            btnPrintInvoice.ForeColor = Color.White;
            btnPrintInvoice.Location = new Point(370, 15);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Size = new Size(110, 35);
            btnPrintInvoice.TabIndex = 0;
            btnPrintInvoice.Text = "🖨 Print Invoice";
            btnPrintInvoice.UseVisualStyleBackColor = false;
            btnPrintInvoice.Click += btnPrintInvoice_Click;
            // 
            // InvoiceManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(pnlCenter);
            Controls.Add(pnlBottom);
            Controls.Add(pnlFilters);
            Controls.Add(pnlTop);
            Name = "InvoiceManagementForm";
            Text = "Invoice Management";
            Load += InvoiceManagementForm_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private Panel pnlFilters;
        private Button btnClearFilters;
        private Button btnSearch;
        private Panel pnlCenter;
        private DataGridView dgvInvoices;
        private Panel pnlBottom;
        private Panel pnlActions;
        private Button btnPrintInvoice;
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