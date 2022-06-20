using UI.Models;

namespace UI.Services
{
    internal class ParserCore
    {
        public static List<SubCat> CategoryGet(MainCat parent) //Gets categories from section index
        {
            List<SubCat> result = new();
            WebPage webPage = new(parent.Link);

            Console.WriteLine("21Cent\t" + $"Debug: started parsing {parent.Link}");

            webPage.Load().Wait();
            var list = webPage.QuerySelector("dt > a.cloud-sub__header"); //Parse for <dt> tags
            Parallel.ForEach(list, I =>
            {
                var link = I.GetAttribute("href"); //Getting link
                var title = I.TextContent; //Getting content title
                result.Add(new Models.SubCat { Title = title, Link = link, Pmid = parent.Mid });
            });

            Console.WriteLine("21Cent\t" + $"Debug: Ended parsing {parent.Link}");

            return result;
        }

        public static int PageCountGet(SubCat item) //Gets page count in given Catalog
        {
            int pageAMT = 1;
            WebPage webPage = new(item.Link);

            Console.WriteLine("21Cent\t" + $"Debug: page count of {item.Link}");

            webPage.Load().Wait();
            var T = webPage.FindByClass("cr-paging_nav"); //Get page count if exists
            if (T.Length == 0)
                return pageAMT; //If there is none return 1 page

            string tmp = T[0].TextContent.Trim().Split('/')[1].Replace(">", ""); //Get last number
            pageAMT = int.Parse(tmp);

            return pageAMT;
        }



        public static List<CatalogItem> CatalogGet(string url) //Catalog parser
        {
            List<CatalogItem> result = new();
            WebPage webPage = new(url);

            webPage.Load().Wait();

            var list = webPage.QuerySelector("dt.result__root > a"); //Parse link + name
            Parallel.ForEach(list, item =>
            {
                static string Cleaner(string deb) //Price string cleaner
                {
                    if (deb.Contains("р."))
                        deb = deb.Remove(deb.Length - 2);
                    deb = deb.Replace(",", ".");
                    deb = deb.Replace(" ", "");
                    return deb;
                }

                bool stock = false, discount = false;
                string link = "", name = "";
                double old = 0, cur = 0;

                link = item.GetAttribute("href") + "?print";  //Get versions for print
                name = item.Children[1].TextContent;  //Get name

                var T = new WebPage(link);
                T.Load().Wait();

                var lst = T.FindByClass("g-item-data");
                if (lst[0].TextContent != "нет на складе")  //Get avaliability
                {
                    stock = true;
                    lst = T.FindByClass("g-price");
                    if (lst.Length == 2) //Get discount
                    {
                        discount = true;
                        string deb1 = Cleaner(lst[0].TextContent.Split(' ')[0]), deb2 = Cleaner(lst[1].TextContent);
                        old = double.Parse(deb1); //Prices if discount==true
                        cur = double.Parse(deb2);
                    }
                    else if (lst.Length == 1)
                    {
                        discount = false;
                        string deb = Cleaner(lst[0].TextContent);
                        cur = double.Parse(deb); //Prices if discount==false
                    }
                }
                Console.WriteLine("21Cent\t" + $"Loading {name} @ {link}");
                result.Add(new Models.CatalogItem { Name = name, Link = link, Isinstock = stock, Isdiscount = discount, Oldprice = (float?)old, Price = (float?)cur }); //Adding item
            });

            return result;
        }
    }
}