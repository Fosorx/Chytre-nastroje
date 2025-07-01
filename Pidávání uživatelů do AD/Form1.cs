using Microsoft.VisualBasic.ApplicationServices;
using OfficeOpenXml;
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

            ExcelPackage.License.SetNonCommercialPersonal("Fosorx");

            using (ExcelPackage package = new ExcelPackage(filePath))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int row = 3;

                while (worksheet.Cells[row, 1].Value != null)
                {
                    string _name = worksheet.Cells[row, 4].Value.ToString();
                    string _surname = worksheet.Cells[row, 5].Value.ToString();
                    string _userName = worksheet.Cells[row, 6].Value.ToString();

                    users.Add(new Users { name = _name, surname = _surname, userName = _userName });
                    row++;
                }
                if (row != 3)
                {
                    MessageBox.Show("Data úspěšně načtená");
                    return users;
                }
                return null;
            }

        }


        private void AddUsersToAD()
        {
            using PowerShell ps = PowerShell.Create();

            // Načtení modulu ActiveDirectory jednou před cyklem
            ps.AddScript("Import-Module ActiveDirectory").Invoke();
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
                    }
                    ps.Streams.Error.Clear();
                }
                else
                {
                    Console.WriteLine($"User {user.userName} created successfully.");
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
