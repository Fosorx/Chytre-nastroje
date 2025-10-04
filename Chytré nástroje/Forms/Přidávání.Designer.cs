namespace Chytré_nástroje
{
    partial class Přidávání
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
            label2 = new Label();
            AddUsersButton = new Button();
            label3 = new Label();
            YearOfGraduationTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            LetterClassTextBox = new TextBox();
            progressBar1 = new ProgressBar();
            Output = new Label();
            LogOpenButton = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(539, 108);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Vybrat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 104);
            label1.Name = "label1";
            label1.Size = new Size(256, 25);
            label1.TabIndex = 1;
            label1.Text = "Vyberte prosím Excel soubor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(620, 112);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 2;
            label2.Text = "Vybraný soubor:";
            label2.Visible = false;
            // 
            // AddUsersButton
            // 
            AddUsersButton.Enabled = false;
            AddUsersButton.Font = new Font("Segoe UI", 15F);
            AddUsersButton.Location = new Point(12, 258);
            AddUsersButton.Name = "AddUsersButton";
            AddUsersButton.Size = new Size(770, 41);
            AddUsersButton.TabIndex = 3;
            AddUsersButton.Text = "Přidat uživatele";
            AddUsersButton.UseVisualStyleBackColor = true;
            AddUsersButton.Click += AddUsersButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label3.Location = new Point(196, 9);
            label3.Name = "label3";
            label3.Size = new Size(409, 45);
            label3.TabIndex = 4;
            label3.Text = "Přidávání uživatelů do AD";
            // 
            // YearOfGraduationTextBox
            // 
            YearOfGraduationTextBox.Location = new Point(539, 147);
            YearOfGraduationTextBox.Name = "YearOfGraduationTextBox";
            YearOfGraduationTextBox.Size = new Size(75, 23);
            YearOfGraduationTextBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(12, 145);
            label4.Name = "label4";
            label4.Size = new Size(392, 25);
            label4.TabIndex = 6;
            label4.Text = "Napište prosím rok ukončení studia studentů:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(12, 187);
            label5.Name = "label5";
            label5.Size = new Size(342, 25);
            label5.TabIndex = 7;
            label5.Text = "Napište prosím písmeno třídy studentů:";
            // 
            // LetterClassTextBox
            // 
            LetterClassTextBox.Location = new Point(539, 194);
            LetterClassTextBox.Name = "LetterClassTextBox";
            LetterClassTextBox.Size = new Size(75, 23);
            LetterClassTextBox.TabIndex = 8;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 305);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(770, 23);
            progressBar1.TabIndex = 9;
            // 
            // Output
            // 
            Output.AutoSize = true;
            Output.Font = new Font("Segoe UI", 12F);
            Output.Location = new Point(247, 340);
            Output.Name = "Output";
            Output.Size = new Size(0, 21);
            Output.TabIndex = 10;
            // 
            // LogOpenButton
            // 
            LogOpenButton.Location = new Point(707, 344);
            LogOpenButton.Name = "LogOpenButton";
            LogOpenButton.Size = new Size(75, 23);
            LogOpenButton.TabIndex = 11;
            LogOpenButton.Text = "Log";
            LogOpenButton.UseVisualStyleBackColor = true;
            LogOpenButton.Click += button2_Click;
            // 
            // Přidávání
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 379);
            Controls.Add(LogOpenButton);
            Controls.Add(Output);
            Controls.Add(progressBar1);
            Controls.Add(LetterClassTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(YearOfGraduationTextBox);
            Controls.Add(label3);
            Controls.Add(AddUsersButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Přidávání";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Button AddUsersButton;
        private Label label3;
        private TextBox YearOfGraduationTextBox;
        private Label label4;
        private Label label5;
        private TextBox LetterClassTextBox;
        private ProgressBar progressBar1;
        private Label Output;
        private Button LogOpenButton;
    }
}
