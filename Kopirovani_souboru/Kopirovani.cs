using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kopirovani_souboru
{
    public partial class Kopirovani : Form
    {
        public Kopirovani()
        {
            InitializeComponent();
        }

        List<string> namesList = new List<string>();

        bool isFolder = false;
        string chooseTargetFolder = string.Empty;
        string chooseFolder = string.Empty;
        string filePath = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog1.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
                string readText = File.ReadAllText(filePath);
                namesList = readText.Split(";").ToList();
                ShowNames();
            }
        }

        public void ShowNames()
        {
            foreach (var name in namesList)
            {
                namesView.Items.Add(name);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    label4.Text = filePath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Vyberte složku";
                dialog.UseDescriptionForTitle = true; // od .NET 6+

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    chooseFolder = dialog.SelectedPath;
                    label5.Text = chooseFolder;
                }
                isFolder = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Vyberte složku";
                dialog.UseDescriptionForTitle = true; // od .NET 6+

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    chooseTargetFolder = dialog.SelectedPath;
                    label7.Text = chooseTargetFolder;
                }
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Maximum = namesList.Count;

            if (isFolder)
            {
                await Task.Run(() =>
                {
                    foreach (var name in namesList)
                    {
                        CopyDirectory(chooseFolder, Path.Combine(chooseTargetFolder, name));
                        this.Invoke(() => ChangeTaskBar());
                    }
                });
            }
            else
            {
                await Task.Run(() =>
                {
                    foreach (var name in namesList)
                    {
                        string cilovaCesta = Path.Combine(chooseTargetFolder, name, Path.GetFileName(filePath));
                        File.Copy(filePath, cilovaCesta);
                        this.Invoke(() => ChangeTaskBar());
                    }
                });
            }

            MessageBox.Show("Kopírování dokonèeno");
        }

        public static void CopyDirectory(string sourceDir, string targetDir)
        {
            // Vytvoø cílovou složku, pokud neexistuje
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            // Zkopíruj všechny soubory
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(targetDir, Path.GetFileName(file));
                File.Copy(file, destFile, overwrite: true);
            }

            // Rekurzivnì zkopíruj všechny podsložky
            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string newTargetDir = Path.Combine(targetDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, newTargetDir);
            }
        }

        private void ChangeTaskBar()
        {
            progressBar.Value = progressBar.Value + ((1 / namesList.Count()));
        }
    }
}
