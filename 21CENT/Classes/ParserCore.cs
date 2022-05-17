using AngleSharp;
using AngleSharp.Dom;
using Pastel;

namespace Code
{
    internal class ParserCore
    {
        public static void CategoryGet(string url, List<Tuple<string, string>> result) //Gets categories from section index
        {
            Console.WriteLine($"{DateTime.Now}\tDebug: started parsing {url}".Pastel("#9c9c9c"));
            WebPage webPage = new WebPage(url);
            webPage.Load().Wait();
            var list = webPage.FindByTag("dt"); //Parse for <dt> tags
            Parallel.ForEach(list, I =>
            {
                var item = I.Children[0];
                if (item.InnerHtml.Contains("span")) //Sorting out garbage
                    return;
                var link = item.GetAttribute("href");
                if (String.IsNullOrEmpty(link) || link.Split("/").Length > 5) //Sorting out garbage (second time)
                    return;
                var key = item.TextContent;
                result.Add(new Tuple<string, string>(key, link));
            });
            Console.WriteLine($"{DateTime.Now}\tDebug: Ended parsing {url}".Pastel("#9c9c9c"));
        }

        public static int PageCountGet(string url) //Gets page count in given Catalog
        {
            int pageAMT = 1;
            WebPage webPage = new WebPage(url);
            Console.WriteLine($"{DateTime.Now}\tDebug: page count of {url}".Pastel("#9c9c9c"));
            webPage.Load().Wait();
            var T = webPage.FindByClass("cr-paging_nav"); //Get page count if exists
            if (T.Length == 0)
                return pageAMT;
            string tmp = T[0].TextContent.Trim().Split("/")[1].Replace(">", ""); //Get last number
            pageAMT = Int32.Parse(tmp);
            return pageAMT;
        }

        public static void CatalogGet(string url, long ID, List<Tuple<string, string, long>> result) //Catalog parser
        {
            WebPage webPage = new WebPage(url);
            webPage.Load().Wait();
            var list = webPage.FindByClass("result__root"); //Parse for needed content
            Parallel.ForEach(list, item =>
            {
                string str = item.Children[1].GetAttribute("href") + "?print", name; //Get versions for print
                WebPage webPage1 = new WebPage(str);
                webPage1.Load().Wait();
                var lst = webPage1.FindByClass("content__header");
                name = lst[0].TextContent;
                Console.WriteLine($"{DateTime.Now}\tDebug: Trying to add {name} @ {str}".Pastel("#9c9c9c"));
                if (!result.Contains(new Tuple<string, string, long>(str, name, ID))) //Eliminate copies
                    result.Add(new Tuple<string, string, long>(str, name, ID));
                else
                    return;
            });
        }
    }

    internal sealed class WebPage
    {
        private IDocument _ashDocument;
        private readonly string _url;
        private static readonly Random rn = new(DateTime.Now.Second);

        public WebPage(string U)
        {
            _url = U;
        }

        public async Task Load()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            Thread.Sleep(rn.Next(1000));                 //Wait to bypass protection
            _ashDocument = await context.OpenAsync(_url);
        }

        public IHtmlCollection<IElement> FindByClass(string name)
        {
            return _ashDocument.GetElementsByClassName(name);
        }

        public IHtmlCollection<IElement> FindByTag(string name)
        {
            return _ashDocument.GetElementsByTagName(name);
        }
    }
}