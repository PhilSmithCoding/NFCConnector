using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace NfcConnect.Database
{
    class DatabaseConnect
    {
        public DatabaseConnect()
        {
        }

        public string GetCommandForCardID(string cardID)
        {
            using (var connection = new SQLiteConnection(@"Data Source=C:\Users\pschm\source\repos\NfcConnect\NfcConnect\Database\NFCConnect.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"SELECT text.value as text FROM card INNER JOIN text ON card.text_id = text.id WHERE card.id = '{cardID}'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var text = reader.GetString(0);
                        return text;
                    }
                }
            }
            return "";
        }

        public void WriteCommandForCardID(string cardID,string storeValue,string text)
        {
            using (var connection = new SQLiteConnection(@"Data Source=C:\Users\pschm\source\repos\NfcConnect\NfcConnect\Database\NFCConnect.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $@"INSERT into text (value) VALUES ('{ text.Trim()}')";
                command.ExecuteNonQuery();
                command.CommandText = @"SELECT MAX(id) FROM text";
                int textID = 0;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textID = reader.GetInt32(0);
                    }
                }
                command.CommandText = $@"INSERT into card (id,text_id) VALUES ('{cardID}','{textID.ToString()}')";
                command.ExecuteReader();
            }
        }
    }
}