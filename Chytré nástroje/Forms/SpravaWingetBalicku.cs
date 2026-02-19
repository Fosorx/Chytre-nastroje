using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chytré_nástroje.Code;

namespace Chytré_nástroje.Forms
{
    public partial class SpravaWingetBalicku : UserControl
    {
        // Veřejný list pro uložení vybraných aplikací k instalaci

        string[] Programs = new string[]
        {
            "audacity.audacity",
            "BlenderFoundation.Blender",
            "FreeCAD.FreeCAD",
            "Insecure.Nmap",
            "OpenJS.NodeJS",
            "OBSProject.OBSStudio",
            "Oculus.Oculus",
            "Prusa3D.PrusaSlicer",
            "Unity.UnityHub",
            "Oracle.VirtualBox",
            "VideoLAN.VLC",
            "Microsoft.SQLServerManagementStudio",
            "Microsoft.VisualStudioCode",
            "WiresharkFoundation.Wireshark"
        };

        public SpravaWingetBalicku()
        {
            InitializeComponent();
            FillProgramList();

            // Přihlášení k událostem
            this.ProgramsComboBox.SelectedIndexChanged += ProgramsComboBox_SelectedIndexChanged;
            this.VersionsCheckedListBox.ItemCheck += VersionsCheckedListBox_ItemCheck;
            this.AddListButton.Click += AddListButton_Click;
        }

        private void FillProgramList()
        {
            ProgramsComboBox.Items.Clear();
            foreach (var program in Programs)
            {
                ProgramsComboBox.Items.Add(program);
            }
        }

        // Zajištění výběru pouze JEDNÉ možnosti v CheckedListBoxu
        private void VersionsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Odškrtne všechny ostatní položky kromě té, na kterou se právě kliklo
                for (int i = 0; i < VersionsCheckedListBox.Items.Count; i++)
                {
                    if (i != e.Index)
                        VersionsCheckedListBox.SetItemChecked(i, false);
                }
            }
        }

        // Přidání vybraného programu a verze do listu
        private void AddListButton_Click(object sender, EventArgs e)
        {
            if (ProgramsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Vyberte nejdříve program.");
                return;
            }

            if (VersionsCheckedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vyberte verzi programu.");
                return;
            }

            string appId = ProgramsComboBox.SelectedItem.ToString();
            string version = VersionsCheckedListBox.CheckedItems[0].ToString();

            // Formát uložení (můžeš si upravit, např. na JSON nebo CSV)
            string entry = $"{appId} | {version}";

            if (!PublicValues.SelectedInstallList.Contains(entry))
            {
                PublicValues.SelectedInstallList.Add(entry);
                MessageBox.Show($"Přidáno do seznamu: {entry}\nCelkem položek: {PublicValues.SelectedInstallList.Count}");
            }
            else
            {
                MessageBox.Show("Tato kombinace již v seznamu je.");
            }
        }

        private async void ProgramsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProgramsComboBox.SelectedItem != null)
            {
                string selectedAppId = ProgramsComboBox.SelectedItem.ToString();
                await UpdateVersionList(selectedAppId);
            }
        }

        public async Task UpdateVersionList(string appId, int maxVersions = 8)
        {
            VersionsCheckedListBox.Items.Clear();
            VersionsCheckedListBox.Items.Add("Hledám verze...", CheckState.Indeterminate);

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = $"show --id {appId} --versions",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8
                };

                using var process = Process.Start(psi);
                if (process == null) return;

                string output = await process.StandardOutput.ReadToEndAsync();
                await process.WaitForExitAsync();

                string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                VersionsCheckedListBox.Items.Clear();

                bool startParsing = false;
                int count = 0;

                foreach (var line in lines)
                {
                    if (line.Contains("---"))
                    {
                        startParsing = true;
                        continue;
                    }

                    if (startParsing && count < maxVersions)
                    {
                        string[] parts = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length > 0)
                        {
                            VersionsCheckedListBox.Items.Add(parts[0]);
                            count++;
                        }
                    }
                }

                if (VersionsCheckedListBox.Items.Count == 0)
                {
                    VersionsCheckedListBox.Items.Add("Nebyly nalezeny žádné verze.");
                }
            }
            catch (Exception ex)
            {
                VersionsCheckedListBox.Items.Clear();
                VersionsCheckedListBox.Items.Add("Chyba při načítání");
                MessageBox.Show($"Chyba Wingetu: {ex.Message}");
            }
        }
    }
}