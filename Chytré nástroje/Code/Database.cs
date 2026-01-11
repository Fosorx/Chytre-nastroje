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
        public async Task Login()
        {
            string connString = "Server=localhost;Database=SmartTools;Trusted_Connection=True;Encrypt=False;";


            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    await conn.OpenAsync();
                    MessageBox.Show("Spojení s databází SmartTools OK!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL chyba: {ex.Message}");
            }


        }
    }
    
}
