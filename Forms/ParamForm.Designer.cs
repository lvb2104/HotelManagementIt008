namespace HotelManagementIt008.Forms
{
    partial class ParamForm
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
            dgvParams = new DataGridView();
            lblTitle = new Label();
            lblKey = new Label();
            cbKey = new ComboBox();
            lblValue = new Label();
            txtValue = new TextBox();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvParams).BeginInit();
            SuspendLayout();
            // 
            // dgvParams
            // 
            dgvParams.AllowUserToAddRows = false;
            dgvParams.AllowUserToDeleteRows = false;
            dgvParams.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParams.BackgroundColor = Color.White;
            dgvParams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParams.Location = new Point(10, 38);
            dgvParams.Margin = new Padding(3, 2, 3, 2);
            dgvParams.Name = "dgvParams";
            dgvParams.RowHeadersWidth = 51;
            dgvParams.RowTemplate.Height = 29;
            dgvParams.Size = new Size(679, 262);
            dgvParams.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(212, 30);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Parameter Settings";
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Location = new Point(10, 312);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(29, 15);
            lblKey.TabIndex = 3;
            lblKey.Text = "Key:";
            // 
            // cbKey
            // 
            cbKey.FormattingEnabled = true;
            cbKey.Location = new Point(46, 310);
            cbKey.Margin = new Padding(3, 2, 3, 2);
            cbKey.Name = "cbKey";
            cbKey.Size = new Size(132, 23);
            cbKey.TabIndex = 4;
            cbKey.SelectedIndexChanged += cbKey_SelectedIndexChanged;
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new Point(192, 312);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(38, 15);
            lblValue.TabIndex = 5;
            lblValue.Text = "Value:";
            // 
            // txtValue
            // 
            txtValue.Location = new Point(240, 310);
            txtValue.Margin = new Padding(3, 2, 3, 2);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(132, 23);
            txtValue.TabIndex = 6;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(16, 185, 129);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(385, 304);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(88, 30);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // ParamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 244, 246);
            ClientSize = new Size(700, 344);
            Controls.Add(btnUpdate);
            Controls.Add(txtValue);
            Controls.Add(lblValue);
            Controls.Add(cbKey);
            Controls.Add(lblKey);
            Controls.Add(lblTitle);
            Controls.Add(dgvParams);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ParamForm";
            Text = "ParamForm";
            ((System.ComponentModel.ISupportInitialize)dgvParams).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParams;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.ComboBox cbKey;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnUpdate;
    }
}
