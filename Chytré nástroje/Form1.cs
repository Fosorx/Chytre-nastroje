using Microsoft.Win32;
using System.Diagnostics;
using Hlavni_program;
using Kopirovani_souboru;

namespace Chytré_nástroje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mazani mazani = new Mazani();
            mazani.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kopirovani kopirovani = new Kopirovani();
            kopirovani.Show();
        }
    }
}
