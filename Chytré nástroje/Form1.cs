using Microsoft.Win32;
using System.Diagnostics;
using Mazani_profilu;
using Kopirovani_souboru;
using Přidávání_uživatelů_do_AD;

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

        private void button4_Click(object sender, EventArgs e)
        {
            Přidávání přidávání = new Přidávání();
            přidávání.Show();
        }
    }
}
