namespace Chytré_nástroje.Forms
{
    partial class Hlavni_2
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
            loginPanel = new Panel();
            button1 = new Button();
            textBox_password = new TextBox();
            label_password = new Label();
            label_title_2 = new Label();
            label_title_1 = new Label();
            loginPanel.SuspendLayout();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.BackColor = Color.FromArgb(0, 0, 37);
            loginPanel.Controls.Add(button1);
            loginPanel.Controls.Add(textBox_password);
            loginPanel.Controls.Add(label_password);
            loginPanel.Controls.Add(label_title_2);
            loginPanel.Controls.Add(label_title_1);
            loginPanel.Location = new Point(0, 0);
            loginPanel.Margin = new Padding(0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(524, 681);
            loginPanel.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button1.Location = new Point(92, 427);
            button1.Name = "button1";
            button1.Size = new Size(353, 37);
            button1.TabIndex = 7;
            button1.Text = "Přihlásit se";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox_password
            // 
            textBox_password.Font = new Font("Segoe UI", 15F);
            textBox_password.Location = new Point(92, 376);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(353, 34);
            textBox_password.TabIndex = 6;
            textBox_password.TextAlign = HorizontalAlignment.Center;
            textBox_password.UseSystemPasswordChar = true;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Segoe UI", 25F);
            label_password.ForeColor = Color.White;
            label_password.Location = new Point(213, 327);
            label_password.Name = "label_password";
            label_password.Size = new Size(111, 46);
            label_password.TabIndex = 5;
            label_password.Text = "Heslo:";
            // 
            // label_title_2
            // 
            label_title_2.AutoSize = true;
            label_title_2.Font = new Font("Segoe UI", 38F, FontStyle.Bold);
            label_title_2.ForeColor = Color.White;
            label_title_2.Location = new Point(65, 164);
            label_title_2.Name = "label_title_2";
            label_title_2.Size = new Size(380, 68);
            label_title_2.TabIndex = 4;
            label_title_2.Text = "SMART TOOLS";
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
            // Hlavni_2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1264, 681);
            Controls.Add(loginPanel);
            MaximizeBox = false;
            Name = "Hlavni_2";
            Text = "Smart tools";
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel loginPanel;
        private Label label_title_1;
        private Label label_password;
        private Label label_title_2;
        private Button button1;
        private TextBox textBox_password;
    }
}