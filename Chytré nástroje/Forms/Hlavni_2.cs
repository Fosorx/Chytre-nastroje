using Chytré_nástroje.Code;
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
    public partial class Hlavni_2 : Form
    {
        Database database = new Database();
        public Hlavni_2()
        {
            InitializeComponent();
        }
        private async void button_login_Click(object sender, EventArgs e)
        {
            await database.Login();
        }

        private void LoadUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panelForms.Controls.Clear();   // vyčistí panel
            panelForms.Controls.Add(uc);   // vloží nový UserControl
        }

    }
}
