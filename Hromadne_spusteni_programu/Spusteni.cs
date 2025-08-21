using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Hromadne_spusteni_programu
{
    public partial class Spusteni : Form
    {
        public Spusteni()
        {
            InitializeComponent();
        }

        private void chooseAllButton_Click(object sender, EventArgs e)
        {
            if (checkedComputersBox.CheckedItems.Count < checkedComputersBox.Items.Count)
            {
                for (int i = 0; i < checkedComputersBox.Items.Count; i++)
                {
                    checkedComputersBox.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedComputersBox.Items.Count; i++)
                {
                    checkedComputersBox.SetItemChecked(i, false);
                }
            }
        }

        private int numberOfIpAdresses()
        {
            switch (checkedComputersBox.SelectedIndex)
            {
                case 0:
                    return 33;
                case 1:
                    return 25;
                case 2:
                    return 33;
                case 3:
                    return 25;
                case 4:
                    return 25;
                case 5:
                    return 17;
                default:
                    return 0;
            }
        }
        private string ip
        {
            get
            {
                switch (checkedComputersBox.SelectedIndex)
                {
                    case 0:
                        return "10.130.136.";
                    case 1:
                        return "10.130.134.";
                    case 2:
                        return "10.130.133.";
                    case 3:
                        return "10.130.71.";
                    case 4:
                        return "10.130.98.";
                    case 5:
                        return "10.130.37.";
                    default:
                        return string.Empty;
                }
            }
        }

        private string passwordHash(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private async void startButton_Click(object sender, EventArgs e)
        {
            for(int i = 1; i < numberOfIpAdresses(); i++)
            {
                try
                {
                    using (TcpClient client = new TcpClient())
                    {
                        // Timeout pro pøipojení (2s)
                        var connectTask = client.ConnectAsync(ip + $"{i}", 7468);
                        if (await Task.WhenAny(connectTask, Task.Delay(2000)) != connectTask)
                        {
                            label4.Text = "Timeout – server nedostupný";
                            return;
                        }

                        using (NetworkStream stream = client.GetStream())
                        {
                            string message = @$"{passwordHash(passwordTextBox.Text)};RUN {programPathTextBox.Text}";
                            byte[] data = Encoding.UTF8.GetBytes(message);
                            await stream.WriteAsync(data, 0, data.Length);

                            // Timeout pro ètení odpovìdi (2s)
                            var buffer = new byte[1024];
                            var readTask = stream.ReadAsync(buffer, 0, buffer.Length);
                            if (await Task.WhenAny(readTask, Task.Delay(2000)) != readTask)
                            {
                                Console.WriteLine("Timeout – žádná odpovìï od serveru");
                                return;
                            }

                            int bytesRead = await readTask;
                            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                            Console.WriteLine($"Odpovìï od klienta: {response}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba: {ex.Message}");
                }
            }
        }

        private void checkedComputersBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Zruš všechny ostatní
                for (int i = 0; i < checkedComputersBox.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        checkedComputersBox.SetItemChecked(i, false);
                    }
                }
            }
        }
    }
}
