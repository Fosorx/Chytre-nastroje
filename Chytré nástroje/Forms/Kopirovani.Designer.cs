namespace Chytré_nástroje
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
            chooseFolderNamesButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            nadpis = new Label();
            label1 = new Label();
            chooseFileButton = new Button();
            label2 = new Label();
            chooseFolderButton = new Button();
            label3 = new Label();
            CopyButton = new Button();
            label6 = new Label();
            chooseTargetFolderButton = new Button();
            progressBar = new ProgressBar();
            namesCheckBox = new CheckedListBox();
            selectedFile = new Label();
            selectedFolder = new Label();
            selectedTargetFolder = new Label();
            ChooseAllButton = new Button();
            checkComputer = new CheckBox();
            SuspendLayout();
            // 
            // chooseFolderNamesButton
            // 
            chooseFolderNamesButton.Location = new Point(395, 63);
            chooseFolderNamesButton.Name = "chooseFolderNamesButton";
            chooseFolderNamesButton.Size = new Size(343, 23);
            chooseFolderNamesButton.TabIndex = 0;
            chooseFolderNamesButton.Text = "Vybrat";
            chooseFolderNamesButton.UseVisualStyleBackColor = true;
            chooseFolderNamesButton.Click += chooseFolderNamesButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // nadpis
            // 
            nadpis.AutoSize = true;
            nadpis.Font = new Font("Segoe UI", 14F);
            nadpis.Location = new Point(391, 26);
            nadpis.Name = "nadpis";
            nadpis.Size = new Size(347, 25);
            nadpis.TabIndex = 1;
            nadpis.Text = "Vyberte prosím složku se složkami žáků.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(409, 118);
            label1.Name = "label1";
            label1.Size = new Size(210, 21);
            label1.TabIndex = 3;
            label1.Text = "Vybrat soubor ke kopírování:";
            // 
            // chooseFileButton
            // 
            chooseFileButton.Location = new Point(635, 119);
            chooseFileButton.Name = "chooseFileButton";
            chooseFileButton.Size = new Size(75, 23);
            chooseFileButton.TabIndex = 4;
            chooseFileButton.Text = "Vybrat";
            chooseFileButton.UseVisualStyleBackColor = true;
            chooseFileButton.Click += chooseFileButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(409, 153);
            label2.Name = "label2";
            label2.Size = new Size(205, 21);
            label2.TabIndex = 5;
            label2.Text = "Vybrat složku ke kopírování:";
            // 
            // chooseFolderButton
            // 
            chooseFolderButton.Location = new Point(635, 154);
            chooseFolderButton.Name = "chooseFolderButton";
            chooseFolderButton.Size = new Size(75, 23);
            chooseFolderButton.TabIndex = 6;
            chooseFolderButton.Text = "Vybrat";
            chooseFolderButton.UseVisualStyleBackColor = true;
            chooseFolderButton.Click += chooseFolderButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 375);
            label3.Name = "label3";
            label3.Size = new Size(177, 15);
            label3.TabIndex = 7;
            label3.Text = "seznam žáků / seznam počítačů ";
            // 
            // CopyButton
            // 
            CopyButton.Location = new Point(409, 243);
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new Size(301, 23);
            CopyButton.TabIndex = 10;
            CopyButton.Text = "Kopírovat";
            CopyButton.UseVisualStyleBackColor = true;
            CopyButton.Click += CopyButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(409, 196);
            label6.Name = "label6";
            label6.Size = new Size(103, 21);
            label6.TabIndex = 11;
            label6.Text = "Cílová složka:";
            // 
            // chooseTargetFolderButton
            // 
            chooseTargetFolderButton.Location = new Point(635, 197);
            chooseTargetFolderButton.Name = "chooseTargetFolderButton";
            chooseTargetFolderButton.Size = new Size(75, 23);
            chooseTargetFolderButton.TabIndex = 12;
            chooseTargetFolderButton.Text = "Vybrat";
            chooseTargetFolderButton.UseVisualStyleBackColor = true;
            chooseTargetFolderButton.Click += chooseTargetFolderButton_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(409, 286);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(301, 23);
            progressBar.TabIndex = 14;
            // 
            // namesCheckBox
            // 
            namesCheckBox.FormattingEnabled = true;
            namesCheckBox.Location = new Point(12, 26);
            namesCheckBox.Name = "namesCheckBox";
            namesCheckBox.Size = new Size(281, 346);
            namesCheckBox.TabIndex = 15;
            // 
            // selectedFile
            // 
            selectedFile.AutoSize = true;
            selectedFile.Location = new Point(728, 124);
            selectedFile.Name = "selectedFile";
            selectedFile.Size = new Size(0, 15);
            selectedFile.TabIndex = 16;
            // 
            // selectedFolder
            // 
            selectedFolder.AutoSize = true;
            selectedFolder.Location = new Point(728, 159);
            selectedFolder.Name = "selectedFolder";
            selectedFolder.Size = new Size(0, 15);
            selectedFolder.TabIndex = 17;
            // 
            // selectedTargetFolder
            // 
            selectedTargetFolder.AutoSize = true;
            selectedTargetFolder.Location = new Point(728, 201);
            selectedTargetFolder.Name = "selectedTargetFolder";
            selectedTargetFolder.Size = new Size(0, 15);
            selectedTargetFolder.TabIndex = 18;
            // 
            // ChooseAllButton
            // 
            ChooseAllButton.Location = new Point(50, 393);
            ChooseAllButton.Name = "ChooseAllButton";
            ChooseAllButton.Size = new Size(177, 23);
            ChooseAllButton.TabIndex = 19;
            ChooseAllButton.Text = "Označit / odznačit všechny";
            ChooseAllButton.UseVisualStyleBackColor = true;
            ChooseAllButton.Click += ChooseAllButton_Click;
            // 
            // checkComputer
            // 
            checkComputer.AutoSize = true;
            checkComputer.Location = new Point(233, 397);
            checkComputer.Name = "checkComputer";
            checkComputer.Size = new Size(71, 19);
            checkComputer.TabIndex = 20;
            checkComputer.Text = "Počítače";
            checkComputer.UseVisualStyleBackColor = true;
            checkComputer.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Kopirovani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(823, 450);
            Controls.Add(checkComputer);
            Controls.Add(ChooseAllButton);
            Controls.Add(selectedTargetFolder);
            Controls.Add(selectedFolder);
            Controls.Add(selectedFile);
            Controls.Add(namesCheckBox);
            Controls.Add(progressBar);
            Controls.Add(chooseTargetFolderButton);
            Controls.Add(label6);
            Controls.Add(CopyButton);
            Controls.Add(label3);
            Controls.Add(chooseFolderButton);
            Controls.Add(label2);
            Controls.Add(chooseFileButton);
            Controls.Add(label1);
            Controls.Add(nadpis);
            Controls.Add(chooseFolderNamesButton);
            HelpButton = true;
            Name = "Kopirovani";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kopírování souborů / složek";
            Load += Kopirovani_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button chooseFolderNamesButton;
        private OpenFileDialog openFileDialog1;
        private Label nadpis;
        private Label label1;
        private Button chooseFileButton;
        private Label label2;
        private Button chooseFolderButton;
        private Label label3;
        private Button CopyButton;
        private Label label6;
        private Button chooseTargetFolderButton;
        private ProgressBar progressBar;
        private CheckedListBox namesCheckBox;
        private Label selectedFile;
        private Label selectedFolder;
        private Label selectedTargetFolder;
        private Button ChooseAllButton;
        private CheckBox checkComputer;
    }
}
