using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chytré_nástroje.Code;

namespace Chytré_nástroje.Forms
{
    public partial class MazaniProfilu : UserControl
    {
        private const int ServerPort = 8888;
        private List<UserProfile> seznamProfilu = new List<UserProfile>();

        public MazaniProfilu()
        {
            InitializeComponent();

            // 1. Základní nastavení UI
            ProfileDetailsLabel.Text = $"UŽIVATEL: \nSTAV: \nCESTA: \nSID: ";
            DeleteProfileButton.Enabled = false;

            // 2. Naplnění prvního seznamu (tím se spustí i naplnění druhého seznamu)
            PopulateClasses();
        }

        #region Logika pro dynamické plnění ComboBoxů a IP adres

        private void PopulateClasses()
        {
            ComputerClassComboBox.Items.Clear();
            ComputerClassComboBox.Items.AddRange(new string[] 
            { "VT1", "VT2", "VT3", "VT4", "VT5", "ELM", "Localhost" })
            if (ComputerClassComboBox.Items.Count > 0)
                ComputerClassComboBox.SelectedIndex = 0;
        }

        // TATO METODA SE SPUSTÍ VŽDY, KDYŽ KLIKNETE NA JINOU UČEBNU
        private void ComputerClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Vyčistit staré počítače
            ComputersComboBox.Items.Clear();

            // Zjistit počet PC pro vybranou učebnu
            int count = GetNumberOfIpAddresses();

            // Naplnit druhý ComboBox
            for (int i = 1; i <= count; i++)
            {
                ComputersComboBox.Items.Add($"Počítač {i}");
            }

            // Automaticky vybrat první počítač v seznamu
            if (ComputersComboBox.Items.Count > 0)
                ComputersComboBox.SelectedIndex = 0;
        }

        private int GetNumberOfIpAddresses()
        {
            switch (ComputerClassComboBox.SelectedIndex)
            {
                case 0: return 32; // VT1
                case 1: return 24; // VT2
                case 2: return 32; // VT3
                case 3: return 24; // VT4
                case 4: return 24; // VT5
                case 5: return 16; // ELM
                case 6: return 1;  //Localhost
                default: return 0;
            }
        }

        private string GetIpPrefix()
        {
            switch (ComputerClassComboBox.SelectedIndex)
            {
                case 0: return "10.130.136.";
                case 1: return "10.130.134.";
                case 2: return "10.130.133.";
                case 3: return "10.130.71.";
                case 4: return "10.130.98.";
                case 5: return "10.130.37.";
                case 6: return "127.0.0.";
                default: return string.Empty;
            }
        }

        #endregion

        #region Síťová komunikace

        private async Task CommunicateWithServer(string message)
        {
            // Sestavení IP adresy:Prefix + vybrané číslo v ComputersComboBox
            // Index je od 0, proto přidáváme +1, aby "Počítač 1" měl koncovku .1
            string currentIp = GetIpPrefix() + (ComputersComboBox.SelectedIndex + 1).ToString();

            try
            {
                using (TcpClient client = new TcpClient())
                {
                    // Timeout 3 sekundy na připojení
                    var connectTask = client.ConnectAsync(currentIp, ServerPort);
                    if (await Task.WhenAny(connectTask, Task.Delay(3000)) != connectTask)
                    {
                        MessageBox.Show($"Chyba: Počítač {currentIp} v učebně {ComputerClassComboBox.Text} neodpovídá.", "Chyba připojení");
                        return;
                    }

                    using (NetworkStream stream = client.GetStream())
                    using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        await writer.WriteLineAsync(message);
                        string response = await reader.ReadToEndAsync();

                        if (string.IsNullOrWhiteSpace(response)) return;

                        if (message == "GetProfiles")
                        {
                            ZpracujJsonProfily(response, currentIp);
                        }
                        else if (message.StartsWith("DeleteProfile"))
                        {
                            ZpracujOdpovedMazani(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kritická chyba na {currentIp}:\n{ex.Message}");
            }
        }

        private void ZpracujJsonProfily(string json, string ip)
        {
            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                seznamProfilu = JsonSerializer.Deserialize<List<UserProfile>>(json, options);

                ProfilesListBox.DataSource = null;
                ProfilesListBox.DataSource = seznamProfilu;
                ProfilesListBox.DisplayMember = "Uzivatel";

                if (seznamProfilu == null || seznamProfilu.Count == 0)
                {
                    MessageBox.Show($"Na PC {ip} nebyly nalezeny žádné profily.", "Informace");
                }
            }
            catch
            {
                MessageBox.Show($"Data z {ip} nejsou ve správném formátu JSON.", "Chyba serveru");
            }
        }

        private void ZpracujOdpovedMazani(string json)
        {
            try
            {
                using JsonDocument doc = JsonDocument.Parse(json);
                bool success = doc.RootElement.GetProperty("Success").GetBoolean();
                string message = doc.RootElement.GetProperty("Message").GetString();

                MessageBox.Show(message, success ? "Úspěch" : "Chyba",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show($"Odpověď: {json}", "Info");
            }
        }

        #endregion

        #region Události tlačítek a seznamu

        private async void GetProfilesButton_Click(object sender, EventArgs e)
        {
            DeleteProfileButton.Enabled = true;

            if (ComputersComboBox.SelectedIndex == -1) return;

            GetProfilesButton.Enabled = false;
            ProfilesListBox.DataSource = null;
            await CommunicateWithServer("GetProfiles");
            GetProfilesButton.Enabled = true;
        }

        private void ProfilesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProfilesListBox.SelectedItem is UserProfile vybrany)
            {
                ProfileDetailsLabel.Text = $"UŽIVATEL: {vybrany.Uzivatel}\n" +
                                           $"STAV: {vybrany.Stav}\n" +
                                           $"CESTA: {vybrany.Slozka}\n" +
                                           $"SID: {vybrany.SID}";

            }
        }

        private async void DeleteProfileButton_Click(object sender, EventArgs e)
        {
            if (ProfilesListBox.SelectedItem is UserProfile vybrany)
            {
                var result = MessageBox.Show(
                    $"VAROVÁNÍ: Opravdu chcete smazat profil {vybrany.Uzivatel}?\n" +
                    $"Tato akce je nevratná.",
                    "Potvrdit smazání",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteProfileButton.Enabled = false;
                    await CommunicateWithServer($"DeleteProfile {vybrany.SID}");

                    await Task.Delay(1000);
                    await CommunicateWithServer("GetProfiles");
                }
            }
        }

        #endregion
    }
}