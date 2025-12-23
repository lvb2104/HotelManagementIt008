namespace HotelManagementIt008.Forms
{
    partial class UserDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblIdentityNumber;
        private System.Windows.Forms.TextBox txtIdentityNumber;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.ComboBox cboUserType;
        private System.Windows.Forms.DataGridView dgvParticipants;
        private System.Windows.Forms.Button btnAddParticipant;
        private System.Windows.Forms.Button btnRemoveParticipant;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblUsername = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblFullName = new System.Windows.Forms.Label();
            txtFullName = new System.Windows.Forms.TextBox();
            lblAddress = new System.Windows.Forms.Label();
            txtAddress = new System.Windows.Forms.TextBox();
            lblIdentityNumber = new System.Windows.Forms.Label();
            txtIdentityNumber = new System.Windows.Forms.TextBox();
            lblUserType = new System.Windows.Forms.Label();
            cboUserType = new System.Windows.Forms.ComboBox();
            dgvParticipants = new System.Windows.Forms.DataGridView();
            btnAddParticipant = new System.Windows.Forms.Button();
            btnRemoveParticipant = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(dgvParticipants)).BeginInit();
            SuspendLayout();

            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(20, 20);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(70, 15);
            lblUsername.Text = "Username:";

            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(120, 17);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(200, 23);

            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new System.Drawing.Point(20, 60);
            lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(120, 57);
            txtEmail.Size = new System.Drawing.Size(200, 23);

            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new System.Drawing.Point(20, 100);
            lblFullName.Text = "Full Name:";

            // 
            // txtFullName
            // 
            txtFullName.Location = new System.Drawing.Point(120, 97);
            txtFullName.Size = new System.Drawing.Size(200, 23);

            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new System.Drawing.Point(20, 140);
            lblAddress.Text = "Address:";

            // 
            // txtAddress
            // 
            txtAddress.Location = new System.Drawing.Point(120, 137);
            txtAddress.Size = new System.Drawing.Size(200, 23);

            // 
            // lblIdentityNumber
            // 
            lblIdentityNumber.AutoSize = true;
            lblIdentityNumber.Location = new System.Drawing.Point(20, 180);
            lblIdentityNumber.Text = "Identity Number:";

            // 
            // txtIdentityNumber
            // 
            txtIdentityNumber.Location = new System.Drawing.Point(120, 177);
            txtIdentityNumber.Size = new System.Drawing.Size(200, 23);

            // 
            // lblUserType
            // 
            lblUserType.AutoSize = true;
            lblUserType.Location = new System.Drawing.Point(20, 220);
            lblUserType.Text = "User Type:";

            // 
            // cboUserType
            // 
            cboUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboUserType.Location = new System.Drawing.Point(120, 217);
            cboUserType.Size = new System.Drawing.Size(200, 23);

            // 
            // dgvParticipants
            // 
            dgvParticipants.Location = new System.Drawing.Point(20, 260);
            dgvParticipants.Size = new System.Drawing.Size(500, 200);
            dgvParticipants.AllowUserToAddRows = false;
            dgvParticipants.AllowUserToDeleteRows = false;
            dgvParticipants.ReadOnly = true;

            // 
            // btnAddParticipant
            // 
            btnAddParticipant.Location = new System.Drawing.Point(540, 260);
            btnAddParticipant.Size = new System.Drawing.Size(100, 30);
            btnAddParticipant.Text = "Add Participant";
            btnAddParticipant.Click += btnAddParticipant_Click;

            // 
            // btnRemoveParticipant
            // 
            btnRemoveParticipant.Location = new System.Drawing.Point(540, 300);
            btnRemoveParticipant.Size = new System.Drawing.Size(100, 30);
            btnRemoveParticipant.Text = "Remove Participant";
            btnRemoveParticipant.Click += btnRemoveParticipant_Click;

            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(120, 480);
            btnSave.Size = new System.Drawing.Size(100, 30);
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;

            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(240, 480);
            btnCancel.Size = new System.Drawing.Size(100, 30);
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;

            // 
            // UserDetailForm
            // 
            ClientSize = new System.Drawing.Size(680, 530);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblIdentityNumber);
            Controls.Add(txtIdentityNumber);
            Controls.Add(lblUserType);
            Controls.Add(cboUserType);
            Controls.Add(dgvParticipants);
            Controls.Add(btnAddParticipant);
            Controls.Add(btnRemoveParticipant);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "UserDetailForm";
            Text = "User Detail";

            ((System.ComponentModel.ISupportInitialize)(dgvParticipants)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
