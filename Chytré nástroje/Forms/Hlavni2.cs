using Chytré_nástroje.Code;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chytré_nástroje.Forms
{
    public partial class Hlavni2 : Form
    {
        private Panel panelPrograms;
        private Panel panelMenu;
        private Menu menuControl;

        public Hlavni2()
        {
            InitializeComponent();

            panelPrograms = DesignComponent.CreatePanel(265, 0, 825, 560, "Kopirovani");
            panelPrograms.Visible = false;
            this.Controls.Add(panelPrograms);

            panelMenu = DesignComponent.CreatePanel(0, 0, 265, 560, "Menu");
            panelMenu.Visible = false;
            this.Controls.Add(panelMenu);

            // Menu vytvoříme JEDNOU
            menuControl = new Menu();
            menuControl.ButtonSpusteni += LoadControlSpusteni;
            menuControl.ButtonKopirovani += LoadControlKopirovani;
            menuControl.PictureBox_MenuBar += ChangePictureBarMenu;
            menuControl.ButtonPridavani += LoadControlPridavani;
            menuControl.ButtonMazani += LoadControlMazani;
            //menuControl.PictureBox_MenuBar;


            LoadControlLogin();
        }

        public void LoadControlLogin()
        {
            var loginControl = new Login();
            loginControl.Dock = DockStyle.Fill;

            loginControl.LoginSuccess += () =>
            {
                LoadControlKopirovani();
                LoadControlMenu();
            };

            panel_login.Controls.Clear();
            panel_login.Controls.Add(loginControl);
        }

        public void LoadControlMenu()
        {
            panelMenu.Visible = true;

            menuControl.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(menuControl);
        }

        public void LoadControlKopirovani()
        {
            panelPrograms.Visible = true;
            panel_login.Visible = false;

            var kopirovani = new Kopirovani();
            kopirovani.Dock = DockStyle.Fill;

            panelPrograms.Controls.Clear();
            panelPrograms.Controls.Add(kopirovani);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        public void LoadControlSpusteni()
        {
            var spusteni = new Spusteni();
            spusteni.Dock = DockStyle.Fill;

            panelPrograms.Controls.Clear();
            panelPrograms.Controls.Add(spusteni);
        }

        public void LoadControlPridavani()
        {
            var pridavani = new Přidávání();
            pridavani.Dock = DockStyle.Fill;

            panelPrograms.Controls.Clear();
            panelPrograms.Controls.Add(pridavani);
        }

        public void LoadControlMazani()
        {
            var mazani = new MazaniProfilu();
            mazani.Dock = DockStyle.Fill;
            panelPrograms.Controls.Clear();
            panelPrograms.Controls.Add(mazani);
        }

        public void ChangePictureBarMenu()
        {
            if (menuControl.Is_Picture_Cross)
            {
                panelMenu.Size = new Size(50, panelMenu.Size.Height);
                panelPrograms.Location = new Point(50, 0);
            }
            else
            {
                panelMenu.Size = new Size(265, panelMenu.Size.Height);
                panelPrograms.Location = new Point(265, 0);
            }
        }
    }
}
