namespace Kopirovani_souboru
{
    partial class Kopirovani
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
            openFileDialog1 = new OpenFileDialog();
            nadpis = new Label();
            namesView = new ListView();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button4 = new Button();
            label6 = new Label();
            button5 = new Button();
            label7 = new Label();
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(192, 76);
            button1.Name = "button1";
            button1.Size = new Size(386, 23);
            button1.TabIndex = 0;
            button1.Text = "Vybrat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // nadpis
            // 
            nadpis.AutoSize = true;
            nadpis.Font = new Font("Segoe UI", 14F);
            nadpis.Location = new Point(192, 38);
            nadpis.Name = "nadpis";
            nadpis.Size = new Size(386, 25);
            nadpis.TabIndex = 1;
            nadpis.Text = "Vyberte prosím textový soubor s jmény žáků.";
            // 
            // namesView
            // 
            namesView.Font = new Font("Segoe UI", 15F);
            namesView.Location = new Point(88, 142);
            namesView.Name = "namesView";
            namesView.Size = new Size(603, 62);
            namesView.TabIndex = 2;
            namesView.UseCompatibleStateImageBehavior = false;
            namesView.View = View.List;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(88, 276);
            label1.Name = "label1";
            label1.Size = new Size(210, 21);
            label1.TabIndex = 3;
            label1.Text = "Vybrat soubor ke kopírování:";
            // 
            // button2
            // 
            button2.Location = new Point(314, 277);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Vybrat";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(88, 311);
            label2.Name = "label2";
            label2.Size = new Size(205, 21);
            label2.TabIndex = 5;
            label2.Text = "Vybrat složku ke kopírování:";
            // 
            // button3
            // 
            button3.Location = new Point(314, 312);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Vybrat";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(300, 207);
            label3.Name = "label3";
            label3.Size = new Size(177, 15);
            label3.TabIndex = 7;
            label3.Text = "seznam žáků / seznam počítačů ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7F);
            label4.Location = new Point(413, 283);
            label4.Name = "label4";
            label4.Size = new Size(0, 12);
            label4.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7F);
            label5.Location = new Point(413, 320);
            label5.Name = "label5";
            label5.Size = new Size(0, 12);
            label5.TabIndex = 9;
            // 
            // button4
            // 
            button4.Location = new Point(88, 401);
            button4.Name = "button4";
            button4.Size = new Size(301, 23);
            button4.TabIndex = 10;
            button4.Text = "Kopírovat";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(93, 354);
            label6.Name = "label6";
            label6.Size = new Size(103, 21);
            label6.TabIndex = 11;
            label6.Text = "Cílová složka:";
            // 
            // button5
            // 
            button5.Location = new Point(314, 355);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 12;
            button5.Text = "Vybrat";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F);
            label7.Location = new Point(413, 363);
            label7.Name = "label7";
            label7.Size = new Size(0, 12);
            label7.TabIndex = 13;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(442, 401);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(325, 23);
            progressBar.TabIndex = 14;
            // 
            // Kopirovani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar);
            Controls.Add(label7);
            Controls.Add(button5);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(namesView);
            Controls.Add(nadpis);
            Controls.Add(button1);
            Name = "Kopirovani";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Label nadpis;
        private ListView namesView;
        private Label label1;
        private Button button2;
        private Label label2;
        private Button button3;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button4;
        private Label label6;
        private Button button5;
        private Label label7;
        private ProgressBar progressBar;
    }
}
