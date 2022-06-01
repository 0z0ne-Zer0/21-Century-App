using Pastel;

namespace Code
{
    public class Programm
    {
        private static ParseLibs libs = new ParseLibs();
        private static PGRSQLWorker worker = new(IP: "192.168.0.110");

        private static void FirstTimeSetup()
        {
            Console.WriteLine($"{DateTime.Now}\tDebug: Starting parsing main categories.");
            libs.CategoryParser(new List<List<Tuple<string, string>>>(18));
            List<List<Tuple<string>>> res = new List<List<Tuple<string>>>();
            for (int i = 1; i <= 18; i++)
                res.Add(worker.Read<string>($"SELECT URL FROM subcat WHERE MCID={i}"));
            Parallel.For(0, 18, i =>
            {
                var cur = i;
                libs.PageParser(res[cur], cur);
            });
            libs = new ParseLibs();
        }

        private static void Main()
        {
            Console.WriteLine($"{DateTime.Now}\tProgram start".Pastel("#00FF00"));
            var read = worker.Read<int, string, string>("SELECT scid,name,url FROM subcat");
            Console.Write(read);
            Console.WriteLine($"{DateTime.Now}\tProgram end.".Pastel("#00FF00"));
        }
    }
}