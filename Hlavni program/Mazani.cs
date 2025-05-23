using Microsoft.Win32;
using System.ComponentModel;
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
                    if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
                    {
                        MessageBox.Show("Neplatná cesta");
                        return;
                    }

                    var command = $"/C rmdir /S /Q \"{folderPath}\"";

                    var startInfo = new ProcessStartInfo("cmd.exe")
                    {
                        Verb = "runas",
                        UseShellExecute = true,
                        WindowStyle = ProcessWindowStyle.Normal,
                        Arguments = command
                    };

                    using var process = Process.Start(startInfo);
                    process?.WaitForExit();
                }
                catch (Win32Exception ex) when (ex.NativeErrorCode == 1223)
                {
                    MessageBox.Show("Operace byla ukonèena uživatelem");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Složka nebyla nalezena!");
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

        private void button1_Click(object sender, EventArgs e)
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
    }
}
