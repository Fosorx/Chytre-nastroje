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
    public partial class Login : Form
    {
        Database database = new Database();
        Cryptography cryptography = new Cryptography();
        
        public Login()
        {
            InitializeComponent();
        }
        private async void button_login_Click(object sender, EventArgs e)
        {
            if(await database.LoginAsync(textBox_userName.Text, cryptography.CreateSHA256(textBox_password.Text)))
            {
                MessageBox.Show($"Vítejte uživateli {textBox_userName.Text}");
            }
            else
            {
                MessageBox.Show($"Špatné uživatelské jméno nebo heslo. Zkuste to prosím znovu.");
            }
        }
    }
}
