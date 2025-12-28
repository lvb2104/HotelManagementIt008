namespace HotelManagementIt008.Forms
{
    partial class PaymentManagementForm
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
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.lblFilterDate = new System.Windows.Forms.Label();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.cboFilterMethod = new System.Windows.Forms.ComboBox();
            this.lblFilterMethod = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnPrintPayment = new System.Windows.Forms.Button();
            this.btnMergePayments = new System.Windows.Forms.Button();
            this.btnDeletePayment = new System.Windows.Forms.Button();
            this.btnEditPayment = new System.Windows.Forms.Button();
            this.btnMarkAsPaid = new System.Windows.Forms.Button();
            this.btnMarkAsPending = new System.Windows.Forms.Button();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1090, 60);
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
            this.lblTitle.Text = "Payment Management";
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlFilters.Controls.Add(this.grpFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 60);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFilters.Size = new System.Drawing.Size(1090, 120);
            this.pnlFilters.TabIndex = 1;
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.dtpFilterDate);
            this.grpFilters.Controls.Add(this.lblFilterDate);
            this.grpFilters.Controls.Add(this.cboFilterStatus);
            this.grpFilters.Controls.Add(this.lblFilterStatus);
            this.grpFilters.Controls.Add(this.cboFilterMethod);
            this.grpFilters.Controls.Add(this.lblFilterMethod);
            this.grpFilters.Controls.Add(this.btnClearFilters);
            this.grpFilters.Controls.Add(this.btnSearch);
            this.grpFilters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.grpFilters.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpFilters.Location = new System.Drawing.Point(10, 10);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(1070, 100);
            this.grpFilters.TabIndex = 1;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Search Filters";
            // 
            // dtpFilterDate
            // 
            this.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterDate.Location = new System.Drawing.Point(360, 45);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.ShowCheckBox = true;
            this.dtpFilterDate.Size = new System.Drawing.Size(150, 25);
            this.dtpFilterDate.TabIndex = 7;
            // 
            // lblFilterDate
            // 
            this.lblFilterDate.AutoSize = true;
            this.lblFilterDate.Location = new System.Drawing.Point(360, 23);
            this.lblFilterDate.Name = "lblFilterDate";
            this.lblFilterDate.Size = new System.Drawing.Size(84, 19);
            this.lblFilterDate.TabIndex = 6;
            this.lblFilterDate.Text = "Created Date:";
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Location = new System.Drawing.Point(190, 45);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(150, 25);
            this.cboFilterStatus.TabIndex = 5;
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Location = new System.Drawing.Point(190, 23);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(50, 19);
            this.lblFilterStatus.TabIndex = 4;
            this.lblFilterStatus.Text = "Status:";
            // 
            // cboFilterMethod
            // 
            this.cboFilterMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterMethod.FormattingEnabled = true;
            this.cboFilterMethod.Location = new System.Drawing.Point(20, 45);
            this.cboFilterMethod.Name = "cboFilterMethod";
            this.cboFilterMethod.Size = new System.Drawing.Size(150, 25);
            this.cboFilterMethod.TabIndex = 3;
            // 
            // lblFilterMethod
            // 
            this.lblFilterMethod.AutoSize = true;
            this.lblFilterMethod.Location = new System.Drawing.Point(20, 23);
            this.lblFilterMethod.Name = "lblFilterMethod";
            this.lblFilterMethod.Size = new System.Drawing.Size(59, 19);
            this.lblFilterMethod.TabIndex = 2;
            this.lblFilterMethod.Text = "Method:";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnClearFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(947, 35);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(100, 35);
            this.btnClearFilters.TabIndex = 1;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(841, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.Controls.Add(this.btnMarkAsPending);
            this.pnlActions.Controls.Add(this.btnMarkAsPaid);
            this.pnlActions.Controls.Add(this.btnNext);
            this.pnlActions.Controls.Add(this.lblPageInfo);
            this.pnlActions.Controls.Add(this.btnPrevious);
            this.pnlActions.Controls.Add(this.btnExportCSV);
            this.pnlActions.Controls.Add(this.btnPrintPayment);
            this.pnlActions.Controls.Add(this.btnMergePayments);
            this.pnlActions.Controls.Add(this.btnDeletePayment);
            this.pnlActions.Controls.Add(this.btnEditPayment);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 180);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActions.Size = new System.Drawing.Size(1090, 60);
            this.pnlActions.TabIndex = 2;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.Location = new System.Drawing.Point(980, 18);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 30);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next ▶";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(860, 23);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(71, 15);
            this.lblPageInfo.TabIndex = 7;
            this.lblPageInfo.Text = "Page 1 of 1";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnPrevious.Location = new System.Drawing.Point(860, 18);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 30);
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.Text = "◀ Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.ForeColor = System.Drawing.Color.White;
            this.btnExportCSV.Location = new System.Drawing.Point(540, 15);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(120, 35);
            this.btnExportCSV.TabIndex = 5;
            this.btnExportCSV.Text = "📊 Export CSV";
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnPrintPayment
            // 
            this.btnPrintPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnPrintPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPayment.ForeColor = System.Drawing.Color.White;
            this.btnPrintPayment.Location = new System.Drawing.Point(410, 15);
            this.btnPrintPayment.Name = "btnPrintPayment";
            this.btnPrintPayment.Size = new System.Drawing.Size(120, 35);
            this.btnPrintPayment.TabIndex = 4;
            this.btnPrintPayment.Text = "📄 Print";
            this.btnPrintPayment.UseVisualStyleBackColor = false;
            this.btnPrintPayment.Click += new System.EventHandler(this.btnPrintPayment_Click);
            // 
            // btnMergePayments
            // 
            this.btnMergePayments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnMergePayments.Enabled = false;
            this.btnMergePayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMergePayments.ForeColor = System.Drawing.Color.White;
            this.btnMergePayments.Location = new System.Drawing.Point(280, 15);
            this.btnMergePayments.Name = "btnMergePayments";
            this.btnMergePayments.Size = new System.Drawing.Size(120, 35);
            this.btnMergePayments.TabIndex = 3;
            this.btnMergePayments.Text = "🔗 Merge";
            this.btnMergePayments.UseVisualStyleBackColor = false;
            this.btnMergePayments.Click += new System.EventHandler(this.btnMergePayments_Click);
            // 
            // btnDeletePayment
            // 
            this.btnDeletePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnDeletePayment.Enabled = false;
            this.btnDeletePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePayment.ForeColor = System.Drawing.Color.White;
            this.btnDeletePayment.Location = new System.Drawing.Point(150, 15);
            this.btnDeletePayment.Name = "btnDeletePayment";
            this.btnDeletePayment.Size = new System.Drawing.Size(120, 35);
            this.btnDeletePayment.TabIndex = 2;
            this.btnDeletePayment.Text = "🗑️ Delete";
            this.btnDeletePayment.UseVisualStyleBackColor = false;
            this.btnDeletePayment.Click += new System.EventHandler(this.btnDeletePayment_Click);
            // 
            // btnMarkAsPaid
            // 
            this.btnMarkAsPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnMarkAsPaid.Enabled = false;
            this.btnMarkAsPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAsPaid.ForeColor = System.Drawing.Color.White;
            this.btnMarkAsPaid.Location = new System.Drawing.Point(670, 15);
            this.btnMarkAsPaid.Name = "btnMarkAsPaid";
            this.btnMarkAsPaid.Size = new System.Drawing.Size(120, 35);
            this.btnMarkAsPaid.TabIndex = 6;
            this.btnMarkAsPaid.Text = "✅ Paid";
            this.btnMarkAsPaid.UseVisualStyleBackColor = false;
            this.btnMarkAsPaid.Click += new System.EventHandler(this.btnMarkAsPaid_Click);
            // 
            // btnMarkAsPending
            // 
            this.btnMarkAsPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnMarkAsPending.Enabled = false;
            this.btnMarkAsPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAsPending.ForeColor = System.Drawing.Color.White;
            this.btnMarkAsPending.Location = new System.Drawing.Point(800, 15);
            this.btnMarkAsPending.Name = "btnMarkAsPending";
            this.btnMarkAsPending.Size = new System.Drawing.Size(120, 35);
            this.btnMarkAsPending.TabIndex = 7;
            this.btnMarkAsPending.Text = "⏳ Pending";
            this.btnMarkAsPending.UseVisualStyleBackColor = false;
            this.btnMarkAsPending.Click += new System.EventHandler(this.btnMarkAsPending_Click);
            // 
            // btnEditPayment
            // 
            this.btnEditPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnEditPayment.Enabled = false;
            this.btnEditPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPayment.ForeColor = System.Drawing.Color.White;
            this.btnEditPayment.Location = new System.Drawing.Point(20, 15);
            this.btnEditPayment.Name = "btnEditPayment";
            this.btnEditPayment.Size = new System.Drawing.Size(120, 35);
            this.btnEditPayment.TabIndex = 1;
            this.btnEditPayment.Text = "✏️ Edit";
            this.btnEditPayment.UseVisualStyleBackColor = false;
            this.btnEditPayment.Click += new System.EventHandler(this.btnEditPayment_Click);
            // 
            // dgvPayments
            // 
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayments.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayments.Location = new System.Drawing.Point(0, 240);
            this.dgvPayments.MultiSelect = false;
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.RowHeadersVisible = false;
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayments.Size = new System.Drawing.Size(1090, 420);
            this.dgvPayments.TabIndex = 3;
            // 
            // PaymentManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1090, 660);
            this.Controls.Add(this.dgvPayments);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaymentManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Management";
            this.Load += new System.EventHandler(this.PaymentManagementForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnEditPayment;
        private System.Windows.Forms.Button btnMarkAsPaid;
        private System.Windows.Forms.Button btnMarkAsPending;
        private System.Windows.Forms.Button btnDeletePayment;
        private System.Windows.Forms.Button btnMergePayments;
        private System.Windows.Forms.Button btnPrintPayment;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.ComboBox cboFilterMethod;
        private System.Windows.Forms.Label lblFilterMethod;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.Label lblFilterDate;
    }
}