using Microsoft.Win32;
using Chytré_nástroje.Code;
using System.Diagnostics;
using Chytré_nástroje.Forms;

namespace Chytré_nástroje
{
    public partial class Hlavni : Form
    {
        public Hlavni()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdate();
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
            MessageBox.Show("UPOZORNĚNÍ: Tato funkce funguje pouze na Windows servers. Děkujeme za pochopení.");
            Přidávání přidávání = new Přidávání();
            přidávání.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hlavni_2 hlavni_2 = new Hlavni_2();
            hlavni_2.Show();
            //Spusteni spusteni = new Spusteni();
            //spusteni.Show();
        }

        private async Task AutoUpdate()
        {
            var updater = new AutoUpdate();
            await updater.CheckForUpdateAsync();
        }
    }
}
