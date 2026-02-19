namespace Chytré_nástroje.Forms
{
    partial class SpravaWingetBalicku
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
            label1 = new Label();
            ProgramsComboBox = new ComboBox();
            VersionsCheckedListBox = new CheckedListBox();
            label2 = new Label();
            AddListButton = new Button();
            SuspendLayout();
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            name.Location = new Point(205, 9);
            name.Name = "name";
            name.Size = new Size(396, 45);
            name.TabIndex = 0;
            name.Text = "Správa Winget knihovny ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(32, 109);
            label1.Name = "label1";
            label1.Size = new Size(469, 20);
            label1.TabIndex = 2;
            label1.Text = "Vyberte prosím název programu u kterého chcete zjistit a vybrat verzi:";
            // 
            // ProgramsComboBox
            // 
            ProgramsComboBox.FormattingEnabled = true;
            ProgramsComboBox.Location = new Point(507, 110);
            ProgramsComboBox.Name = "ProgramsComboBox";
            ProgramsComboBox.Size = new Size(172, 23);
            ProgramsComboBox.TabIndex = 3;
            // 
            // VersionsCheckedListBox
            // 
            VersionsCheckedListBox.FormattingEnabled = true;
            VersionsCheckedListBox.Location = new Point(32, 201);
            VersionsCheckedListBox.Name = "VersionsCheckedListBox";
            VersionsCheckedListBox.Size = new Size(647, 202);
            VersionsCheckedListBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(32, 178);
            label2.Name = "label2";
            label2.Size = new Size(358, 20);
            label2.TabIndex = 5;
            label2.Text = "Vyberte prosím verzi, kterou chcete uložit do paměti:";
            // 
            // AddListButton
            // 
            AddListButton.Location = new Point(532, 409);
            AddListButton.Name = "AddListButton";
            AddListButton.Size = new Size(147, 23);
            AddListButton.TabIndex = 6;
            AddListButton.Text = "Přidat do seznamu";
            AddListButton.UseVisualStyleBackColor = true;
            // 
            // SpravaWingetBalicku
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddListButton);
            Controls.Add(label2);
            Controls.Add(VersionsCheckedListBox);
            Controls.Add(ProgramsComboBox);
            Controls.Add(label1);
            Controls.Add(name);
            Name = "SpravaWingetBalicku";
            Size = new Size(809, 521);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name;
        private Label label1;
        private ComboBox ProgramsComboBox;
        private CheckedListBox VersionsCheckedListBox;
        private Label label2;
        private Button AddListButton;
    }
}