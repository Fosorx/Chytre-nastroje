namespace Chytré_nástroje
{
    partial class Hlavni
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(201, 190);
            button1.Name = "button1";
            button1.Size = new Size(432, 49);
            button1.TabIndex = 0;
            button1.Text = "Vymazání profilů";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(107, 102);
            label1.Name = "label1";
            label1.Size = new Size(609, 46);
            label1.TabIndex = 1;
            label1.Text = "Vítejte v programu chytrých nástrojů";
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(201, 245);
            button2.Name = "button2";
            button2.Size = new Size(432, 49);
            button2.TabIndex = 2;
            button2.Text = "Vymazání souborů na systémovém disku";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 15F);
            button3.Location = new Point(201, 300);
            button3.Name = "button3";
            button3.Size = new Size(432, 49);
            button3.TabIndex = 3;
            button3.Text = "Kopírování souboru/složky do více složek";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 15F);
            button4.Location = new Point(201, 355);
            button4.Name = "button4";
            button4.Size = new Size(432, 49);
            button4.TabIndex = 4;
            button4.Text = "Přidávání uživatelů do AD";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 15F);
            button5.Location = new Point(201, 410);
            button5.Name = "button5";
            button5.Size = new Size(432, 49);
            button5.TabIndex = 5;
            button5.Text = "Hromadné spuštění programu";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(728, 471);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 6;
            label2.Text = "Verze programu: 1.2.0";
            // 
            // Hlavni
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 495);
            Controls.Add(label2);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Hlavni";
            Text = "Menu";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label2;
    }
}
