namespace Chytré_nástroje.Forms
{
    partial class SpravaPocitacovychProgramu
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
            name = new Label();
            ProgramsListBox = new ListBox();
            label1 = new Label();
            GetProgramsButton = new Button();
            UpdateButton = new Button();
            InstallButton = new Button();
            label2 = new Label();
            ComputerClassComboBox = new ComboBox();
            ProgramsUpdatesListBox = new ListBox();
            SuccessCountLabel = new Label();
            label3 = new Label();
            CheckUpdatesButton = new Button();
            ChooseUpdatesButtons = new Button();
            AllUpdatesButton = new Button();
            SuspendLayout();
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            name.Location = new Point(84, 9);
            name.Name = "name";
            name.Size = new Size(620, 30);
            name.TabIndex = 0;
            name.Text = "Instalace a aktualizace programů pomocí Winget knihovny";
            // 
            // ProgramsListBox
            // 
            ProgramsListBox.FormattingEnabled = true;
            ProgramsListBox.Location = new Point(22, 102);
            ProgramsListBox.Name = "ProgramsListBox";
            ProgramsListBox.Size = new Size(317, 289);
            ProgramsListBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 77);
            label1.Name = "label1";
            label1.Size = new Size(177, 15);
            label1.TabIndex = 2;
            label1.Text = "Uložené názvy a verze programů";
            // 
            // GetProgramsButton
            // 
            GetProgramsButton.Location = new Point(229, 73);
            GetProgramsButton.Name = "GetProgramsButton";
            GetProgramsButton.Size = new Size(110, 23);
            GetProgramsButton.TabIndex = 3;
            GetProgramsButton.Text = "Vložit obsah listu";
            GetProgramsButton.UseVisualStyleBackColor = true;
            GetProgramsButton.Click += GetProgramsButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(164, 432);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(94, 23);
            UpdateButton.TabIndex = 4;
            UpdateButton.Text = "Aktualizoavat";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // InstallButton
            // 
            InstallButton.Location = new Point(264, 432);
            InstallButton.Name = "InstallButton";
            InstallButton.Size = new Size(75, 23);
            InstallButton.TabIndex = 5;
            InstallButton.Text = "Instalovat";
            InstallButton.UseVisualStyleBackColor = true;
            InstallButton.Click += InstallButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 405);
            label2.Name = "label2";
            label2.Size = new Size(284, 15);
            label2.TabIndex = 6;
            label2.Text = "Vyberte učebnu, ve které se má tento příkaz vykonat:";
            // 
            // ComputerClassComboBox
            // 
            ComputerClassComboBox.FormattingEnabled = true;
            ComputerClassComboBox.Location = new Point(22, 432);
            ComputerClassComboBox.Name = "ComputerClassComboBox";
            ComputerClassComboBox.Size = new Size(121, 23);
            ComputerClassComboBox.TabIndex = 7;
            // 
            // ProgramsUpdatesListBox
            // 
            ProgramsUpdatesListBox.FormattingEnabled = true;
            ProgramsUpdatesListBox.HorizontalScrollbar = true;
            ProgramsUpdatesListBox.Location = new Point(405, 102);
            ProgramsUpdatesListBox.Name = "ProgramsUpdatesListBox";
            ProgramsUpdatesListBox.SelectionMode = SelectionMode.MultiExtended;
            ProgramsUpdatesListBox.Size = new Size(389, 289);
            ProgramsUpdatesListBox.TabIndex = 8;
            // 
            // SuccessCountLabel
            // 
            SuccessCountLabel.AutoSize = true;
            SuccessCountLabel.Location = new Point(22, 483);
            SuccessCountLabel.Name = "SuccessCountLabel";
            SuccessCountLabel.Size = new Size(0, 15);
            SuccessCountLabel.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(405, 77);
            label3.Name = "label3";
            label3.Size = new Size(165, 15);
            label3.TabIndex = 10;
            label3.Text = "Načíst programy k aktualizaci:";
            // 
            // CheckUpdatesButton
            // 
            CheckUpdatesButton.Location = new Point(719, 73);
            CheckUpdatesButton.Name = "CheckUpdatesButton";
            CheckUpdatesButton.Size = new Size(75, 23);
            CheckUpdatesButton.TabIndex = 11;
            CheckUpdatesButton.Text = "Načíst";
            CheckUpdatesButton.UseVisualStyleBackColor = true;
            CheckUpdatesButton.Click += CheckUpdatesButton_Click;
            // 
            // ChooseUpdatesButtons
            // 
            ChooseUpdatesButtons.Location = new Point(405, 431);
            ChooseUpdatesButtons.Name = "ChooseUpdatesButtons";
            ChooseUpdatesButtons.Size = new Size(138, 23);
            ChooseUpdatesButtons.TabIndex = 12;
            ChooseUpdatesButtons.Text = "Aktualizovat vybrané";
            ChooseUpdatesButtons.UseVisualStyleBackColor = true;
            ChooseUpdatesButtons.Click += ChooseUpdatesButtons_Click;
            // 
            // AllUpdatesButton
            // 
            AllUpdatesButton.Location = new Point(661, 431);
            AllUpdatesButton.Name = "AllUpdatesButton";
            AllUpdatesButton.Size = new Size(133, 23);
            AllUpdatesButton.TabIndex = 13;
            AllUpdatesButton.Text = "Aktualizovat všechno";
            AllUpdatesButton.UseVisualStyleBackColor = true;
            AllUpdatesButton.Click += AllUpdatesButton_Click;
            // 
            // SpravaPocitacovychProgramu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AllUpdatesButton);
            Controls.Add(ChooseUpdatesButtons);
            Controls.Add(CheckUpdatesButton);
            Controls.Add(label3);
            Controls.Add(SuccessCountLabel);
            Controls.Add(ProgramsUpdatesListBox);
            Controls.Add(ComputerClassComboBox);
            Controls.Add(label2);
            Controls.Add(InstallButton);
            Controls.Add(UpdateButton);
            Controls.Add(GetProgramsButton);
            Controls.Add(label1);
            Controls.Add(ProgramsListBox);
            Controls.Add(name);
            Name = "SpravaPocitacovychProgramu";
            Size = new Size(809, 521);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name;
        private ListBox ProgramsListBox;
        private Label label1;
        private Button GetProgramsButton;
        private Button UpdateButton;
        private Button InstallButton;
        private Label label2;
        private ComboBox ComputerClassComboBox;
        private ListBox ProgramsUpdatesListBox;
        private Label SuccessCountLabel;
        private Label label3;
        private Button CheckUpdatesButton;
        private Button ChooseUpdatesButtons;
        private Button AllUpdatesButton;
    }
}