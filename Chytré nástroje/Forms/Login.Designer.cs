namespace Chytré_nástroje.Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            loginPanel = new Panel();
            pictureBox_toolsText_smartTools = new PictureBox();
            pictureBox_smartTexr_smartTools = new PictureBox();
            pictureBox_logo_smartTools = new PictureBox();
            label1 = new Label();
            textBox_password = new TextBox();
            button_login = new Button();
            textBox_userName = new TextBox();
            label_password = new Label();
            label_title_1 = new Label();
            loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_toolsText_smartTools).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_smartTexr_smartTools).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_smartTools).BeginInit();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.BackColor = Color.FromArgb(11, 24, 33);
            loginPanel.Controls.Add(pictureBox_toolsText_smartTools);
            loginPanel.Controls.Add(pictureBox_smartTexr_smartTools);
            loginPanel.Controls.Add(pictureBox_logo_smartTools);
            loginPanel.Controls.Add(label1);
            loginPanel.Controls.Add(textBox_password);
            loginPanel.Controls.Add(button_login);
            loginPanel.Controls.Add(textBox_userName);
            loginPanel.Controls.Add(label_password);
            loginPanel.Controls.Add(label_title_1);
            loginPanel.Location = new Point(-8, 0);
            loginPanel.Margin = new Padding(0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(532, 681);
            loginPanel.TabIndex = 1;
            // 
            // pictureBox_toolsText_smartTools
            // 
            pictureBox_toolsText_smartTools.Image = Properties.Resources.Tools___Smart_tools;
            pictureBox_toolsText_smartTools.Location = new Point(209, 224);
            pictureBox_toolsText_smartTools.Name = "pictureBox_toolsText_smartTools";
            pictureBox_toolsText_smartTools.Size = new Size(236, 53);
            pictureBox_toolsText_smartTools.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_toolsText_smartTools.TabIndex = 12;
            pictureBox_toolsText_smartTools.TabStop = false;
            // 
            // pictureBox_smartTexr_smartTools
            // 
            pictureBox_smartTexr_smartTools.Image = Properties.Resources.Smart___Smart_tools;
            pictureBox_smartTexr_smartTools.Location = new Point(209, 178);
            pictureBox_smartTexr_smartTools.Name = "pictureBox_smartTexr_smartTools";
            pictureBox_smartTexr_smartTools.Size = new Size(236, 51);
            pictureBox_smartTexr_smartTools.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_smartTexr_smartTools.TabIndex = 11;
            pictureBox_smartTexr_smartTools.TabStop = false;
            // 
            // pictureBox_logo_smartTools
            // 
            pictureBox_logo_smartTools.Image = Properties.Resources.Logo___smart_tools;
            pictureBox_logo_smartTools.Location = new Point(82, 178);
            pictureBox_logo_smartTools.Name = "pictureBox_logo_smartTools";
            pictureBox_logo_smartTools.Size = new Size(139, 99);
            pictureBox_logo_smartTools.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_logo_smartTools.TabIndex = 10;
            pictureBox_logo_smartTools.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(156, 324);
            label1.Name = "label1";
            label1.Size = new Size(238, 37);
            label1.TabIndex = 9;
            label1.Text = "Uživatelské jméno:";
            // 
            // textBox_password
            // 
            textBox_password.BackColor = Color.FromArgb(11, 24, 33);
            textBox_password.BorderStyle = BorderStyle.FixedSingle;
            textBox_password.Font = new Font("Segoe UI", 15F);
            textBox_password.ForeColor = Color.White;
            textBox_password.Location = new Point(92, 441);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(353, 34);
            textBox_password.TabIndex = 1;
            textBox_password.TextAlign = HorizontalAlignment.Center;
            textBox_password.UseSystemPasswordChar = true;
            // 
            // button_login
            // 
            button_login.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button_login.Location = new Point(92, 495);
            button_login.Name = "button_login";
            button_login.Size = new Size(353, 37);
            button_login.TabIndex = 2;
            button_login.Text = "Přihlásit se";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // textBox_userName
            // 
            textBox_userName.BackColor = Color.FromArgb(11, 24, 33);
            textBox_userName.BorderStyle = BorderStyle.FixedSingle;
            textBox_userName.Font = new Font("Segoe UI", 15F);
            textBox_userName.ForeColor = Color.White;
            textBox_userName.Location = new Point(92, 364);
            textBox_userName.Name = "textBox_userName";
            textBox_userName.Size = new Size(353, 34);
            textBox_userName.TabIndex = 0;
            textBox_userName.TextAlign = HorizontalAlignment.Center;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Segoe UI", 20F);
            label_password.ForeColor = Color.White;
            label_password.Location = new Point(226, 401);
            label_password.Name = "label_password";
            label_password.Size = new Size(90, 37);
            label_password.TabIndex = 5;
            label_password.Text = "Heslo:";
            // 
            // label_title_1
            // 
            label_title_1.AutoSize = true;
            label_title_1.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            label_title_1.ForeColor = Color.White;
            label_title_1.Location = new Point(14, 92);
            label_title_1.Name = "label_title_1";
            label_title_1.Size = new Size(507, 72);
            label_title_1.TabIndex = 3;
            label_title_1.Text = "Vítejte v programu";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(516, 681);
            Controls.Add(loginPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Login";
            Text = "Smart tools";
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_toolsText_smartTools).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_smartTexr_smartTools).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_smartTools).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel loginPanel;
        private Label label_title_1;
        private Label label_password;
        private Label label_title_2;
        private Button button_login;
        private TextBox textBox_userName;
        private TextBox textBox_password;
        private Label label1;
        private PictureBox pictureBox_logo_smartTools;
        private PictureBox pictureBox_toolsText_smartTools;
        private PictureBox pictureBox_smartTexr_smartTools;
    }
}