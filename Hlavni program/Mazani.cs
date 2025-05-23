using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace Hlavni_program
{
    public partial class Mazani : Form
    {
        public Mazani()
        {
            InitializeComponent();
        }

        List<string> sidKeys = new List<string>();

        private async void Form1_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            await LoadProfilesAsync();
        }

        private async Task LoadProfilesAsync()
        {
            await Task.Run(() =>
            {
                string baseKeyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList";

                using RegistryKey profileListKey = Registry.LocalMachine.OpenSubKey(baseKeyPath);
                if (profileListKey != null)
                {
                    foreach (string subKeyName in profileListKey.GetSubKeyNames())
                    {
                        using RegistryKey profileKey = profileListKey.OpenSubKey(subKeyName);
                        if (profileKey != null)
                        {
                            string profilePath = profileKey.GetValue("ProfileImagePath") as string;
                            if (!string.IsNullOrEmpty(profilePath))
                            {
                                sidKeys.Add(subKeyName);

                                // Invoke because this modifies UI
                                Invoke(() => ProfilesInRegisterList.Items.Add(profilePath));
                            }
                        }
                    }
                }
                else
                {
                    Invoke(() => MessageBox.Show("Klíè ProfileList nebyl nalezen."));
                }
            });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (ProfilesInRegisterList.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vyberte prosím alespoò jeden profil.");
                return;
            }

            int total = ProfilesInRegisterList.CheckedItems.Count;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            IProgress<int> progress = new Progress<int>(percent =>
            {
                progressBar.Value = percent;
            });

            int count = 0;

            foreach (var item in ProfilesInRegisterList.CheckedItems)
            {
                int index = ProfilesInRegisterList.Items.IndexOf(item);
                await DeleteProfileAsync(sidKeys[index]);

                count++;
                int percent = (int)((double)count / total * 100);
                progress.Report(percent);
            }

            label2.Visible = true;
        }

        private async Task DeleteProfileAsync(string sidToDelete)
        {
            await Task.Run(() =>
            {
                try
                {
                    string psCommand = $"Get-CimInstance -ClassName Win32_UserProfile | Where-Object {{$_.SID -eq '{sidToDelete}'}} | Remove-CimInstance";

                    var psi = new ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -Command \"{psCommand}\"",
                        UseShellExecute = true,
                        Verb = "runas",
                        CreateNoWindow = true,
                        RedirectStandardOutput = false,
                        RedirectStandardError = false,
                    };

                    using (var process = Process.Start(psi))
                    {
                        process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba pøi mazání profilu pomocí PowerShell: {ex.Message}");
                }
            });
        }

        private void UpdateProgress(int current, int total)
        {
            if (total == 0) return;

            int percentage = (int)((double)current / total * 100);
            progressBar.Value = Math.Min(percentage, 100);
        }
    }
}
