namespace Chytré_nástroje.Forms
{
    partial class MazaniProfilu
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
            GetProfilesButton = new Button();
            ProfilesListBox = new ListBox();
            DeleteProfileButton = new Button();
            ProfileDetailsLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ComputerClassComboBox = new ComboBox();
            ComputersComboBox = new ComboBox();
            SuspendLayout();
            // 
            // GetProfilesButton
            // 
            GetProfilesButton.Location = new Point(34, 483);
            GetProfilesButton.Name = "GetProfilesButton";
            GetProfilesButton.Size = new Size(136, 23);
            GetProfilesButton.TabIndex = 3;
            GetProfilesButton.Text = "Získat data profilů";
            GetProfilesButton.UseVisualStyleBackColor = true;
            GetProfilesButton.Click += GetProfilesButton_Click;
            // 
            // ProfilesListBox
            // 
            ProfilesListBox.FormattingEnabled = true;
            ProfilesListBox.Location = new Point(34, 165);
            ProfilesListBox.Name = "ProfilesListBox";
            ProfilesListBox.Size = new Size(272, 244);
            ProfilesListBox.TabIndex = 4;
            ProfilesListBox.SelectedIndexChanged += ProfilesListBox_SelectedIndexChanged;
            // 
            // DeleteProfileButton
            // 
            DeleteProfileButton.Location = new Point(189, 483);
            DeleteProfileButton.Name = "DeleteProfileButton";
            DeleteProfileButton.Size = new Size(117, 23);
            DeleteProfileButton.TabIndex = 5;
            DeleteProfileButton.Text = "Vymazat vybraný profil";
            DeleteProfileButton.UseVisualStyleBackColor = true;
            DeleteProfileButton.Click += DeleteProfileButton_Click;
            // 
            // ProfileDetailsLabel
            // 
            ProfileDetailsLabel.AutoSize = true;
            ProfileDetailsLabel.Location = new Point(356, 202);
            ProfileDetailsLabel.Name = "ProfileDetailsLabel";
            ProfileDetailsLabel.Size = new Size(38, 15);
            ProfileDetailsLabel.TabIndex = 6;
            ProfileDetailsLabel.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(133, 11);
            label1.Name = "label1";
            label1.Size = new Size(586, 45);
            label1.TabIndex = 7;
            label1.Text = "Vzdálené mazání profilů na počítačích";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 147);
            label2.Name = "label2";
            label2.Size = new Size(155, 15);
            label2.TabIndex = 8;
            label2.Text = "Účty na vzdáleném počítači:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(356, 165);
            label3.Name = "label3";
            label3.Size = new Size(325, 25);
            label3.TabIndex = 9;
            label3.Text = "Detailní informace o vzdáleném účtu:";
            // 
            // ComputerClassComboBox
            // 
            ComputerClassComboBox.FormattingEnabled = true;
            ComputerClassComboBox.Items.AddRange(new object[] { "VT1", "VT2", "VT3", "VT4", "VT5", "ELM" });
            ComputerClassComboBox.Location = new Point(34, 433);
            ComputerClassComboBox.Name = "ComputerClassComboBox";
            ComputerClassComboBox.Size = new Size(121, 23);
            ComputerClassComboBox.TabIndex = 10;
            ComputerClassComboBox.SelectedIndexChanged += ComputerClassComboBox_SelectedIndexChanged;
            // 
            // ComputersComboBox
            // 
            ComputersComboBox.FormattingEnabled = true;
            ComputersComboBox.Location = new Point(185, 433);
            ComputersComboBox.Name = "ComputersComboBox";
            ComputersComboBox.Size = new Size(121, 23);
            ComputersComboBox.TabIndex = 11;
            // 
            // MazaniProfilu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ComputersComboBox);
            Controls.Add(ComputerClassComboBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ProfileDetailsLabel);
            Controls.Add(DeleteProfileButton);
            Controls.Add(ProfilesListBox);
            Controls.Add(GetProfilesButton);
            Name = "MazaniProfilu";
            Size = new Size(809, 521);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button GetProfilesButton;
        private ListBox ProfilesListBox;
        private Button DeleteProfileButton;
        private Label ProfileDetailsLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox ComputerClassComboBox;
        private ComboBox ComputersComboBox;
    }
}