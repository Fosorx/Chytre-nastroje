using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chytré_nástroje.Code;

namespace Chytré_nástroje
{
    public partial class Přidávání : UserControl
    {
        private List<Users> seznamUzivatelu = new List<Users>();
        private string cestaKVybranemuSouboru = string.Empty;

        public Přidávání()
        {
            InitializeComponent();
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oknoProVyberSouboru = new OpenFileDialog())
            {
                // Změna filtru na Excel soubory
                oknoProVyberSouboru.Filter = "Excel soubory (*.xlsx)|*.xlsx|Všechny soubory (*.*)|*.*";
                oknoProVyberSouboru.Title = "Vyberte soubor exportovaný z Bakalářů";

                if (oknoProVyberSouboru.ShowDialog() == DialogResult.OK)
                {
                    this.cestaKVybranemuSouboru = oknoProVyberSouboru.FileName;

                    // Volitelný label pro zobrazení názvu souboru
                    label2.Visible = true;
                    label2.Text = "Vybraný soubor: " + Path.GetFileName(this.cestaKVybranemuSouboru);

                    try
                    {
                        // Místo JSON deserializace zavoláme naši metodu pro Excel
                        this.seznamUzivatelu = Users.LoadFromExcel(this.cestaKVybranemuSouboru);

                        if (this.seznamUzivatelu != null && this.seznamUzivatelu.Count > 0)
                        {
                            AddUsersButton.Enabled = true;

                            // Předpokládám, že tato metoda vykresluje data do nějakého gridu nebo listu
                            ViewUsers(null, null);

                            MessageBox.Show($"Z Excelu bylo úspěšně načteno a transformováno {this.seznamUzivatelu.Count} studentů.");
                        }
                        else
                        {
                            MessageBox.Show("V souboru nebyla nalezena žádná data na očekávaných pozicích.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // ClosedXML může vyhodit chybu, pokud je soubor např. otevřený v Excelu
                        MessageBox.Show("Chyba při čtení Excelu: " + ex.Message +
                            "\n\nUjistěte se, že soubor není otevřen v jiném programu.");
                    }
                }
            }
        }

        private async Task SpustitProcesPridavaniDoAD()
        {
            string rokText = YearOfGraduationTextBox.Text.Trim();
            string tridaText = LetterClassTextBox.Text.Trim();
            string hesloUzivateluText = PasswordUsersTextBox.Text.Trim();

            if (string.IsNullOrEmpty(rokText) || string.IsNullOrEmpty(tridaText))
            {
                MessageBox.Show("Vyplň rok a třídu!");
                return;
            }
            else if (string.IsNullOrEmpty(hesloUzivateluText))
            {
                MessageBox.Show("Vyplň heslo pro uživatele!");
                return;
            }

            progressBar1.Value = 0;
            progressBar1.Maximum = seznamUzivatelu.Count;

            await Task.Run(() =>
            {
                foreach (var student in seznamUzivatelu)
                {
                    // Sestavíme cesty přímo v C#
                    string hotovaCilovaOU = $"OU={tridaText},OU={rokText},OU=Studenti,DC=blek,DC=cz";
                    string hotovaDomovskaSlozka = $@"\\BLEKVM1\DriveK\Student\{rokText}\{student.userName}";
                    string hotovaProfilCesta = $@"\\BLEKVM1\Profiles\{rokText}\{student.userName}";

                    // Sestavíme skript jako jeden řádek pro příkazovou řádku
                    // Používáme -EncodedCommand, aby se nerozbila diakritika
                    // Sestavíme skript jako jeden řádek
                    string powershellSkript = $@"
                        Import-Module ActiveDirectory
                        $heslo = ConvertTo-SecureString '{hesloUzivateluText}' -AsPlainText -Force
    
                        # Přidán parametr -DisplayName
                        $novyUzivatel = New-ADUser -Name '{student.name} {student.surname}' `
                                       -DisplayName '{student.name} {student.surname}' `
                                       -GivenName '{student.name}' `
                                       -Surname '{student.surname}' `
                                       -SamAccountName '{student.userName}' `
                                       -UserPrincipalName '{student.userName}@blek.cz' `
                                       -Path '{hotovaCilovaOU}' `
                                       -AccountPassword $heslo `
                                       -Enabled $true `
                                       -ProfilePath '{hotovaProfilCesta}' `
                                       -HomeDirectory '{hotovaDomovskaSlozka}' `
                                       -HomeDrive 'K:' `
                                       -ChangePasswordAtLogon $true -PassThru

                        New-Item -Path '{hotovaDomovskaSlozka}' -ItemType Directory -Force
                        $acl = Get-Acl '{hotovaDomovskaSlozka}'
                        $pravidlo = New-Object System.Security.AccessControl.FileSystemAccessRule($novyUzivatel.SID, 'FullControl', 'ContainerInherit,ObjectInherit', 'None', 'Allow')
                        $acl.SetAccessRule($pravidlo)
                        Set-Acl '{hotovaDomovskaSlozka}' $acl";

                    // Převedeme skript na Base64, aby ho PowerShell pobral bez problémů s uvozovkami
                    byte[] scriptBytes = System.Text.Encoding.Unicode.GetBytes(powershellSkript);
                    string encodedScript = Convert.ToBase64String(scriptBytes);

                    // Spustíme proces powershell.exe
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -ExecutionPolicy Bypass -EncodedCommand {encodedScript}",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardError = true
                    };

                    using (var proces = System.Diagnostics.Process.Start(psi))
                    {
                        string error = proces.StandardError.ReadToEnd();
                        proces.WaitForExit();

                        this.Invoke(new Action(() =>
                        {
                            if (!string.IsNullOrEmpty(error))
                            {
                                Output.Text = "CHYBA: " + student.userName;
                                // Pokud chceš vidět přesnou chybu, odkomentuj: MessageBox.Show(error);
                            }
                            else
                            {
                                Output.Text = "HOTOVO: " + student.userName;
                            }
                            progressBar1.Value++;
                        }));
                    }
                }
            });
        }

        private void ViewUsers(object sender, EventArgs e)
        {
            UsersListView.Items.Clear();
            foreach (var student in seznamUzivatelu)
            {
                var item = new ListViewItem(student.userName);
                UsersListView.Items.Add(item);
            }
        }

        private async void AddUsersButton_Click(object sender, EventArgs e)
        {
            await SpustitProcesPridavaniDoAD();
        }

        private void PathInformationButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OU pro třídu: OU={třída},OU={rok},OU=Studenti,DC=blek,DC=cz\n" +
                "Domovská složka: \\\\BLEKVM1\\DriveK\\Student\\{rok}\\{uživatelské_jméno}\n" +
                "Profilová cesta: \\\\BLEKVM1\\Profiles\\{rok}\\{uživatelské_jméno}");
        }
    }
}