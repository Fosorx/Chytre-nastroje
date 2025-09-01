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
        private readonly string manifestUrl = "https://chytre-nastroje.netlify.app/update.json";

        public async Task<string> CheckForUpdateAsync()
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
                    Console.WriteLine($"Nová verze {latestVersion} je dostupná, stahuji...");

                    string tempPath = Path.Combine(Path.GetTempPath(), "ChytreNastrojeUpdate");
                    Directory.CreateDirectory(tempPath);

                    string fileName = Path.Combine(tempPath, Path.GetFileName(manifest.url));

                    using var response = await client.GetAsync(manifest.url);
                    response.EnsureSuccessStatusCode();

                    await using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fs);
                    }

                    return $"Soubor stažen: {fileName}";

                    // >>> Zde můžeš spustit updater nebo instalátor
                    // System.Diagnostics.Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
                }
                else
                {
                    return "Používáte nejnovější verzi.";
                }
            }
            catch (Exception ex)
            {
                return "Chyba při kontrole aktualizace: " + ex.Message;
            }
        }
    }

    internal class UpdateManifest
    {
        public string version { get; set; }
        public string url { get; set; }
    }
}
