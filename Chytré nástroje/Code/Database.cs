using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Chytré_nástroje.Code
{
    internal class Database
    {
        public async Task<bool> LoginAsync(string username, string password)
        {
            const string connString = "Server=localhost;Database=SmartTools;Trusted_Connection=True;Encrypt=False;";

            try
            {
                using var conn = new SqlConnection(connString);
                await conn.OpenAsync();

                using var command = conn.CreateCommand();
                command.CommandText = @"SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password;";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                int count = (int)await command.ExecuteScalarAsync();
                return count == 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL chyba: {ex.Message}");
                return false;
            }
        }
    }

}
