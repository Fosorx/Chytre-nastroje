using Chytré_nástroje.Code;
using ClosedXML.Excel;
using Microsoft.VisualBasic.ApplicationServices;
using System.Management.Automation;

namespace Chytré_nástroje
{
    public partial class Přidávání : Form
    {
        public Přidávání()
        {
            InitializeComponent();
        }

        Users Users;

        string filePath = string.Empty;
        List<Users> users_list = new List<Users>();

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel files (*.xlsx;*.xlsm)|*.xlsx;*.xlsm";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    label2.Visible = true;
                    label2.Text = "Vybraný soubor: " + filePath;
                    AddUsersButton.Enabled = true;
                    users_list = LoadFromExcel();
                }
            }
        }

        private List<Users> LoadFromExcel()
        {
            var users = new List<Users>();


            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                var rows = worksheet.RangeUsed().RowsUsed().Skip(2);

                foreach (var row in rows)
                {
                    if (!row.Cell(1).IsEmpty())
                    {
                        string _name = row.Cell(4).GetString();
                        string _surname = row.Cell(5).GetString();
                        string _userName = row.Cell(6).GetString();

                        users.Add(new Users { name = _name, surname = _surname, userName = _userName });
                    }
                }
            }
            return users;
        }

        private async Task AddUsersToAD()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = users_list.Count;
            progressBar1.Value = 0;

            await Task.Run(() =>
            {
                using PowerShell ps = PowerShell.Create();

                ps.AddScript("Set-ExecutionPolicy Bypass -Scope Process -Force; Import-Module ActiveDirectory").Invoke();
                ps.Commands.Clear();

                foreach (var user in users_list)
                {
                    string profilePath = $@"\\BLEKVM1\Profiles\{YearOfGraduationTextBox.Text}\{user.userName}";
                    string homeDirectory = $@"\\BLEKVM1\DriveK\Student\{YearOfGraduationTextBox.Text}\{user.userName}";

                    string script = @"
                    param($username, $firstname, $lastname, $domain, $profilePath, $homeDirectory, $yearOfGraduation, $class)

                    New-ADUser -Name ""$firstname $lastname"" `
                               -GivenName $firstname `
                               -Surname $lastname `
                               -SamAccountName $username `
                               -UserPrincipalName ""$username@$domain"" `
                               -Path ""OU=$class,OU=$yearOfGraduation,OU=Studenti,DC=blek,DC=cz"" `
                               -AccountPassword (ConvertTo-SecureString ""asdfASDF1234!"" -AsPlainText -Force) `
                               -Enabled $true `
                               -ProfilePath $profilePath `
                               -HomeDirectory $homeDirectory `
                               -HomeDrive ""K:"" `
                               -ChangePasswordAtLogon $true

                    if (-not (Test-Path $homeDirectory)) {
                        New-Item -ItemType Directory -Path $homeDirectory -Force | Out-Null
                    }

                    $acl = Get-Acl $homeDirectory
                    $identity = ""$domain\$username""
                    $rule = New-Object System.Security.AccessControl.FileSystemAccessRule(
                        $identity, ""FullControl"", ""ContainerInherit,ObjectInherit"", ""None"", ""Allow""
                    )
                    $acl.SetAccessRule($rule)
                    Set-Acl $homeDirectory $acl
                ";

                    ps.AddScript(script)
                      .AddParameter("username", user.userName)
                      .AddParameter("firstname", user.name)
                      .AddParameter("lastname", user.surname)
                      .AddParameter("domain", "BLEK.CZ")
                      .AddParameter("profilePath", profilePath)
                      .AddParameter("homeDirectory", homeDirectory)
                      .AddParameter("yearOfGraduation", YearOfGraduationTextBox.Text)
                      .AddParameter("class", LetterClassTextBox.Text);

                    var results = ps.Invoke();

                    // Zpracování výsledků musí být voláno na hlavním vlákně (UI thread)
                    this.Invoke(() =>
                    {
                        if (ps.Streams.Error.Count > 0)
                        {
                            foreach (var error in ps.Streams.Error)
                            {
                                Output.Text = $"Chyba při vytváření uživatele {user.userName}";
                                using (StreamWriter sw = File.AppendText("log.txt"))
                                {
                                    sw.WriteLine("Chyba ze dne: " + DateTime.Now);
                                    sw.WriteLine($"Chyba při vytváření uživatele {user.userName}: {error}");
                                }
                            }
                            ps.Streams.Error.Clear();
                        }
                        else
                        {
                            Output.Text = $"Uživatel {user.userName} úspěšně vytvořen.";
                        }

                        progressBar1.Value += 1;
                    });

                    ps.Commands.Clear();
                }
            });
        }

        private async void AddUsersButton_Click(object sender, EventArgs e)
        {
            if (YearOfGraduationTextBox.Text == string.Empty || LetterClassTextBox.Text == string.Empty)
            {
                MessageBox.Show("Zadejte ročník nebo třídu.");
                return;
            }
            else if (users_list.Count == 0)
            {
                MessageBox.Show("Nejsou načteni žádní uživatelé.");
                return;
            }
            else if (YearOfGraduationTextBox.Text.Length != 4 || !int.TryParse(YearOfGraduationTextBox.Text, out _))
            {
                MessageBox.Show("Zadejte platný ročník ve formátu YYYY (např. 2023).");
                return;
            }
            else if (LetterClassTextBox.Text.Length != 1 || !char.IsLetter(LetterClassTextBox.Text[0]))
            {
                MessageBox.Show("Zadejte platnou třídu (např. A, B, C).");
                return;
            }

            AddUsersButton.Enabled = false;
            await AddUsersToAD();
            AddUsersButton.Enabled = true;
            MessageBox.Show("Hotovo.");
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
            System.Diagnostics.Process.Start("notepad.exe", path);
        }
    }
}
