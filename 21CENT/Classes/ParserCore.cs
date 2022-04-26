using AngleSharp;

namespace Code
{
    internal class ParserCore
    {
        private static Random rn = new Random(DateTime.Now.Second);

        public static async Task CatalogGet(string url, List<string> result) //Catalog parser
        {
            var config = Configuration.Default.WithDefaultLoader();
            using (var context = BrowsingContext.New(config))
            {
                Thread.Sleep(rn.Next(1000)); //Wait to bypass protection
                using (var doc = await context.OpenAsync(url)) //Open URL
                {
                    var list = doc.GetElementsByClassName("result__root"); //Parse for needed content
                    foreach (var item in list)
                    {
                        var str = item.Children[1].GetAttribute("href") + "?print"; //Get versions for print
                        if (!result.Contains(str)) //Eliminate copies
                            result.Add(str);
                        else
                            return;
                    }
                }
            }
        }

        public static async Task CategoryGet(string url, List<Tuple<string, string>> result) //Gets categories from section index
        {
            //Console.WriteLine(url + " started at " + DateTime.Now);
            var config = Configuration.Default.WithDefaultLoader();
            using (var context = BrowsingContext.New(config))
            {
                //Thread.Sleep(rn.Next(500));
                using (var doc = await context.OpenAsync(url)) //Open given URL
                {
                    //Console.WriteLine("parsing: " + url);
                    var list = doc.GetElementsByTagName("dt"); //Parse for <dt> tags
                    foreach (var I in list)
                    {
                        var item = I.Children[0];
                        if (item.InnerHtml.Contains("span")) //Sorting out garbage
                            continue;
                        var link = item.GetAttribute("href");
                        if (String.IsNullOrEmpty(link) || link.Split("/").Length > 5) //Sorting out garbage (second time)
                            continue;
                        var key = item.TextContent;
                        result.Add(new Tuple<string, string>(key, link));
                    }
                }
            }
            //Console.WriteLine(url + " ended at " + DateTime.Now);
        }

        public static async Task<int> PageCountGet(string url) //Gets page count in given Catalog
        {
            int pageAMT = 1;
            var config = Configuration.Default.WithDefaultLoader();
            using (var context = BrowsingContext.New(config))
            {
                using (var doc = await context.OpenAsync(url)) //Open URL
                {
                    Console.WriteLine("page count of " + url);
                    var T = doc.GetElementsByClassName("cr-paging_nav"); //Get page count if exists
                    if (T.Length == 0)
                        return pageAMT;
                    string tmp = T[0].TextContent.Trim().Split("/")[1].Replace(">", ""); //Get last number
                    pageAMT = Int32.Parse(tmp);
                }
            }
            return pageAMT;
        }
    }
}