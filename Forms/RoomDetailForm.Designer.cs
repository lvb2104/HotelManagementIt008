namespace HotelManagementIt008.Forms
{
    partial class RoomDetailForm
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
            grpRoomDetails = new GroupBox();
            lblRoomNumber = new Label();
            txtRoomNumber = new TextBox();
            lblNote = new Label();
            txtNote = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblRoomType = new Label();
            cboRoomType = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            pnlActions = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            grpRoomDetails.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // grpRoomDetails
            // 
            grpRoomDetails.Controls.Add(lblRoomNumber);
            grpRoomDetails.Controls.Add(txtRoomNumber);
            grpRoomDetails.Controls.Add(lblNote);
            grpRoomDetails.Controls.Add(txtNote);
            grpRoomDetails.Controls.Add(lblStatus);
            grpRoomDetails.Controls.Add(cboStatus);
            grpRoomDetails.Controls.Add(lblRoomType);
            grpRoomDetails.Controls.Add(cboRoomType);
            grpRoomDetails.Controls.Add(lblPrice);
            grpRoomDetails.Controls.Add(txtPrice);
            grpRoomDetails.Dock = DockStyle.Fill;
            grpRoomDetails.Location = new Point(10, 10);
            grpRoomDetails.Name = "grpRoomDetails";
            grpRoomDetails.Size = new Size(480, 200);
            grpRoomDetails.TabIndex = 0;
            grpRoomDetails.TabStop = false;
            grpRoomDetails.Text = "Room Details";
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Location = new Point(20, 30);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(86, 15);
            lblRoomNumber.TabIndex = 0;
            lblRoomNumber.Text = "Room Number";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(20, 50);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(200, 23);
            txtRoomNumber.TabIndex = 1;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Location = new Point(250, 30);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(33, 15);
            lblNote.TabIndex = 2;
            lblNote.Text = "Note";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(250, 50);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(210, 60);
            txtNote.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(20, 90);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(20, 110);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(200, 23);
            cboStatus.TabIndex = 5;
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(20, 150);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(67, 15);
            lblRoomType.TabIndex = 6;
            lblRoomType.Text = "Room Type";
            // 
            // cboRoomType
            // 
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Location = new Point(20, 170);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new Size(200, 23);
            cboRoomType.TabIndex = 7;
            cboRoomType.SelectedIndexChanged += cboRoomType_SelectedIndexChanged;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(250, 150);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(86, 15);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Price Per Night";
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.WhiteSmoke;
            txtPrice.Enabled = false;
            txtPrice.Location = new Point(250, 170);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(210, 23);
            txtPrice.TabIndex = 9;
            txtPrice.Text = "0.00";
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnSave);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(10, 210);
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
            // RoomDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 270);
            Controls.Add(grpRoomDetails);
            Controls.Add(pnlActions);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RoomDetailForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Room Detail";
            grpRoomDetails.ResumeLayout(false);
            grpRoomDetails.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRoomDetails;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.ComboBox cboRoomType;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
