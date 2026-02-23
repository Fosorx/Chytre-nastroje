using Microsoft.Data.SqlClient; // Důležité pro MSSQL
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chytré_nástroje.Code
{
    internal class Database
    {
        // Connection string vložený přímo do třídy (nebo ho můžeš předávat v konstruktoru)
        private readonly string _connectionString = @"Data Source=bleksql2; Initial Catalog=MMClient; Integrated Security=True; TrustServerCertificate=True";

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                // Používáme SqlConnection místo MySqlConnection
                using var conn = new SqlConnection(_connectionString);
                await conn.OpenAsync();

                using var command = conn.CreateCommand();
                // SQL syntaxe zůstává v tomto případě stejná
                command.CommandText = @"SELECT COUNT(*) FROM users WHERE username = @username AND password_hash = @password_hash;";

                // MSSQL parametry
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password_hash", password);

                object result = await command.ExecuteScalarAsync();
                int count = Convert.ToInt32(result);

                return count == 1;
            }
            catch (SqlException ex) // Chytáme SqlException místo MySqlException
            {
                MessageBox.Show($"SQL chyba (MSSQL): {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Obecná chyba: {ex.Message}");
                return false;
            }
        }
    }
}