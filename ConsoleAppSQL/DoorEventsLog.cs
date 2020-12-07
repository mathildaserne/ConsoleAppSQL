namespace ConsoleAppSQL
{
using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

class DoorEventsLog:SQL
{
        
        public static DataTable FindEntriesByDoor(string Door)
        {
            string DörrKommando = @"SELECT Main.DatumTid, Main.Location, Main.Kod, 
            Main.Tagg, Main.Tenant FROM Main
             
            JOIN Event On Main.Kod=Event.ID
            JOIN Location On Main.Location=Location.ID
            JOIN Tenant On Main.Tenant=Tenant.ID 
            LEFT JOIN Tenant AS Tagg ON Main.Tagg=Tagg.ID           
            WHERE Location.Door=@Door";

        DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase")) 
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando,con);
                cmd.Parameters.AddWithValue("@Door", Door);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable FindEntriesByEvent(string Event)
        {

            string DörrKommando = @"SELECT Main.DatumTid, Main.Location, Main.Kod, 
            Main.Tagg, Main.Tenant FROM Main

            JOIN Event On Main.Kod=Event.ID
            JOIN Location On Main.Location=Location.ID
            JOIN Tenant On Main.Tenant=Tenant.ID 
            LEFT JOIN Tenant AS Tagg ON Main.Tagg=Tagg.ID           
            WHERE Event.Kod=@Kod";

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando, con);
                cmd.Parameters.AddWithValue("@Kod", Event);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }

        public static DataTable FindEntriesByLocation(string Location)
        {

            string DörrKommando = @"SELECT Main.DatumTid, Main.Location, Main.Kod, 
            Main.Tagg, Main.Tenant FROM Main
             
            JOIN Event On Main.Kod=Event.ID
            JOIN Location On Main.Location=Location.ID
            JOIN Tenant On Main.Tenant=Tenant.ID 
            LEFT JOIN Tenant AS Tagg ON Main.Tagg=Tagg.ID           
            WHERE Location.Door LIKE @Door";

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando, con);
                cmd.Parameters.AddWithValue("@Door", "%"+Location+"%");
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }

        public static DataTable FindEntriesByTag(string Tagg)
        {

            string DörrKommando = @"SELECT Main.DatumTid, Main.Location, Main.Kod, 
            Main.Tagg, Main.Tenant FROM Main
             
            JOIN Event On Main.Kod=Event.ID
            JOIN Location On Main.Location=Location.ID
            JOIN Tenant On Main.Tenant=Tenant.ID 
            LEFT JOIN Tenant AS Tagg ON Main.Tagg=Tagg.ID           
            WHERE Tenant.Tagg=@Tagg";

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando, con);
                cmd.Parameters.AddWithValue("@Tagg", Tagg);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }

        public static DataTable FindEntriesByTenant(string Tenant)
        {

            string DörrKommando = @"SELECT Main.DatumTid, Main.Location, Main.Kod, 
            Main.Tagg, Main.Tenant FROM Main
             
            JOIN Event On Main.Kod=Event.ID
            JOIN Location On Main.Location=Location.ID
            JOIN Tenant On Main.Tenant=Tenant.ID 
            LEFT JOIN Tenant AS Tagg ON Main.Tagg=Tagg.ID           
            WHERE Tenant.Person=@Person";

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + Database))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando, con);
                cmd.Parameters.AddWithValue("@Person", Tenant);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }

        public static DataTable ListTenantsAt(string LGH)
        {

            string DörrKommando = @" ";

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase.db"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando, con);
                cmd.Parameters.AddWithValue("@LGH NR", LGH);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }

        public static void LogEntry()
        {



        }

    }

}
