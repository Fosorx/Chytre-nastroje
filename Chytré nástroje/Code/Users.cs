using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ClosedXML.Excel;

namespace Chytré_nástroje.Code
{
    internal class Users
    {
        public string name { get; set; } = "";
        public string surname { get; set; } = "";
        public string userName { get; set; } = "";

        public static List<Users> LoadFromExcel(string filePath)
        {
            var userList = new List<Users>();

            using (var workbook = new XLWorkbook(filePath))
            {
                // Předpokládám, že data jsou na prvním listu
                var worksheet = workbook.Worksheet(1);

                // Začneme od 3. řádku (přeskočíme "BAKALÁŘI" a hlavičky)
                var rows = worksheet.RangeUsed().RowsUsed().Skip(2);

                foreach (var row in rows)
                {
                    // Načtení surovyých dat ze sloupců B a C (Příjmení a Jméno)
                    string rawSurname = row.Cell(2).GetValue<string>().Trim(); // Sloupec B
                    string rawName = row.Cell(3).GetValue<string>().Trim();    // Sloupec C

                    if (string.IsNullOrEmpty(rawSurname)) continue;

                    var newUser = new Users
                    {
                        // 1. Jméno zůstává (Jakub)
                        name = rawName,

                        // 2. Příjmení převedeme z "NOVÁK" na "Novák"
                        surname = ToTitleCase(rawSurname),

                        // 3. Uživatelské jméno (příjmeníjméno, bez diakritiky, malé)
                        userName = GenerateUserName(rawSurname, rawName)
                    };

                    userList.Add(newUser);
                }
            }

            return userList;
        }

        private static string ToTitleCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "";
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        private static string GenerateUserName(string surname, string name)
        {
            string combined = (surname + name).ToLower();
            return RemoveDiacritics(combined);
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}