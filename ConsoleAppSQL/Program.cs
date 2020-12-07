using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ConsoleAppSQL
{

    class Program

    {
        static void Main()
        {
            SQL.SkapaDatabas();
            var byDoor = DoorEventsLog.FindEntriesByDoor("LGH0101")?.Rows;
            OutputData("search by door", byDoor);
            Console.ReadKey();
        }

        private static void OutputData(string title, DataRowCollection byCode)
        {
            Console.WriteLine(title);
            foreach (DataRow r in byCode)
            {
                Console.WriteLine($"{r["DatumTid"]} {r["Location"]} {r["Kod"]} {r["Tagg"]} {r["Tenant"]} {DoText(r)}");
            }
        }

        private static string DoText(DataRow r)
        {
            var ev = r["Kod"].ToString();
            var what = ev.StartsWith("FD") ? " försökte öppna" : " öppnade";
            var where = ev.EndsWith("IN") ? "inifrån" : "utifrån";

            return r["Tenant"] + $"{what} dörr till {r["Location"]} {where}";
        }
    }
}
