using AngleSharp;
using System.Net;

namespace _21CENT
{
    public class Programm
    {
        //private static string GetNumbers(string input)
        //{
        //    return new string(input.Where(c => char.IsDigit(c)).ToArray());
        //}

        //private static async void PageNav(string url, int pCount)
        //{
        //    var config = Configuration.Default.WithDefaultLoader();
        //    using (var context = BrowsingContext.New(config))
        //    {
        //        using (var doc = await context.OpenAsync(url))
        //        {
        //            var elem = doc.GetElementsByClassName("cr-paging_nav");
        //            string str = GetNumbers(elem[0].TextContent.Trim()).Remove(1, 1);
        //            pCount = int.Parse(str);
        //        }
        //    }
        //}

        private static async Task ListGet(string url, List<string> result)
        {
            var config = Configuration.Default.WithDefaultLoader();
            using (var context = BrowsingContext.New(config))
            {
                using (var doc = await context.OpenAsync(url))
                {
                    var list = doc.GetElementsByClassName("result__root");
                    foreach (var item in list)
                    {
                        var str = item.Children[1].GetAttribute("href") + "?print";
                        if (!result.Contains(str))
                            result.Add(str);
                    }
                }
            }
        }

        private static void Main()
        {
            string path = @"..\output.txt";
            File.Create(path);
            var url = "https://21vek.by/mobile";
            //int pCount = 0;
            var result = new List<string>();
            var tasks = new List<Task>();
            for (int i = 1; i <= 20; i++)
                tasks.Add(ListGet(url + $"/page:{i}", result));
            Task.WaitAll(tasks.ToArray());
            Console.ReadKey();
        }
    }
}