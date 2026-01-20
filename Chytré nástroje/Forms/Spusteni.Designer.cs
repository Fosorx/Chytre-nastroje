namespace Chytré_nástroje
{
    partial class Spusteni
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
            checkedComputersBox = new CheckedListBox();
            chooseAllButton = new Button();
            label1 = new Label();
            label2 = new Label();
            passwordTextBox = new TextBox();
            label3 = new Label();
            programPathTextBox = new TextBox();
            startButton = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // checkedComputersBox
            // 
            checkedComputersBox.FormattingEnabled = true;
            checkedComputersBox.ImeMode = ImeMode.NoControl;
            checkedComputersBox.Items.AddRange(new object[] { "VT1", "VT2", "VT3", "VT4", "VT5", "ELM" });
            checkedComputersBox.Location = new Point(43, 193);
            checkedComputersBox.Name = "checkedComputersBox";
            checkedComputersBox.RightToLeft = RightToLeft.No;
            checkedComputersBox.Size = new Size(105, 130);
            checkedComputersBox.TabIndex = 0;
            checkedComputersBox.ItemCheck += checkedComputersBox_ItemCheck;
            // 
            // chooseAllButton
            // 
            chooseAllButton.Enabled = false;
            chooseAllButton.Location = new Point(55, 329);
            chooseAllButton.Name = "chooseAllButton";
            chooseAllButton.Size = new Size(75, 23);
            chooseAllButton.TabIndex = 1;
            chooseAllButton.Text = "Vybrat vše";
            chooseAllButton.UseVisualStyleBackColor = true;
            chooseAllButton.Click += chooseAllButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(158, 25);
            label1.Name = "label1";
            label1.Size = new Size(524, 46);
            label1.TabIndex = 2;
            label1.Text = "Hromadné spouštení programu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(195, 197);
            label2.Name = "label2";
            label2.Size = new Size(140, 21);
            label2.TabIndex = 3;
            label2.Text = "Zadejte vaše heslo:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(490, 195);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(257, 23);
            passwordTextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(195, 242);
            label3.Name = "label3";
            label3.Size = new Size(261, 21);
            label3.TabIndex = 5;
            label3.Text = "Zadejte cestu nebo název programu:";
            // 
            // programPathTextBox
            // 
            programPathTextBox.Location = new Point(490, 242);
            programPathTextBox.Name = "programPathTextBox";
            programPathTextBox.Size = new Size(257, 23);
            programPathTextBox.TabIndex = 6;
            // 
            // startButton
            // 
            startButton.Location = new Point(195, 318);
            startButton.Name = "startButton";
            startButton.Size = new Size(552, 23);
            startButton.TabIndex = 7;
            startButton.Text = "Spustit";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(195, 401);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 8;
            // 
            // Spusteni
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(startButton);
            Controls.Add(programPathTextBox);
            Controls.Add(label3);
            Controls.Add(passwordTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chooseAllButton);
            Controls.Add(checkedComputersBox);
            Name = "Spusteni";
            Size = new Size(825, 560);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedComputersBox;
        private Button chooseAllButton;
        private Label label1;
        private Label label2;
        private TextBox passwordTextBox;
        private Label label3;
        private TextBox programPathTextBox;
        private Button startButton;
        private Label label4;
    }
}
