namespace HotelManagementIt008.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpChangePassword = new System.Windows.Forms.GroupBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.btnShowOldPassword = new FontAwesome.Sharp.IconButton();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.btnShowNewPassword = new FontAwesome.Sharp.IconButton();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnShowConfirmPassword = new FontAwesome.Sharp.IconButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.grpChangePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(384, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Settings";
            // 
            // grpChangePassword
            // 
            this.grpChangePassword.Controls.Add(this.lblOldPassword);
            this.grpChangePassword.Controls.Add(this.txtOldPassword);
            this.grpChangePassword.Controls.Add(this.btnShowOldPassword);
            this.grpChangePassword.Controls.Add(this.lblNewPassword);
            this.grpChangePassword.Controls.Add(this.txtNewPassword);
            this.grpChangePassword.Controls.Add(this.btnShowNewPassword);
            this.grpChangePassword.Controls.Add(this.lblConfirmPassword);
            this.grpChangePassword.Controls.Add(this.txtConfirmPassword);
            this.grpChangePassword.Controls.Add(this.btnShowConfirmPassword);
            this.grpChangePassword.Controls.Add(this.btnSave);
            this.grpChangePassword.Controls.Add(this.btnCancel);
            this.grpChangePassword.Location = new System.Drawing.Point(12, 70);
            this.grpChangePassword.Name = "grpChangePassword";
            this.grpChangePassword.Size = new System.Drawing.Size(350, 250);
            this.grpChangePassword.TabIndex = 1;
            this.grpChangePassword.TabStop = false;
            this.grpChangePassword.Text = "Change Password";
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Location = new System.Drawing.Point(20, 30);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(79, 15);
            this.lblOldPassword.TabIndex = 0;
            this.lblOldPassword.Text = "Old Password";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(20, 50);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(220, 23);
            this.txtOldPassword.TabIndex = 1;
            // 
            // btnShowOldPassword
            // 
            this.btnShowOldPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowOldPassword.FlatAppearance.BorderSize = 0;
            this.btnShowOldPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShowOldPassword.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.btnShowOldPassword.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnShowOldPassword.IconSize = 22;
            this.btnShowOldPassword.Location = new System.Drawing.Point(250, 48);
            this.btnShowOldPassword.Name = "btnShowOldPassword";
            this.btnShowOldPassword.Size = new System.Drawing.Size(30, 25);
            this.btnShowOldPassword.TabIndex = 2;
            this.btnShowOldPassword.UseVisualStyleBackColor = true;
            this.btnShowOldPassword.Click += new System.EventHandler(this.btnShowOldPassword_Click);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(20, 80);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(84, 15);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(20, 100);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(220, 23);
            this.txtNewPassword.TabIndex = 4;
            // 
            // btnShowNewPassword
            // 
            this.btnShowNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowNewPassword.FlatAppearance.BorderSize = 0;
            this.btnShowNewPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShowNewPassword.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.btnShowNewPassword.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnShowNewPassword.IconSize = 22;
            this.btnShowNewPassword.Location = new System.Drawing.Point(250, 98);
            this.btnShowNewPassword.Name = "btnShowNewPassword";
            this.btnShowNewPassword.Size = new System.Drawing.Size(30, 25);
            this.btnShowNewPassword.TabIndex = 5;
            this.btnShowNewPassword.UseVisualStyleBackColor = true;
            this.btnShowNewPassword.Click += new System.EventHandler(this.btnShowNewPassword_Click);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(20, 130);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(104, 15);
            this.lblConfirmPassword.TabIndex = 6;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(20, 150);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(220, 23);
            this.txtConfirmPassword.TabIndex = 7;
            // 
            // btnShowConfirmPassword
            // 
            this.btnShowConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowConfirmPassword.FlatAppearance.BorderSize = 0;
            this.btnShowConfirmPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShowConfirmPassword.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.btnShowConfirmPassword.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnShowConfirmPassword.IconSize = 22;
            this.btnShowConfirmPassword.Location = new System.Drawing.Point(250, 148);
            this.btnShowConfirmPassword.Name = "btnShowConfirmPassword";
            this.btnShowConfirmPassword.Size = new System.Drawing.Size(30, 25);
            this.btnShowConfirmPassword.TabIndex = 8;
            this.btnShowConfirmPassword.UseVisualStyleBackColor = true;
            this.btnShowConfirmPassword.Click += new System.EventHandler(this.btnShowConfirmPassword_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(110, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 340);
            this.Controls.Add(this.grpChangePassword);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpChangePassword.ResumeLayout(false);
            this.grpChangePassword.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpChangePassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private FontAwesome.Sharp.IconButton btnShowOldPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private FontAwesome.Sharp.IconButton btnShowNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private FontAwesome.Sharp.IconButton btnShowConfirmPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}