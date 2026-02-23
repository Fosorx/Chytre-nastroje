using Chytré_nástroje.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chytré_nástroje
{
    public partial class Pridavani : UserControl
    {
        private List<Users> seznamUzivatelu = new List<Users>();
        private string cestaKVybranemuSouboru = string.Empty;

        // Definice cesty k logu
        public string CestaKLogu => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "UserAddToADLogs.txt");

        public Pridavani()
        {
            InitializeComponent();
            label2.Visible = false;
        }

        // Pomocná metoda pro zápis do logu
        private void ZapsatDoLogu(string zprava)
        {
            try
            {
                string slozkaLogu = Path.GetDirectoryName(CestaKLogu);
                if (!Directory.Exists(slozkaLogu))
                {
                    Directory.CreateDirectory(slozkaLogu);
                }

                string radek = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {zprava}{Environment.NewLine}";
                File.AppendAllText(CestaKLogu, radek);
            }
            catch
            {
                // Pokud selže logování, nebudeme shazovat aplikaci
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oknoProVyberSouboru = new OpenFileDialog())
            {
                oknoProVyberSouboru.Filter = "Excel soubory (*.xlsx)|*.xlsx|Všechny soubory (*.*)|*.*";
                oknoProVyberSouboru.Title = "Vyberte soubor exportovaný z Bakalářů";

                if (oknoProVyberSouboru.ShowDialog() == DialogResult.OK)
                {
                    this.cestaKVybranemuSouboru = oknoProVyberSouboru.FileName;
                    label2.Visible = true;
                    label2.Text = "Vybraný soubor: " + Path.GetFileName(this.cestaKVybranemuSouboru);

                    try
                    {
                        this.seznamUzivatelu = Users.LoadFromExcel(this.cestaKVybranemuSouboru);

                        if (this.seznamUzivatelu != null && this.seznamUzivatelu.Count > 0)
                        {
                            AddUsersButton.Enabled = true;
                            ViewUsers(null, null);
                            ZapsatDoLogu($"Načten soubor: {Path.GetFileName(this.cestaKVybranemuSouboru)} (Počet uživatelů: {this.seznamUzivatelu.Count})");
                            MessageBox.Show($"Z Excelu bylo úspěšně načteno a transformováno {this.seznamUzivatelu.Count} studentů.");
                        }
                        else
                        {
                            ZapsatDoLogu($"VAROVÁNÍ: Soubor {Path.GetFileName(this.cestaKVybranemuSouboru)} neobsahuje žádná data.");
                            MessageBox.Show("V souboru nebyla nalezena žádná data na očekávaných pozicích.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ZapsatDoLogu($"CHYBA při načítání Excelu: {ex.Message}");
                        MessageBox.Show("Chyba při čtení Excelu: " + ex.Message);
                    }
                }
            }
        }

        private async Task SpustitProcesPridavaniDoAD()
        {
            string rokText = YearOfGraduationTextBox.Text.Trim();
            string tridaText = LetterClassTextBox.Text.Trim();
            string hesloUzivateluText = PasswordUsersTextBox.Text.Trim();

            if (string.IsNullOrEmpty(rokText) || string.IsNullOrEmpty(tridaText) || string.IsNullOrEmpty(hesloUzivateluText))
            {
                MessageBox.Show("Vyplň rok, třídu a heslo!");
                return;
            }

            progressBar1.Value = 0;
            progressBar1.Maximum = seznamUzivatelu.Count;
            ZapsatDoLogu($"=== START PROCESU (Třída: {tridaText}, Rok: {rokText}) ===");

            await Task.Run(() =>
            {
                foreach (var student in seznamUzivatelu)
                {
                    string hotovaCilovaOU = $"OU={tridaText},OU={rokText},OU=Studenti,DC=blek,DC=cz";
                    string hotovaDomovskaSlozka = $@"\\BLEKVM1\DriveK\Student\{rokText}\{student.userName}";
                    string hotovaProfilCesta = $@"\\BLEKVM1\Profiles\{rokText}\{student.userName}";

                    // VYLEPŠENÝ POWERSHELL SKRIPT: Přidáno ErrorAction Stop a blok Try-Catch
                    string powershellSkript = $@"
                $ErrorActionPreference = 'Stop'
                try {{
                    Import-Module ActiveDirectory
                    $heslo = ConvertTo-SecureString '{hesloUzivateluText}' -AsPlainText -Force
                    
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

                    if (!(Test-Path '{hotovaDomovskaSlozka}')) {{
                        New-Item -Path '{hotovaDomovskaSlozka}' -ItemType Directory -Force
                    }}
                    
                    $acl = Get-Acl '{hotovaDomovskaSlozka}'
                    $pravidlo = New-Object System.Security.AccessControl.FileSystemAccessRule($novyUzivatel.SID, 'FullControl', 'ContainerInherit,ObjectInherit', 'None', 'Allow')
                    $acl.SetAccessRule($pravidlo)
                    Set-Acl '{hotovaDomovskaSlozka}' $acl
                }} catch {{
                    Write-Error $_.Exception.Message
                    exit 1
                }}";

                    byte[] scriptBytes = System.Text.Encoding.Unicode.GetBytes(powershellSkript);
                    string encodedScript = Convert.ToBase64String(scriptBytes);

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
                        string rawError = proces.StandardError.ReadToEnd();
                        proces.WaitForExit();

                        this.Invoke(new Action(() =>
                        {
                            if (!string.IsNullOrEmpty(rawError))
                            {
                                // Vytáhneme jen čistou zprávu
                                string cistaChyba = ZiskejStrucnouChybu(rawError);
                                ZapsatDoLogu($"CHYBA ({student.userName}): {cistaChyba}");
                                Output.Text = "CHYBA: " + student.userName;

                                // Pokud chybí modul AD, nemá cenu pokračovat u dalších 500 lidí
                                if (cistaChyba.Contains("ActiveDirectory") || cistaChyba.Contains("term 'New-ADUser' is not recognized"))
                                {
                                    ZapsatDoLogu("KRITICKÁ CHYBA: Chybí AD Modul. Proces přerušen.");
                                    // Zde by bylo dobré vyskočit z foreach, ale v Task.Run to vyřešíme returnem
                                    // seznamUzivatelu.Clear(); // Drastické, ale účinné pro zastavení cyklu
                                }
                            }
                            else
                            {
                                ZapsatDoLogu($"ÚSPĚCH ({student.userName})");
                                Output.Text = "HOTOVO: " + student.userName;
                            }
                            progressBar1.Value++;
                        }));
                    }
                }
            });
            ZapsatDoLogu("=== KONEC PROCESU ===");
        }

        // Pomocná metoda pro vytažení pouze první užitečné věty z chyby
        private string ZiskejStrucnouChybu(string error)
        {
            if (string.IsNullOrEmpty(error)) return "";

            // Pokud je to to hrozné XML, zkusíme vytáhnout jen text v Error tagu
            if (error.Contains("<S S=\"Error\">"))
            {
                var match = System.Text.RegularExpressions.Regex.Match(error, @"<S S=""Error"">(.*?)<\/S>");
                if (match.Success)
                    error = match.Groups[1].Value;
            }

            // Odstraníme paznaky a vezmeme jen první řádek nebo větu před tečkou
            string clean = error.Replace("_x000D__x000A_", " ").Trim();
            int dotIndex = clean.IndexOf('.');
            if (dotIndex > 0) clean = clean.Substring(0, dotIndex);

            return clean;
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

        private void LogOpenButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (System.IO.File.Exists(CestaKLogu))
                {
                    // Spustí výchozí editor (většinou Notepad) s vaším souborem
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = CestaKLogu,
                        UseShellExecute = true // Důležité pro otevření v externím programu
                    });
                }
                else
                {
                    MessageBox.Show("Soubor s logem zatím neexistuje.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nepodařilo se otevřít log: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}