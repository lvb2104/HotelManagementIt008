namespace HotelManagementIt008.Forms
{
    partial class PaymentDetailForm
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
            grpPaymentDetails = new GroupBox();
            lblAmountLabel = new Label();
            lblAmount = new Label();
            lblMethod = new Label();
            cboMethod = new ComboBox();
            pnlActions = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            grpPaymentDetails.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // grpPaymentDetails
            // 
            grpPaymentDetails.Controls.Add(lblAmountLabel);
            grpPaymentDetails.Controls.Add(lblAmount);
            grpPaymentDetails.Controls.Add(lblMethod);
            grpPaymentDetails.Controls.Add(cboMethod);
            grpPaymentDetails.Dock = DockStyle.Top;
            grpPaymentDetails.Location = new Point(10, 10);
            grpPaymentDetails.Name = "grpPaymentDetails";
            grpPaymentDetails.Size = new Size(480, 180);
            grpPaymentDetails.TabIndex = 0;
            grpPaymentDetails.TabStop = false;
            grpPaymentDetails.Text = "Payment Details";
            // 
            // lblAmountLabel
            // 
            lblAmountLabel.AutoSize = true;
            lblAmountLabel.Location = new Point(20, 30);
            lblAmountLabel.Name = "lblAmountLabel";
            lblAmountLabel.Size = new Size(51, 15);
            lblAmountLabel.TabIndex = 0;
            lblAmountLabel.Text = "Amount";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAmount.ForeColor = Color.FromArgb(76, 175, 80);
            lblAmount.Location = new Point(20, 50);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(45, 21);
            lblAmount.TabIndex = 1;
            lblAmount.Text = "$0.00";
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Location = new Point(20, 85);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(96, 15);
            lblMethod.TabIndex = 2;
            lblMethod.Text = "Payment Method";
            // 
            // cboMethod
            // 
            cboMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMethod.FormattingEnabled = true;
            cboMethod.Location = new Point(20, 105);
            cboMethod.Name = "cboMethod";
            cboMethod.Size = new Size(200, 23);
            cboMethod.TabIndex = 3;
            // 
            // 
            // cboStatus and lblStatus removed
            //
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnSave);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(10, 200);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(480, 50);
            pnlActions.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(310, 10);
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
            btnCancel.Location = new Point(400, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // PaymentDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 260);
            Controls.Add(pnlActions);
            Controls.Add(grpPaymentDetails);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentDetailForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Payment";
            grpPaymentDetails.ResumeLayout(false);
            grpPaymentDetails.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private GroupBox grpPaymentDetails;
        private Label lblAmountLabel;
        private Label lblAmount;
        private Label lblMethod;
        private ComboBox cboMethod;

        private Panel pnlActions;
        private Button btnSave;
        private Button btnCancel;
    }
}
