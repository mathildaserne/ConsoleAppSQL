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

    class DoorEventsLog : SQL
    {
        public int MaxEntries
        { get; set; }    
        public DoorEventsLog(int _MaxEntries)
        {
            MaxEntries = _MaxEntries;
        }

    public static DataTable FindEntriesByDoor(string Door)
        {
            //Hämtar data från databasen 
            string DörrKommando = @"SELECT Main.DatumTid, Main.Location, Main.Kod, 
            Main.Tagg, Main.Tenant FROM Main 
             
            JOIN Event On Main.Kod=Event.Kod
            JOIN Location On Main.Location=Location.Door
            JOIN Tenant On (Main.Tenant=Tenant.Person AND Main.Tagg=Tenant.Tagg)          
            WHERE Location.Door=@Door
            ORDER BY Main.DatumTid DESC
            LIMIT @Entry";

            DoorEventsLog DoorEvents = new DoorEventsLog(20);

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase.db")) 
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando,con);
                cmd.Parameters.AddWithValue("@Door", Door);
                cmd.Parameters.AddWithValue("@Entry", DoorEvents.MaxEntries);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable FindEntriesByEvent(string Event)
        {
            //Hämtar data från databasen
            string DörrKommando = @"SELECT Main.DatumTid, Main.Location, Main.Kod, 
            Main.Tagg, Main.Tenant FROM Main

            JOIN Event On Main.Kod=Event.Kod
            JOIN Location On Main.Location=Location.Door
            JOIN Tenant On (Main.Tenant=Tenant.Person AND Main.Tagg=Tenant.Tagg)           
            WHERE Event.Kod=@Kod
            ORDER BY Main.DatumTid DESC
            LIMIT @Entry";

            DoorEventsLog DoorEvents = new DoorEventsLog(20);

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase.db"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando, con);
                cmd.Parameters.AddWithValue("@Kod", Event);
                cmd.Parameters.AddWithValue("@Entry", DoorEvents.MaxEntries);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }

        public static DataTable FindEntriesByLocation(string Location)
        {
            //Hämtar data från databasen
            string DörrKommando = @"SELECT Main.DatumTid, Main.Location, Main.Kod, 
            Main.Tagg, Main.Tenant FROM Main
             
            JOIN Event On Main.Kod=Event.Kod
            JOIN Location On Main.Location=Location.Door
            JOIN Tenant On (Main.Tenant=Tenant.Person AND Main.Tagg=Tenant.Tagg)             
            WHERE Location.Door = @Door
            ORDER BY Main.DatumTid DESC
            LIMIT @Entry";

            DoorEventsLog DoorEvents = new DoorEventsLog(20);

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase.db"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando, con);
                cmd.Parameters.AddWithValue("@Door", Location);
                cmd.Parameters.AddWithValue("@Entry", DoorEvents.MaxEntries);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }

        public static DataTable FindEntriesByTag(string Tagg)
        {
            //Hämtar data från databasen
            string DörrKommando = @"SELECT Main.DatumTid, Main.Location, Main.Kod, 
            Main.Tagg, Main.Tenant FROM Main
             
            JOIN Event On Main.Kod=Event.Kod
            JOIN Location On Main.Location=Location.Door
            JOIN Tenant On (Main.Tenant=Tenant.Person AND Main.Tagg=Tenant.Tagg)             
            WHERE Tenant.Tagg=@Tagg
            ORDER BY Main.DatumTid DESC
            LIMIT @Entry";

            DoorEventsLog DoorEvents = new DoorEventsLog(20);

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase.db"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando, con);
                cmd.Parameters.AddWithValue("@Tagg", Tagg);
                cmd.Parameters.AddWithValue("@Entry", DoorEvents.MaxEntries);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }

        public static DataTable FindEntriesByTenant(string Tenant)
        {
            //Hämtar data från databasen
            string DörrKommando = @"SELECT Main.DatumTid, Main.Location, Main.Kod, 
            Main.Tagg, Main.Tenant FROM Main
             
            JOIN Event On Main.Kod=Event.Kod
            JOIN Location On Main.Location=Location.Door
            JOIN Tenant On (Main.Tenant=Tenant.Person AND Main.Tagg=Tenant.Tagg)           
            WHERE Tenant.Person=@Person
            ORDER BY Main.DatumTid DESC
            LIMIT @Entry";

            DoorEventsLog DoorEvents = new DoorEventsLog(20);

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase.db"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando, con);
                cmd.Parameters.AddWithValue("@Person", Tenant);
                cmd.Parameters.AddWithValue("@Entry", DoorEvents.MaxEntries);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }

        public static DataTable ListTenantsAt(string LGH)
        {

            string DörrKommando = @"SELECT Main.Location, Main.Tagg, Main.Tenant FROM Main 
            JOIN Tenant On (Main.Tagg=Tenant.Tagg AND Main.Tenant=Tenant.Person)
            JOIN Location On Main.Location=Location.Door
            WHERE Location.Door=@LGHNR 
            ORDER BY Main.DatumTid DESC
            LIMIT @Entry";

            DoorEventsLog DoorEvents = new DoorEventsLog(20);

            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase.db"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(DörrKommando, con);
                cmd.Parameters.AddWithValue("@LGHNR", LGH);
                cmd.Parameters.AddWithValue("@Entry", DoorEvents.MaxEntries);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }

        public static void LogEntry(string DateTime, string Loc, string Code, string Tag, string Ten)
        {

            string LoggEntry = @"Insert into main(DatumTid, Location, Kod, Tagg, Tenant) values
            (@DatumTid, @Location, @Kod, @Tagg, @Tenant)";
            using (SQLiteConnection con = new SQLiteConnection("data source=" + "MinDatabase.db"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(LoggEntry, con);
                cmd.Parameters.AddWithValue("@DatumTid", DateTime);
                cmd.Parameters.AddWithValue("@Location", Loc);
                cmd.Parameters.AddWithValue("@Kod", Code);
                cmd.Parameters.AddWithValue("@Tagg", Tag);
                cmd.Parameters.AddWithValue("@Tenant", Ten);
                cmd.ExecuteNonQuery();
            }
            

        }

    }

}
