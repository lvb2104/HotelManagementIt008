namespace HotelManagementIt008.Forms
{
    partial class LoginForm
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox();
            btnLogin = new Button();
            logoPic = new PictureBox();
            title = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            chkRememberMe = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)logoPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(0, 117, 214);
            txtUsername.Location = new Point(89, 227);
            txtUsername.Margin = new Padding(4, 2, 4, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(179, 17);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.FromArgb(0, 117, 214);
            txtPassword.Location = new Point(89, 291);
            txtPassword.Margin = new Padding(4, 2, 4, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(179, 17);
            txtPassword.TabIndex = 3;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Cursor = Cursors.Hand;
            chkShowPassword.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkShowPassword.ForeColor = Color.FromArgb(70, 70, 70);
            chkShowPassword.Location = new Point(35, 351);
            chkShowPassword.Margin = new Padding(4, 2, 4, 2);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(115, 17);
            chkShowPassword.TabIndex = 4;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 117, 214);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(35, 405);
            btnLogin.Margin = new Padding(4, 2, 4, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 37);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "LOG IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // logoPic
            // 
            logoPic.Image = Resources.logo;
            logoPic.Location = new Point(89, 12);
            logoPic.Margin = new Padding(4, 3, 4, 3);
            logoPic.Name = "logoPic";
            logoPic.Size = new Size(149, 111);
            logoPic.SizeMode = PictureBoxSizeMode.Zoom;
            logoPic.TabIndex = 7;
            logoPic.TabStop = false;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = Color.FromArgb(0, 117, 214);
            title.Location = new Point(111, 126);
            title.Margin = new Padding(4, 0, 4, 0);
            title.Name = "title";
            title.Size = new Size(126, 45);
            title.TabIndex = 8;
            title.Text = "LOG IN";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Resources.user;
            pictureBox2.Location = new Point(35, 216);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 28);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 117, 214);
            panel1.Location = new Point(35, 253);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 1);
            panel1.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 117, 214);
            panel2.Location = new Point(35, 314);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 1);
            panel2.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources._lock;
            pictureBox1.Location = new Point(35, 280);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Cursor = Cursors.Hand;
            chkRememberMe.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkRememberMe.ForeColor = Color.FromArgb(70, 70, 70);
            chkRememberMe.Location = new Point(180, 351);
            chkRememberMe.Margin = new Padding(4, 2, 4, 2);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(105, 17);
            chkRememberMe.TabIndex = 13;
            chkRememberMe.Text = "Remember me";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(331, 500);
            Controls.Add(chkRememberMe);
            Controls.Add(panel2);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(title);
            Controls.Add(logoPic);
            Controls.Add(btnLogin);
            Controls.Add(chkShowPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 117, 214);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 2, 4, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            Text = "Hotel Management - Login";
            ((System.ComponentModel.ISupportInitialize)logoPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUsername;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private PictureBox logoPic;
        private Label title;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private CheckBox chkRememberMe;
    }
}