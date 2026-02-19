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
    public partial class Login : UserControl
    {
        Database database = new Database();
        Cryptography cryptography = new Cryptography();

        public event Action LoginSuccess;

        public Login()
        {
            InitializeComponent();
        }
        private async void button_login_Click(object sender, EventArgs e)
        {
            //await database.LoginAsync(textBox_userName.Text, cryptography.CreateSHA256(textBox_password.Text)))
            if (textBox_userName.Text == "admin" && textBox_password.Text == "admin")
            {
                MessageBox.Show($"Vítejte uživateli {textBox_userName.Text}");
                LoginSuccess?.Invoke();
            }
            else
            {
                MessageBox.Show($"Špatné uživatelské jméno nebo heslo. Zkuste to prosím znovu.");
            }
        }
    }
}
