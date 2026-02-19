namespace Chytré_nástroje.Forms
{
    partial class Hlavni2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hlavni2));
            panel_login = new Panel();
            SuspendLayout();
            // 
            // panel_login
            // 
            resources.ApplyResources(panel_login, "panel_login");
            panel_login.Name = "panel_login";
            // 
            // Hlavni2
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel_login);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Hlavni2";
            SizeGripStyle = SizeGripStyle.Hide;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_login;
    }
}