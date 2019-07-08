using PerrysNetConsole;
using PerrysNetConsoleHtml;
using System;
using System.IO;

namespace Demo
{
    class Program
    {

        protected static String[] headerdata = new String[]
        {
            "Name",
            "Project",
            "Hours",
            "Comment",
        };

        protected static String[][] exambledatalong = new String[][]
        {
            new String[] { "Rollout new Database Schema", "Shop 2.0", "12", "Need more testing, it was very complicated to migrate the records into the new schema." },
            new String[] { "Unittesting", "DBLib", "2", "Success" },
            new String[] { "CVS to GIT", "Shop 2.0", "4", "" },
            new String[] { "", "", "", "" }
        };

        static void Main(string[] args)
        {
            var tabledata = RowCollection.Create(exambledatalong);
            var header = RowConf.Create(headerdata).PresetTH();
            tabledata.Import(0, header);
            tabledata.Settings.Border.Enabled = true;
            tabledata.Settings.Border.HorizontalLineBody = BorderConf.HorizontalLineAlwaysOnFunc;

            using (var writer = new CoExHtmlWriter() { Title = "A fancy demo" })
            {
                CoEx.WriteTitleLarge("A fancy demo");
                CoEx.WriteLine();
                CoEx.WriteTable(tabledata);

                var target = Path.Combine(AppContext.BaseDirectory, "lastoutput.html");
                if (File.Exists(target))
                {
                    File.Delete(target);
                }

                writer.SaveAs(target);
                CoEx.WriteLine();
                CoEx.WriteLine("Output file: {0}", target);
            }

            CoEx.WriteLine();
            CoEx.PressAnyKey();
        }

    }
}
