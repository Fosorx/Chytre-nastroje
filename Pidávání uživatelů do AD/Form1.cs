using ClosedXML.Excel;
using Microsoft.VisualBasic.ApplicationServices;
using Pidávání_uživatelů_do_AD;
using System.Management.Automation;

namespace Přidávání_uživatelů_do_AD
{
    public partial class Form1 : Form
    {
        public Form1()
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
                openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
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


        private void AddUsersToAD()
        {
            using PowerShell ps = PowerShell.Create();

            // Načtení modulu ActiveDirectory jednou před cyklem
            ps.AddScript("Set-ExecutionPolicy Bypass -Scope Process -Force; Import-Module ActiveDirectory").Invoke();


            ps.Commands.Clear();

            foreach (var user in users_list)
            {
                string profilePath = $@"\\BL3C-WSE-Mach\Profiles$\{user.userName}";
                string homeDirectory = $@"\\BL3C-WSE-Mach\Home_folders$\{user.userName}";

                string script = @"
                param($username, $firstname, $lastname, $domain, $profilePath, $homeDirectory)

                New-ADUser -Name ""$firstname $lastname"" `
                           -GivenName $firstname `
                           -Surname $lastname `
                           -SamAccountName $username `
                           -UserPrincipalName ""$username@$domain"" `
                           -Path ""OU=SOS-Studenti,OU=SOS-Uzivatele,OU=SOS-Blatna,DC=localmach,DC=lab"" `
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
                  .AddParameter("domain", "localmach.lab")
                  .AddParameter("profilePath", profilePath)
                  .AddParameter("homeDirectory", homeDirectory);

                var results = ps.Invoke();

                if (ps.Streams.Error.Count > 0)
                {
                    Console.WriteLine($"Error creating user {user.userName}:");
                    foreach (var error in ps.Streams.Error)
                    {
                        Console.WriteLine(error.ToString());
                        MessageBox.Show($"Chyba při vytváření uživatele {user.userName}: {error}");
                    }
                    ps.Streams.Error.Clear();
                }
                else
                {
                    Console.WriteLine($"User {user.userName} created successfully.");
                    MessageBox.Show($"Uživatel {user.userName} úspěšně vytvořen.");
                }

                ps.Commands.Clear();
            }
        }

        private void AddUsersButton_Click(object sender, EventArgs e)
        {
            AddUsersToAD();
        }
    }
}
