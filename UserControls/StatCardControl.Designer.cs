namespace HotelManagementIt008.UserControls
{
    partial class StatCardControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblValue = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 10F);
            lblTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(34, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Dock = DockStyle.Fill;
            lblValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValue.Location = new Point(20, 39);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(74, 45);
            lblValue.TabIndex = 1;
            lblValue.Text = "123";
            lblValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StatCardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblValue);
            Controls.Add(lblTitle);
            Margin = new Padding(10);
            Name = "StatCardControl";
            Padding = new Padding(20);
            Size = new Size(250, 120);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblValue;
    }
}
