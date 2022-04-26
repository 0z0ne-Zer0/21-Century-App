using Pastel;

namespace Code
{
    public class Programm
    {
        private static void Main()
        {
            Console.WriteLine($"{DateTime.Now}\tProgram start".Pastel("#00FF00"));
            Console.WriteLine($"{DateTime.Now}\tStarting parsing main categories.");
            //ParseLibs.CategoryParser(new List<List<Tuple<string, string>>>(18));
            var tasks = new List<Task>();
            for (int i = 0; i < 18; i++)
            {
                tasks.Clear();
                Console.WriteLine($"{DateTime.Now}\tStarted parsing from {i + 1} to {i + 3} categories.".Pastel("#FFFF00"));
                for (int j = 0; j < 3; j++)
                {
                    var res = SQLWorker.ReadTable<string>($"SELECT URL FROM subcat WHERE MCID={i + 1}");
                    tasks.Add(ParseLibs.PageParser(res, i));
                    i++;
                }
                Task.WaitAll(tasks.ToArray());
            }
            Console.WriteLine($"{DateTime.Now}\tProgram end.".Pastel("#00FF00"));
            Console.ReadKey();
        }
    }
}