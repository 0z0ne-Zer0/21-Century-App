using Pastel;

namespace Code
{
    public class Programm
    {
        private static void Main()
        {
            Console.WriteLine(("Program start:\t" + DateTime.Now).Pastel("#00FF00"));
            //Console.WriteLine("Starting parsing main categories.\t" + DateTime.Now);
            //ParseLibs.CategoryParser(new List<List<Tuple<string, string>>>(18));
            var tasks = new List<Task>();
            for (int i = 0; i < 18; i++)
            {
                var res = SQLWorker.ReadTable<string>($"SELECT URL FROM subcat WHERE MCID={i + 1}");
                tasks.Add(ParseLibs.PageParser(res));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(("Program end:\t" + DateTime.Now).Pastel("#00FF00"));
            Console.ReadKey();
        }
    }
}