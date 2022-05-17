using Pastel;

namespace Code
{
    public class Programm
    {
        private static void Main()
        {
            ParseLibs libs = new ParseLibs();
            Console.WriteLine($"{DateTime.Now}\tProgram start".Pastel("#00FF00"));
            //Console.WriteLine($"{DateTime.Now}\tStarting parsing main categories.");
            //libs.CategoryParser(new List<List<Tuple<string, string>>>(18));
            var tasks = new List<Task>();
            //for (int i = 0; i < 18; i++)
            //{
            //    var cur = i;
            //    var res = SQLWorker.Read<string>($"SELECT URL FROM subcat WHERE MCID={cur + 1}");
            //    tasks.Add(Task.Run(() => { Task.Delay(1000).Wait(); libs.PageParser(res, cur); }));
            //}
            var pages = SQLWorker.Read<string, int>($"SELECT URL,Pages FROM subcat");
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"{DateTime.Now}\tProgram end.".Pastel("#00FF00"));
            Console.ReadKey();
        }
    }
}