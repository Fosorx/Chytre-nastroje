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
            label6 = new Label();
            PasswordUsersTextBox = new TextBox();
            UsersListView = new ListView();
            label7 = new Label();
            PathInformationButton = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(546, 161);
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
            label1.Location = new Point(19, 157);
            label1.Name = "label1";
            label1.Size = new Size(256, 25);
            label1.TabIndex = 1;
            label1.Text = "Vyberte prosím Excel soubor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 182);
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
            AddUsersButton.Location = new Point(19, 424);
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
            label3.Location = new Point(203, 28);
            label3.Name = "label3";
            label3.Size = new Size(409, 45);
            label3.TabIndex = 4;
            label3.Text = "Přidávání uživatelů do AD";
            // 
            // YearOfGraduationTextBox
            // 
            YearOfGraduationTextBox.Location = new Point(546, 225);
            YearOfGraduationTextBox.Name = "YearOfGraduationTextBox";
            YearOfGraduationTextBox.Size = new Size(100, 23);
            YearOfGraduationTextBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(19, 223);
            label4.Name = "label4";
            label4.Size = new Size(392, 25);
            label4.TabIndex = 6;
            label4.Text = "Napište prosím rok ukončení studia studentů:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(19, 265);
            label5.Name = "label5";
            label5.Size = new Size(342, 25);
            label5.TabIndex = 7;
            label5.Text = "Napište prosím písmeno třídy studentů:";
            // 
            // LetterClassTextBox
            // 
            LetterClassTextBox.Location = new Point(546, 272);
            LetterClassTextBox.Name = "LetterClassTextBox";
            LetterClassTextBox.Size = new Size(100, 23);
            LetterClassTextBox.TabIndex = 8;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(19, 471);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(770, 23);
            progressBar1.TabIndex = 9;
            // 
            // Output
            // 
            Output.AutoSize = true;
            Output.Font = new Font("Segoe UI", 12F);
            Output.Location = new Point(287, 510);
            Output.Name = "Output";
            Output.Size = new Size(0, 21);
            Output.TabIndex = 10;
            // 
            // LogOpenButton
            // 
            LogOpenButton.Location = new Point(571, 511);
            LogOpenButton.Name = "LogOpenButton";
            LogOpenButton.Size = new Size(75, 23);
            LogOpenButton.TabIndex = 11;
            LogOpenButton.Text = "Log";
            LogOpenButton.UseVisualStyleBackColor = true;
            LogOpenButton.Click += LogOpenButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(19, 304);
            label6.Name = "label6";
            label6.Size = new Size(379, 25);
            label6.TabIndex = 12;
            label6.Text = "Napište prosím heslo pro skupinu uživatelů:";
            // 
            // PasswordUsersTextBox
            // 
            PasswordUsersTextBox.Location = new Point(546, 306);
            PasswordUsersTextBox.Name = "PasswordUsersTextBox";
            PasswordUsersTextBox.Size = new Size(100, 23);
            PasswordUsersTextBox.TabIndex = 13;
            // 
            // UsersListView
            // 
            UsersListView.Font = new Font("Segoe UI", 11F);
            UsersListView.Location = new Point(19, 363);
            UsersListView.Name = "UsersListView";
            UsersListView.Size = new Size(770, 46);
            UsersListView.TabIndex = 14;
            UsersListView.UseCompatibleStateImageBehavior = false;
            UsersListView.View = View.List;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 342);
            label7.Name = "label7";
            label7.Size = new Size(156, 15);
            label7.TabIndex = 15;
            label7.Text = "Náhled vybraných uživatelů:";
            // 
            // PathInformationButton
            // 
            PathInformationButton.Location = new Point(663, 511);
            PathInformationButton.Name = "PathInformationButton";
            PathInformationButton.Size = new Size(126, 23);
            PathInformationButton.TabIndex = 16;
            PathInformationButton.Text = "Informace o cestách";
            PathInformationButton.UseVisualStyleBackColor = true;
            PathInformationButton.Click += PathInformationButton_Click;
            // 
            // Přidávání
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PathInformationButton);
            Controls.Add(label7);
            Controls.Add(UsersListView);
            Controls.Add(PasswordUsersTextBox);
            Controls.Add(label6);
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
            Size = new Size(825, 560);
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
        private Label label6;
        private TextBox PasswordUsersTextBox;
        private ListView UsersListView;
        private Label label7;
        private Button PathInformationButton;
    }
}
