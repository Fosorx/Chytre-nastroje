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
    public partial class SpravaPocitacovychProgramu : UserControl
    {
        private const int ServerPort = 8888;

        private int _successCounter = 0;

        public SpravaPocitacovychProgramu()
        {
            InitializeComponent();
            PopulateClasses(); // Naplníme ComboBoxy učebnami hned při startu
        }

        #region UI Setup & Data Refresh

        private void PopulateClasses()
        {
            ComputerClassComboBox.Items.Clear();
            ComputerClassComboBox.Items.AddRange(new string[] { "VT1", "VT2", "VT3", "VT4", "VT5", "ELM", "Localhost" });
            if (ComputerClassComboBox.Items.Count > 0) ComputerClassComboBox.SelectedIndex = 0;
        }

        // TADY JE TO TLAČÍTKO, CO TI CHYBĚLO:
        private void GetProgramsButton_Click(object sender, EventArgs e)
        {
            ProgramsListBox.Items.Clear();

            // Taháme data z té statické třídy, kterou jsme opravili
            foreach (var programEntry in PublicValues.SelectedInstallList)
            {
                ProgramsListBox.Items.Add(programEntry);
            }

            if (ProgramsListBox.Items.Count == 0)
            {
                MessageBox.Show("No programs selected. Please add them in the previous step.", "Empty List");
            }
        }

        #endregion

        #region Actions (Install / Update)
        
        private async void InstallButton_Click(object sender, EventArgs e)
        {
            await SendBatchToEntireClass("install");
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            await SendBatchToEntireClass("upgrade");
        }

        private async Task SendBatchToEntireClass(string action)
        {
            if (PublicValues.SelectedInstallList.Count == 0)
            {
                MessageBox.Show("Seznam programů je prázdný!", "Chyba");
                return;
            }

            // Resetujeme počítadlo a label před začátkem hromadného odesílání
            _successCounter = 0;
            UpdateSuccessLabel();

            int pcCount = GetNumberOfIpAddresses();
            string prefix = GetIpPrefix();

            // Vyčistíme staré odpovědi v ListBoxu
            ProgramsUpdatesListBox.Items.Clear();

            // Iterujeme přes všechna PC v učebně
            for (int i = 1; i <= pcCount; i++)
            {
                string targetIp = prefix + i.ToString();

                foreach (var entry in PublicValues.SelectedInstallList)
                {
                    string[] parts = entry.Split(new[] { " | " }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        var singleRequest = new WingetRequest
                        {
                            Action = action,
                            AppId = parts[0],
                            Version = parts[1]
                        };

                        string jsonPayload = JsonSerializer.Serialize(singleRequest);
                        string fullMessage = $"WingetAction {jsonPayload}";

                        // Spustíme komunikaci asynchronně a nečekáme (Fire and Forget)
                        _ = CommunicateWithServer(targetIp, fullMessage);
                    }
                }
            }

            MessageBox.Show($"Příkazy byly odeslány na {pcCount} počítačů.", "Hromadná akce");
        }

        #endregion

        #region Networking & Helpers

        private async Task CommunicateWithServer(string ip, string message)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    // Krátký timeout pro připojení
                    var connectTask = client.ConnectAsync(ip, ServerPort);
                    if (await Task.WhenAny(connectTask, Task.Delay(2000)) != connectTask) return;

                    using (NetworkStream stream = client.GetStream())
                    using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        await writer.WriteLineAsync(message);

                        // Čekáme na bleskovou odpověď: {"Success": true, ...}
                        string? response = await reader.ReadLineAsync();

                        if (!string.IsNullOrEmpty(response))
                        {
                            // Zapíšeme do ListBoxu (přes Invoke, abychom nezhodili UI)
                            this.Invoke(new Action(() =>
                            {
                                ProgramsUpdatesListBox.Items.Add($"{ip}: {response}");
                            }));

                            // Kontrola úspěchu v JSONu
                            try
                            {
                                var doc = JsonDocument.Parse(response);
                                if (doc.RootElement.GetProperty("Success").GetBoolean())
                                {
                                    // Bezpečné přičtení jedničky napříč vlákny
                                    System.Threading.Interlocked.Increment(ref _successCounter);
                                    UpdateSuccessLabel();
                                }
                            }
                            catch { /* Odpověď nebyla validní JSON nebo Success chybí */ }
                        }
                    }
                }
            }
            catch { /* PC neodpovídá nebo nastala chyba sítě */ }
        }

        private void UpdateSuccessLabel()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateSuccessLabel));
            }
            else
            {
                SuccessCountLabel.Text = $"Podařilo se: {_successCounter}";
            }
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
                case 6: return 1;  // Localhost
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

        #region Winget Updates

        private async void CheckUpdatesButton_Click(object sender, EventArgs e)
        {
            // Vyčistíme starý seznam a dáme uživateli vědět, že se něco děje
            ProgramsUpdatesListBox.Items.Clear();
            ProgramsUpdatesListBox.Items.Add("Hledám dostupné aktualizace, prosím čekejte...");

            // Získáme cílovou IP (např. z ComboBoxu nebo první IP v učebně)
            // Zde pro ukázku beru localhost nebo prefix + první PC
            string targetIp = GetIpPrefix() + "1";
            if (ComputerClassComboBox.SelectedIndex == 6) targetIp = "127.0.0.1";

            await FetchUpdatesFromServer(targetIp);
        }

        private async Task FetchUpdatesFromServer(string ip)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    // Timeout 8 sekund - winget scan je občas pomalejší při kontaktu s MS servery
                    var connectTask = client.ConnectAsync(ip, ServerPort);
                    if (await Task.WhenAny(connectTask, Task.Delay(8000)) != connectTask)
                    {
                        UpdateUpdateListSafe($"CHYBA: PC s {ip} neodpovídá (Timeout).");
                        return;
                    }

                    using (NetworkStream stream = client.GetStream())
                    using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        // Pošleme příkaz pro Scénář E
                        await writer.WriteLineAsync("GetWingetUpdates");

                        // Čekáme na JSON odpověď
                        string? jsonResponse = await reader.ReadLineAsync();

                        if (!string.IsNullOrEmpty(jsonResponse))
                        {
                            try
                            {
                                var updates = JsonSerializer.Deserialize<List<WingetUpdateInfo>>(jsonResponse);

                                this.Invoke(new Action(() => {
                                    ProgramsUpdatesListBox.Items.Clear();
                                    if (updates == null || updates.Count == 0)
                                    {
                                        ProgramsUpdatesListBox.Items.Add("Všechny aplikace jsou aktuální.");
                                    }
                                    else
                                    {
                                        foreach (var up in updates)
                                        {
                                            ProgramsUpdatesListBox.Items.Add(up);
                                        }
                                    }
                                }));
                            }
                            catch (Exception jsonEx)
                            {
                                UpdateUpdateListSafe($"Chyba zpracování dat: {jsonEx.Message}");
                            }
                        }
                        else
                        {
                            UpdateUpdateListSafe("Server poslal prázdnou odpověď.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateUpdateListSafe($"Chyba spojení: {ex.Message}");
            }
        }

        // Pomocná metoda pro bezpečný zápis do ListBoxu z jiného vlákna
        private void UpdateUpdateListSafe(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateUpdateListSafe(message)));
            }
            else
            {
                ProgramsUpdatesListBox.Items.Clear();
                ProgramsUpdatesListBox.Items.Add(message);
            }
        }

        #endregion

        #region Updates// Tlačítko: Aktualizovat pouze vybrané řádky
        private async void ChooseUpdatesButtons_Click(object sender, EventArgs e)
        {
            // Získáme seznam všech objektů, které uživatel v ListBoxu označil
            var selectedUpdates = ProgramsUpdatesListBox.SelectedItems
                .OfType<WingetUpdateInfo>()
                .ToList();

            if (selectedUpdates.Count == 0)
            {
                MessageBox.Show("Označte v seznamu aplikace, které chcete aktualizovat.", "Žádný výběr");
                return;
            }

            await ProcessWingetUpgrades(selectedUpdates);
        }

        // Tlačítko: Aktualizovat úplně všechno, co winget našel
        private async void AllUpdatesButton_Click(object sender, EventArgs e)
        {
            // Získáme všechny objekty typu WingetUpdateInfo, které jsou v ListBoxu
            var allUpdates = ProgramsUpdatesListBox.Items
                .OfType<WingetUpdateInfo>()
                .ToList();

            if (allUpdates.Count == 0)
            {
                MessageBox.Show("Seznam aktualizací je prázdný.", "Není co aktualizovat");
                return;
            }

            await ProcessWingetUpgrades(allUpdates);
        }

        private async Task ProcessWingetUpgrades(List<WingetUpdateInfo> updatesToApply)
        {
            // Příprava UI
            _successCounter = 0;
            UpdateSuccessLabel();

            // Programy vypíšeme do logu, ať víme, že se něco děje
            ProgramsUpdatesListBox.Items.Clear();
            ProgramsUpdatesListBox.Items.Add("--- Spouštím hromadnou aktualizaci ---");

            int pcCount = GetNumberOfIpAddresses();
            string prefix = GetIpPrefix();

            foreach (var update in updatesToApply)
            {
                for (int i = 1; i <= pcCount; i++)
                {
                    // Sestavení IP adresy
                    string targetIp = (ComputerClassComboBox.SelectedIndex == 6) ? "127.0.0.1" : prefix + i.ToString();

                    // Vytvoření JSON požadavku
                    var request = new WingetRequest
                    {
                        Action = "upgrade", // Winget příkaz pro aktualizaci
                        AppId = update.Id,
                        Version = ""
                    };

                    string jsonPayload = JsonSerializer.Serialize(request);
                    string fullMessage = $"WingetAction {jsonPayload}";

                    // Odeslání (Fire and Forget) - nečekáme na dokončení instalace, 
                    // jen na potvrzení serveru, že příkaz přijal.
                    _ = CommunicateWithServer(targetIp, fullMessage);

                    // Pokud jedeme na Localhostu, neiterujeme přes 32 adres
                    if (ComputerClassComboBox.SelectedIndex == 6) break;
                }
            }

            MessageBox.Show($"Požadavky na aktualizaci {updatesToApply.Count} aplikací byly odeslány na všechny dostupné počítače.", "Akce spuštěna");
        }
        #endregion
    }

    // Třída pro JSON (přesně tak, jak ji čeká tvůj klient)
    public class WingetRequest
    {
        public string Action { get; set; }
        public string AppId { get; set; }
        public string Version { get; set; }
    }
}