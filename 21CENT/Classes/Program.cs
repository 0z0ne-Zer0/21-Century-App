using Pastel;

namespace Code
{
    public class Programm
    {
        private static ParseLibs libs = new ParseLibs();
        private static object syncObject = new object();

        private static void FirstTimeSetup()
        {
            Console.WriteLine($"{DateTime.Now}\tDebug: Starting parsing main categories.");
            libs.CategoryParser(new List<List<Tuple<string, string>>>(18));
            List<List<Tuple<string>>> res = new List<List<Tuple<string>>>();
            for (int i = 1; i <= 18; i++)
                res.Add(SQLiteWorker.Read<string>($"SELECT URL FROM subcat WHERE MCID={i}"));
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
            SQLiteWorker.Create();
            Console.WriteLine($"{DateTime.Now}\tProgram end.".Pastel("#00FF00"));
            //Console.Read();
        }
    }
}