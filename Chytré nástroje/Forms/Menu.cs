using Chytré_nástroje.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chytré_nástroje.Forms
{
    public partial class Menu : UserControl
    {
        public event Action ButtonSpusteni;
        public event Action ButtonKopirovani;
        public event Action ButtonPridavani;
        public event Action PictureBox_MenuBar;

        public bool Is_Picture_Cross;

        public Menu()
        {
            InitializeComponent();
            pictureBox_menuBar.Image = Resources.cross_small;
            Is_Picture_Cross = true;
        }

        private void button_spusteni_Click(object sender, EventArgs e)
        {
            ButtonSpusteni?.Invoke();
        }

        private void button_kopirovani_Click(object sender, EventArgs e)
        {
            ButtonKopirovani?.Invoke();
        }

        private void button_pridavani_Click(object sender, EventArgs e)
        {
            ButtonPridavani?.Invoke();
        }

        private void pictureBox_menuBar_Click(object sender, EventArgs e)
        {
            if (Is_Picture_Cross)
            {
                button_spusteni.Visible = false;
                button_kopirovani.Visible = false;
                button_pridavani.Visible = false;
                pictureBox1.Visible = false;
                label_userName.Visible = false;
                label2.Visible = false;

                pictureBox_menuBar.Image = Resources.menu_burger;

                PictureBox_MenuBar?.Invoke();

                Is_Picture_Cross = false;

            }
            else
            {
                button_spusteni.Visible = true;
                button_kopirovani.Visible = true;
                button_pridavani.Visible = true;
                pictureBox1.Visible = true;
                label_userName.Visible = true;
                label2.Visible = true;

                pictureBox_menuBar.Image = Resources.cross_small;

                PictureBox_MenuBar?.Invoke();

                Is_Picture_Cross = true;
            }
        }

    }
}
