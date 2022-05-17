using Pastel;

namespace Code
{
    public class Programm
    {
        static ParseLibs libs = new ParseLibs();
        static List<Task> tasks = new List<Task>();

        private static void FirstTimeSetup()
        {
            Console.WriteLine($"{DateTime.Now}\tStarting parsing main categories.");
            libs.CategoryParser(new List<List<Tuple<string, string>>>(18));
            for (int i = 0; i < 18; i++)
            {
               var cur = i;
               var res = SQLWorker.Read<string>($"SELECT URL FROM subcat WHERE MCID={cur + 1}");
               tasks.Add(Task.Run(() => { Task.Delay(1000).Wait(); libs.PageParser(res, cur); }));
            }
            Task.WaitAll(tasks.ToArray());
            tasks.Clear();
            libs = new ParseLibs();
        }

        private static void Main()
        {
            Console.WriteLine($"{DateTime.Now}\tProgram start".Pastel("#00FF00"));
            var pages = SQLWorker.Read<string, long>($"SELECT URL,Pages FROM subcat WHERE SCID=1");
            //var cat = libs.CatalogParser(pages);
            Console.WriteLine($"{DateTime.Now}\tProgram end.".Pastel("#00FF00"));
            //Console.Read();
        }
    }
}