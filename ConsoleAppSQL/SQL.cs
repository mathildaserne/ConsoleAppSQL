using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace ConsoleAppSQL
{
    class SQL
    {
        
        public static void ExecuteSQL(string sql, params string[] values)
        {
            //Koppling till databas
            using (var sqlite2 = new SQLiteConnection("data source=" + "MinDatabase.db"))
            {
                
                sqlite2.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, sqlite2);
                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }
                cmd.ExecuteNonQuery();
            }
        }

    }
}