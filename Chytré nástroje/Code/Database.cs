using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chytré_nástroje.Code
{
    internal class Database
    {
        public async Task<bool> LoginAsync(string username, string password)
        {
            const string connString = "Server=78.45.172.198;Port=3306;Database=SmartTools;User=remote_user;Password=jhkLpoT65823497!;SslMode=Disabled;";

            try
            {
                using var conn = new MySqlConnection(connString);
                await conn.OpenAsync();

                using var command = conn.CreateCommand();
                command.CommandText = @"SELECT COUNT(*) FROM users WHERE username = @username AND password_hash = @password_hash;";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password_hash", password);

                int count = Convert.ToInt32(await command.ExecuteScalarAsync());
                return count == 1;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"SQL chyba: {ex.Message}");
                return false;
            }
        }

    }

}
