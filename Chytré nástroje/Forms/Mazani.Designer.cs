namespace Chytré_nástroje
{
    partial class Mazani
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
            progressBar = new ProgressBar();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            ProfilesInRegisterList = new CheckedListBox();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(39, 355);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(472, 23);
            progressBar.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.ForeColor = Color.Lime;
            label2.Location = new Point(618, 239);
            label2.Name = "label2";
            label2.Size = new Size(113, 28);
            label2.TabIndex = 8;
            label2.Text = "Dokončeno";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(39, 72);
            label1.Name = "label1";
            label1.Size = new Size(337, 28);
            label1.TabIndex = 7;
            label1.Text = "Vyberte prosím jeden z těchto profilů";
            // 
            // button1
            // 
            button1.Location = new Point(586, 176);
            button1.Name = "button1";
            button1.Size = new Size(175, 31);
            button1.TabIndex = 6;
            button1.Text = "Vymazat profily";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ProfilesInRegisterList
            // 
            ProfilesInRegisterList.FormattingEnabled = true;
            ProfilesInRegisterList.Location = new Point(39, 112);
            ProfilesInRegisterList.Name = "ProfilesInRegisterList";
            ProfilesInRegisterList.Size = new Size(472, 202);
            ProfilesInRegisterList.TabIndex = 5;
            // 
            // Mazani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(ProfilesInRegisterList);
            Name = "Mazani";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar;
        private Label label2;
        private Label label1;
        private Button button1;
        private CheckedListBox ProfilesInRegisterList;
    }
}
