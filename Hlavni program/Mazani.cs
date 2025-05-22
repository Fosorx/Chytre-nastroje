using Microsoft.Win32;
using System.Diagnostics;

namespace Hlavni_program
{
    public partial class Mazani : Form
    {
        public Mazani()
        {
            InitializeComponent();
        }
        List<string> sidKeys = new List<string>();

        int taskComplete = 0;


        public void ShowProfilePath()
        {
            string baseKeyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList";

            using (RegistryKey profileListKey = Registry.LocalMachine.OpenSubKey(baseKeyPath))
            {
                if (profileListKey != null)
                {
                    foreach (string subKeyName in profileListKey.GetSubKeyNames())
                    {
                        using (RegistryKey profileKey = profileListKey.OpenSubKey(subKeyName))
                        {
                            if (profileKey != null)
                            {
                                string profilePath = profileKey.GetValue("ProfileImagePath") as string;

                                if (!string.IsNullOrEmpty(profilePath))
                                {
                                    sidKeys.Add(subKeyName);
                                    ProfilesInRegisterList.Items.Add(profilePath);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Klíè ProfileList nebyl nalezen.");
                }
            }
        }

        private void DeleteProfiles(string sidToDelete, string folderPath)
        {
            string profileListKeyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList";

            using (RegistryKey baseKey = Registry.LocalMachine.OpenSubKey(profileListKeyPath, writable: true))
            {
                if (baseKey != null)
                {
                    try
                    {
                        baseKey.DeleteSubKeyTree(sidToDelete);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show($"Chyba pøi mazání: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Nebyl nalezen profil.");

                }
            }

            if (Directory.Exists(folderPath))
            {
                try
                {
                    string command = $"/C rmdir /S /Q \"{folderPath}\"";

                    // Spuštìní pøíkazového øádku jako administrátor
                    ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe")
                    {
                        Verb = "runas",  // Spuštìní s administrátorskými právy
                        UseShellExecute = true, // Pro použití 'runas'
                        WindowStyle = ProcessWindowStyle.Normal, // Okno bude zobrazeno
                        Arguments = command // Pøíkaz pro vymazání složky
                    };

                    // Spuštìní procesu CMD
                    Process.Start(startInfo);

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Složka nebyla nalezena!");
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (ProfilesInRegisterList.CheckedItems.Count != 0)
            {
                foreach (var item in ProfilesInRegisterList.CheckedItems)
                {
                    int index = ProfilesInRegisterList.Items.IndexOf(item);
                    DeleteProfiles(sidKeys[index], item.ToString());
                    ChangeTaskBar();
                }
                progressBar.Value = 0;
                label2.Visible = true;

            }
            else
            {
                MessageBox.Show("Vyberte prosím alespoò jeden profil.");
            }
        }

        private void ChangeTaskBar()
        {
            progressBar.Value = progressBar.Value + ((1 / ProfilesInRegisterList.CheckedItems.Count));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            ShowProfilePath();
        }
    }
}
