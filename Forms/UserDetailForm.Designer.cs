namespace HotelManagementIt008.Forms
{
    partial class UserDetailForm
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
            this.grpUserDetails = new System.Windows.Forms.GroupBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblIdentityNumber = new System.Windows.Forms.Label();
            this.txtIdentityNumber = new System.Windows.Forms.TextBox();
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.cboUserType = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.btnShowPassword = new FontAwesome.Sharp.IconButton();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpUserDetails.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUserDetails
            // 
            this.grpUserDetails.Controls.Add(this.lblUsername);
            this.grpUserDetails.Controls.Add(this.txtUsername);
            this.grpUserDetails.Controls.Add(this.lblEmail);
            this.grpUserDetails.Controls.Add(this.txtEmail);
            this.grpUserDetails.Controls.Add(this.lblPassword);
            this.grpUserDetails.Controls.Add(this.txtPassword);
            this.grpUserDetails.Controls.Add(this.lblFullName);
            this.grpUserDetails.Controls.Add(this.txtFullName);
            this.grpUserDetails.Controls.Add(this.lblAddress);
            this.grpUserDetails.Controls.Add(this.txtAddress);
            this.grpUserDetails.Controls.Add(this.lblIdentityNumber);
            this.grpUserDetails.Controls.Add(this.txtIdentityNumber);
            this.grpUserDetails.Controls.Add(this.lblUserType);
            this.grpUserDetails.Controls.Add(this.cboUserType);
            this.grpUserDetails.Controls.Add(this.lblRole);
            this.grpUserDetails.Controls.Add(this.cboRole);
            this.grpUserDetails.Controls.Add(this.btnShowPassword);

            this.grpUserDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUserDetails.Location = new System.Drawing.Point(10, 10);
            this.grpUserDetails.Name = "grpUserDetails";
            this.grpUserDetails.Size = new System.Drawing.Size(780, 500);
            this.grpUserDetails.TabIndex = 0;
            this.grpUserDetails.TabStop = false;
            this.grpUserDetails.Text = "User Details";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(30, 40);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(60, 15);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(30, 65);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(340, 23);
            this.txtUsername.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(410, 40);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 15);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(410, 65);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(340, 23);
            this.txtEmail.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(410, 250);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 15);
            this.lblPassword.TabIndex = 20;
            this.lblPassword.Text = "Password (Optional)";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(410, 275);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(305, 23);
            this.txtPassword.TabIndex = 21;
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPassword.FlatAppearance.BorderSize = 0;
            this.btnShowPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShowPassword.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.btnShowPassword.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnShowPassword.IconSize = 22;
            this.btnShowPassword.Location = new System.Drawing.Point(720, 274);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(30, 25);
            this.btnShowPassword.TabIndex = 22;
            this.btnShowPassword.UseVisualStyleBackColor = true;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(30, 110);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(61, 15);
            this.lblFullName.TabIndex = 4;
            this.lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(30, 135);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(340, 23);
            this.txtFullName.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(410, 180);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(49, 15);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(410, 205);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(340, 23);
            this.txtAddress.TabIndex = 11;
            // 
            // lblIdentityNumber
            // 
            this.lblIdentityNumber.AutoSize = true;
            this.lblIdentityNumber.Location = new System.Drawing.Point(410, 110);
            this.lblIdentityNumber.Name = "lblIdentityNumber";
            this.lblIdentityNumber.Size = new System.Drawing.Size(95, 15);
            this.lblIdentityNumber.TabIndex = 6;
            this.lblIdentityNumber.Text = "Identity Number";
            // 
            // txtIdentityNumber
            // 
            this.txtIdentityNumber.Location = new System.Drawing.Point(410, 135);
            this.txtIdentityNumber.Name = "txtIdentityNumber";
            this.txtIdentityNumber.Size = new System.Drawing.Size(340, 23);
            this.txtIdentityNumber.TabIndex = 7;
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(30, 180);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(57, 15);
            this.lblUserType.TabIndex = 8;
            this.lblUserType.Text = "User Type";
            // 
            // cboUserType
            // 
            this.cboUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserType.FormattingEnabled = true;
            this.cboUserType.Location = new System.Drawing.Point(30, 205);
            this.cboUserType.Name = "cboUserType";
            this.cboUserType.Size = new System.Drawing.Size(340, 23);
            this.cboUserType.TabIndex = 9;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(30, 250);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(30, 15);
            this.lblRole.TabIndex = 12;
            this.lblRole.Text = "Role";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(30, 275);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(340, 23);
            this.cboRole.TabIndex = 13;

            // 
            //
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnSave);
            this.pnlActions.Controls.Add(this.btnCancel);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(10, 520);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(780, 50);
            this.pnlActions.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(610, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(700, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UserDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.grpUserDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserDetailForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Detail";
            this.grpUserDetails.ResumeLayout(false);
            this.grpUserDetails.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUserDetails;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblIdentityNumber;
        private System.Windows.Forms.TextBox txtIdentityNumber;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.ComboBox cboUserType;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private FontAwesome.Sharp.IconButton btnShowPassword;
    }
}
