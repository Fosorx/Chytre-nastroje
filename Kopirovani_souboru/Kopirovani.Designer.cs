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
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            label3 = new Label();
            button4 = new Button();
            label6 = new Label();
            button5 = new Button();
            progressBar = new ProgressBar();
            namesCheckBox = new CheckedListBox();
            selectedFile = new Label();
            selectedFolder = new Label();
            selectedTargetFolder = new Label();
            ChooseAllButton = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(395, 63);
            button1.Name = "button1";
            button1.Size = new Size(343, 23);
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
            // button2
            // 
            button2.Location = new Point(635, 119);
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
            label2.Location = new Point(409, 153);
            label2.Name = "label2";
            label2.Size = new Size(205, 21);
            label2.TabIndex = 5;
            label2.Text = "Vybrat složku ke kopírování:";
            // 
            // button3
            // 
            button3.Location = new Point(635, 154);
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
            label3.Location = new Point(50, 375);
            label3.Name = "label3";
            label3.Size = new Size(177, 15);
            label3.TabIndex = 7;
            label3.Text = "seznam žáků / seznam počítačů ";
            label3.Click += label3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(409, 243);
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
            label6.Location = new Point(409, 196);
            label6.Name = "label6";
            label6.Size = new Size(103, 21);
            label6.TabIndex = 11;
            label6.Text = "Cílová složka:";
            // 
            // button5
            // 
            button5.Location = new Point(635, 197);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 12;
            button5.Text = "Vybrat";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(409, 320);
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
            // Kopirovani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(823, 450);
            Controls.Add(ChooseAllButton);
            Controls.Add(selectedTargetFolder);
            Controls.Add(selectedFolder);
            Controls.Add(selectedFile);
            Controls.Add(namesCheckBox);
            Controls.Add(progressBar);
            Controls.Add(button5);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(nadpis);
            Controls.Add(button1);
            HelpButton = true;
            Name = "Kopirovani";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kopírování souborů / složek";
            Load += Kopirovani_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Label nadpis;
        private Label label1;
        private Button button2;
        private Label label2;
        private Button button3;
        private Label label3;
        private Button button4;
        private Label label6;
        private Button button5;
        private ProgressBar progressBar;
        private CheckedListBox namesCheckBox;
        private Label selectedFile;
        private Label selectedFolder;
        private Label selectedTargetFolder;
        private Button ChooseAllButton;
    }
}
