namespace HotelManagementIt008.Forms
{
    partial class PaymentMergeForm
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
            grpTargetPayment = new GroupBox();
            lblTargetIdLabel = new Label();
            lblTargetId = new Label();
            lblTargetMethodLabel = new Label();
            lblTargetMethod = new Label();
            lblTargetAmountLabel = new Label();
            lblTargetAmount = new Label();
            lblTargetStatusLabel = new Label();
            lblTargetStatus = new Label();
            grpPaymentsToMerge = new GroupBox();
            dgvPayments = new DataGridView();
            grpSummary = new GroupBox();
            lblCurrentAmountLabel = new Label();
            lblCurrentAmount = new Label();
            lblTotalAmountLabel = new Label();
            lblTotalAmount = new Label();
            pnlActions = new Panel();
            btnMerge = new Button();
            btnCancel = new Button();
            grpTargetPayment.SuspendLayout();
            grpPaymentsToMerge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            grpSummary.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // grpTargetPayment
            // 
            grpTargetPayment.Controls.Add(lblTargetIdLabel);
            grpTargetPayment.Controls.Add(lblTargetId);
            grpTargetPayment.Controls.Add(lblTargetMethodLabel);
            grpTargetPayment.Controls.Add(lblTargetMethod);
            grpTargetPayment.Controls.Add(lblTargetAmountLabel);
            grpTargetPayment.Controls.Add(lblTargetAmount);
            grpTargetPayment.Controls.Add(lblTargetStatusLabel);
            grpTargetPayment.Controls.Add(lblTargetStatus);
            grpTargetPayment.Dock = DockStyle.Top;
            grpTargetPayment.Location = new Point(10, 10);
            grpTargetPayment.Name = "grpTargetPayment";
            grpTargetPayment.Size = new Size(780, 100);
            grpTargetPayment.TabIndex = 0;
            grpTargetPayment.TabStop = false;
            grpTargetPayment.Text = "Target Payment (Keep)";
            // 
            // lblTargetIdLabel
            // 
            lblTargetIdLabel.AutoSize = true;
            lblTargetIdLabel.Location = new Point(20, 30);
            lblTargetIdLabel.Name = "lblTargetIdLabel";
            lblTargetIdLabel.Size = new Size(69, 15);
            lblTargetIdLabel.TabIndex = 0;
            lblTargetIdLabel.Text = "Payment ID:";
            // 
            // lblTargetId
            // 
            lblTargetId.AutoSize = true;
            lblTargetId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTargetId.Location = new Point(95, 30);
            lblTargetId.Name = "lblTargetId";
            lblTargetId.Size = new Size(25, 15);
            lblTargetId.TabIndex = 1;
            lblTargetId.Text = "N/A";
            // 
            // lblTargetMethodLabel
            // 
            lblTargetMethodLabel.AutoSize = true;
            lblTargetMethodLabel.Location = new Point(20, 55);
            lblTargetMethodLabel.Name = "lblTargetMethodLabel";
            lblTargetMethodLabel.Size = new Size(52, 15);
            lblTargetMethodLabel.TabIndex = 2;
            lblTargetMethodLabel.Text = "Method:";
            // 
            // lblTargetMethod
            // 
            lblTargetMethod.AutoSize = true;
            lblTargetMethod.Location = new Point(95, 55);
            lblTargetMethod.Name = "lblTargetMethod";
            lblTargetMethod.Size = new Size(25, 15);
            lblTargetMethod.TabIndex = 3;
            lblTargetMethod.Text = "N/A";
            // 
            // lblTargetAmountLabel
            // 
            lblTargetAmountLabel.AutoSize = true;
            lblTargetAmountLabel.Location = new Point(350, 30);
            lblTargetAmountLabel.Name = "lblTargetAmountLabel";
            lblTargetAmountLabel.Size = new Size(54, 15);
            lblTargetAmountLabel.TabIndex = 4;
            lblTargetAmountLabel.Text = "Amount:";
            // 
            // lblTargetAmount
            // 
            lblTargetAmount.AutoSize = true;
            lblTargetAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTargetAmount.ForeColor = Color.FromArgb(76, 175, 80);
            lblTargetAmount.Location = new Point(410, 28);
            lblTargetAmount.Name = "lblTargetAmount";
            lblTargetAmount.Size = new Size(44, 19);
            lblTargetAmount.TabIndex = 5;
            lblTargetAmount.Text = "$0.00";
            // 
            // lblTargetStatusLabel
            // 
            lblTargetStatusLabel.AutoSize = true;
            lblTargetStatusLabel.Location = new Point(350, 55);
            lblTargetStatusLabel.Name = "lblTargetStatusLabel";
            lblTargetStatusLabel.Size = new Size(42, 15);
            lblTargetStatusLabel.TabIndex = 6;
            lblTargetStatusLabel.Text = "Status:";
            // 
            // lblTargetStatus
            // 
            lblTargetStatus.AutoSize = true;
            lblTargetStatus.Location = new Point(410, 55);
            lblTargetStatus.Name = "lblTargetStatus";
            lblTargetStatus.Size = new Size(25, 15);
            lblTargetStatus.TabIndex = 7;
            lblTargetStatus.Text = "N/A";
            // 
            // grpPaymentsToMerge
            // 
            grpPaymentsToMerge.Controls.Add(dgvPayments);
            grpPaymentsToMerge.Dock = DockStyle.Fill;
            grpPaymentsToMerge.Location = new Point(10, 110);
            grpPaymentsToMerge.Name = "grpPaymentsToMerge";
            grpPaymentsToMerge.Size = new Size(780, 240);
            grpPaymentsToMerge.TabIndex = 1;
            grpPaymentsToMerge.TabStop = false;
            grpPaymentsToMerge.Text = "Select Payments to Merge";
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Dock = DockStyle.Fill;
            dgvPayments.Location = new Point(3, 19);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new Size(774, 218);
            dgvPayments.TabIndex = 0;
            dgvPayments.CellValueChanged += dgvPayments_CellValueChanged;
            dgvPayments.CurrentCellDirtyStateChanged += dgvPayments_CurrentCellDirtyStateChanged;
            // 
            // grpSummary
            // 
            grpSummary.Controls.Add(lblCurrentAmountLabel);
            grpSummary.Controls.Add(lblCurrentAmount);
            grpSummary.Controls.Add(lblTotalAmountLabel);
            grpSummary.Controls.Add(lblTotalAmount);
            grpSummary.Dock = DockStyle.Bottom;
            grpSummary.Location = new Point(10, 350);
            grpSummary.Name = "grpSummary";
            grpSummary.Size = new Size(780, 80);
            grpSummary.TabIndex = 2;
            grpSummary.TabStop = false;
            grpSummary.Text = "Merge Summary";
            // 
            // lblCurrentAmountLabel
            // 
            lblCurrentAmountLabel.AutoSize = true;
            lblCurrentAmountLabel.Location = new Point(20, 30);
            lblCurrentAmountLabel.Name = "lblCurrentAmountLabel";
            lblCurrentAmountLabel.Size = new Size(147, 15);
            lblCurrentAmountLabel.TabIndex = 0;
            lblCurrentAmountLabel.Text = "Current Target Amount:";
            // 
            // lblCurrentAmount
            // 
            lblCurrentAmount.AutoSize = true;
            lblCurrentAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCurrentAmount.Location = new Point(173, 28);
            lblCurrentAmount.Name = "lblCurrentAmount";
            lblCurrentAmount.Size = new Size(44, 19);
            lblCurrentAmount.TabIndex = 1;
            lblCurrentAmount.Text = "$0.00";
            // 
            // lblTotalAmountLabel
            // 
            lblTotalAmountLabel.AutoSize = true;
            lblTotalAmountLabel.Location = new Point(350, 30);
            lblTotalAmountLabel.Name = "lblTotalAmountLabel";
            lblTotalAmountLabel.Size = new Size(136, 15);
            lblTotalAmountLabel.TabIndex = 2;
            lblTotalAmountLabel.Text = "Total After Merge:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(33, 150, 243);
            lblTotalAmount.Location = new Point(492, 26);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(51, 21);
            lblTotalAmount.TabIndex = 3;
            lblTotalAmount.Text = "$0.00";
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnMerge);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(10, 430);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(780, 50);
            pnlActions.TabIndex = 3;
            // 
            // btnMerge
            // 
            btnMerge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMerge.BackColor = Color.FromArgb(156, 39, 176);
            btnMerge.Enabled = false;
            btnMerge.FlatStyle = FlatStyle.Flat;
            btnMerge.ForeColor = Color.White;
            btnMerge.Location = new Point(610, 10);
            btnMerge.Name = "btnMerge";
            btnMerge.Size = new Size(80, 30);
            btnMerge.TabIndex = 0;
            btnMerge.Text = "🔗 Merge";
            btnMerge.UseVisualStyleBackColor = false;
            btnMerge.Click += btnMerge_Click;
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
            // PaymentMergeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 490);
            Controls.Add(grpPaymentsToMerge);
            Controls.Add(grpSummary);
            Controls.Add(pnlActions);
            Controls.Add(grpTargetPayment);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentMergeForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Merge Payments";
            grpTargetPayment.ResumeLayout(false);
            grpTargetPayment.PerformLayout();
            grpPaymentsToMerge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            grpSummary.ResumeLayout(false);
            grpSummary.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private GroupBox grpTargetPayment;
        private Label lblTargetIdLabel;
        private Label lblTargetId;
        private Label lblTargetMethodLabel;
        private Label lblTargetMethod;
        private Label lblTargetAmountLabel;
        private Label lblTargetAmount;
        private Label lblTargetStatusLabel;
        private Label lblTargetStatus;
        private GroupBox grpPaymentsToMerge;
        private DataGridView dgvPayments;
        private GroupBox grpSummary;
        private Label lblCurrentAmountLabel;
        private Label lblCurrentAmount;
        private Label lblTotalAmountLabel;
        private Label lblTotalAmount;
        private Panel pnlActions;
        private Button btnMerge;
        private Button btnCancel;
    }
}
