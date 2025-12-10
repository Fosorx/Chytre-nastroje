using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chytré_nástroje.Code
{
    internal class AutoUpdate
    {
        private readonly string manifestUrl = "https://fosorx.github.io/update.json";

        public async Task CheckForUpdateAsync()
        {
            try
            {
                using var client = new HttpClient();
                string json = await client.GetStringAsync(manifestUrl);

                var manifest = JsonSerializer.Deserialize<UpdateManifest>(json);

                Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version!;
                Version latestVersion = new Version(manifest.version);

                if (latestVersion > currentVersion)
                {
                    MessageBox.Show($"Nová verze {latestVersion} je dostupná, stahuji...");

                    string tempPath = Path.Combine(Path.GetTempPath(), "ChytreNastrojeUpdate");
                    Directory.CreateDirectory(tempPath);

                    string fileName = Path.Combine(tempPath, Path.GetFileName(manifest.url));

                    using var response = await client.GetAsync(manifest.url);
                    response.EnsureSuccessStatusCode();

                    await using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fs);
                    }
                    MessageBox.Show($"Soubor stažen: {fileName}");

                }
                else
                {

                    MessageBox.Show("Používáte nejnovější verzi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při kontrole aktualizace: " + ex.Message);
            }
        }
    }

    internal class UpdateManifest
    {
        public string version { get; set; }
        public string url { get; set; }
    }
}
