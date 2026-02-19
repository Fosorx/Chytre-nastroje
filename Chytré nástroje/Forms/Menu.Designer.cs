namespace Chytré_nástroje.Forms
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            button_kopirovani = new Button();
            button_spusteni = new Button();
            button_pridavani = new Button();
            pictureBox1 = new PictureBox();
            label_userName = new Label();
            label2 = new Label();
            pictureBox_menuBar = new PictureBox();
            button_mazani = new Button();
            button_sprava_winget = new Button();
            button_sprava_instlaci = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_menuBar).BeginInit();
            SuspendLayout();
            // 
            // button_kopirovani
            // 
            button_kopirovani.BackColor = Color.FromArgb(213, 229, 241);
            button_kopirovani.FlatStyle = FlatStyle.Flat;
            button_kopirovani.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button_kopirovani.ForeColor = Color.Black;
            button_kopirovani.Location = new Point(41, 180);
            button_kopirovani.Margin = new Padding(9, 10, 9, 10);
            button_kopirovani.Name = "button_kopirovani";
            button_kopirovani.Padding = new Padding(5);
            button_kopirovani.RightToLeft = RightToLeft.No;
            button_kopirovani.Size = new Size(169, 40);
            button_kopirovani.TabIndex = 0;
            button_kopirovani.Text = "Kopírování souborů";
            button_kopirovani.UseVisualStyleBackColor = false;
            button_kopirovani.Click += button_kopirovani_Click;
            // 
            // button_spusteni
            // 
            button_spusteni.BackColor = Color.FromArgb(213, 229, 241);
            button_spusteni.FlatStyle = FlatStyle.Flat;
            button_spusteni.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button_spusteni.Location = new Point(41, 228);
            button_spusteni.Margin = new Padding(9, 10, 9, 10);
            button_spusteni.Name = "button_spusteni";
            button_spusteni.RightToLeft = RightToLeft.No;
            button_spusteni.Size = new Size(169, 40);
            button_spusteni.TabIndex = 1;
            button_spusteni.Text = "Spuštění programů";
            button_spusteni.UseVisualStyleBackColor = false;
            button_spusteni.Click += button_spusteni_Click;
            // 
            // button_pridavani
            // 
            button_pridavani.BackColor = Color.FromArgb(213, 229, 241);
            button_pridavani.FlatStyle = FlatStyle.Flat;
            button_pridavani.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button_pridavani.Location = new Point(41, 276);
            button_pridavani.Margin = new Padding(9, 10, 9, 10);
            button_pridavani.Name = "button_pridavani";
            button_pridavani.RightToLeft = RightToLeft.No;
            button_pridavani.Size = new Size(169, 37);
            button_pridavani.TabIndex = 2;
            button_pridavani.Text = "Přidávání uživatelů do AD";
            button_pridavani.UseVisualStyleBackColor = false;
            button_pridavani.Click += button_pridavani_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(31, 59);
            pictureBox1.Margin = new Padding(5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label_userName
            // 
            label_userName.AutoSize = true;
            label_userName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label_userName.ForeColor = Color.FromArgb(213, 229, 241);
            label_userName.Location = new Point(92, 75);
            label_userName.Margin = new Padding(5, 0, 5, 0);
            label_userName.Name = "label_userName";
            label_userName.Size = new Size(131, 19);
            label_userName.TabIndex = 5;
            label_userName.Text = "Uživatelské jméno";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(213, 229, 241);
            label2.Location = new Point(92, 145);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 6;
            label2.Text = "Menu";
            // 
            // pictureBox_menuBar
            // 
            pictureBox_menuBar.Location = new Point(9, 3);
            pictureBox_menuBar.Name = "pictureBox_menuBar";
            pictureBox_menuBar.Size = new Size(34, 31);
            pictureBox_menuBar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_menuBar.TabIndex = 7;
            pictureBox_menuBar.TabStop = false;
            pictureBox_menuBar.Click += pictureBox_menuBar_Click;
            // 
            // button_mazani
            // 
            button_mazani.BackColor = Color.FromArgb(213, 229, 241);
            button_mazani.FlatStyle = FlatStyle.Flat;
            button_mazani.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button_mazani.Location = new Point(41, 323);
            button_mazani.Margin = new Padding(9, 10, 9, 10);
            button_mazani.Name = "button_mazani";
            button_mazani.RightToLeft = RightToLeft.No;
            button_mazani.Size = new Size(169, 35);
            button_mazani.TabIndex = 8;
            button_mazani.Text = "Mazání profilů";
            button_mazani.UseVisualStyleBackColor = false;
            button_mazani.Click += buttonMazani_Click;
            // 
            // button_sprava_winget
            // 
            button_sprava_winget.BackColor = Color.FromArgb(213, 229, 241);
            button_sprava_winget.FlatStyle = FlatStyle.Flat;
            button_sprava_winget.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button_sprava_winget.Location = new Point(41, 368);
            button_sprava_winget.Margin = new Padding(9, 10, 9, 10);
            button_sprava_winget.Name = "button_sprava_winget";
            button_sprava_winget.RightToLeft = RightToLeft.No;
            button_sprava_winget.Size = new Size(169, 37);
            button_sprava_winget.TabIndex = 9;
            button_sprava_winget.Text = "Správa Winget";
            button_sprava_winget.UseVisualStyleBackColor = false;
            button_sprava_winget.Click += button_sprava_winget_Click;
            // 
            // button_sprava_instlaci
            // 
            button_sprava_instlaci.BackColor = Color.FromArgb(213, 229, 241);
            button_sprava_instlaci.FlatStyle = FlatStyle.Flat;
            button_sprava_instlaci.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button_sprava_instlaci.Location = new Point(41, 416);
            button_sprava_instlaci.Margin = new Padding(9, 10, 9, 10);
            button_sprava_instlaci.Name = "button_sprava_instlaci";
            button_sprava_instlaci.RightToLeft = RightToLeft.No;
            button_sprava_instlaci.Size = new Size(169, 37);
            button_sprava_instlaci.TabIndex = 10;
            button_sprava_instlaci.Text = "Správa instalací";
            button_sprava_instlaci.UseVisualStyleBackColor = false;
            button_sprava_instlaci.Click += button_sprava_instalaci_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 24, 33);
            Controls.Add(button_sprava_instlaci);
            Controls.Add(button_sprava_winget);
            Controls.Add(button_mazani);
            Controls.Add(pictureBox_menuBar);
            Controls.Add(label2);
            Controls.Add(label_userName);
            Controls.Add(pictureBox1);
            Controls.Add(button_pridavani);
            Controls.Add(button_spusteni);
            Controls.Add(button_kopirovani);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            Margin = new Padding(5);
            Name = "Menu";
            Size = new Size(260, 560);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_menuBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_kopirovani;
        private Button button_spusteni;
        private Button button_pridavani;
        private PictureBox pictureBox1;
        private Label label_userName;
        private Label label2;
        private PictureBox pictureBox_menuBar;
        private Button button_mazani;
        private Button button_sprava_winget;
        private Button button_sprava_instlaci;
    }
}