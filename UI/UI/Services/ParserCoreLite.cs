using System.Xml;
using UI.Models;
using UI.Services.SQLite;

namespace UI.Services
{
    internal class ParserCoreLite
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
                result.Add(new SubCat { Title = title, Link = link, Pmid = parent.Mid });
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

        private static string Cleaner(string deb) //Price string cleaner
        {
            deb = deb.Replace("р.", "");
            deb = deb.Replace("/шт.", "");
            deb = deb.Replace(" ", "");
            deb = deb.Replace(",", ".");
            return deb;
        }

        internal static CatalogItem GetProperties(string url) //Returns properties (price, availiability, discount, other)
        {
            float oldPrice = 0, curentPrice = 0;
            bool stock = false, discount = false;
            XmlDocument doc = new();
            WebPage webPage = new(url);

            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);
            webPage.Load().Wait();

            var lst = webPage.FindByClass("g-item-data");
            if (lst[0].TextContent != "нет на складе")  //Get avaliability
            {
                stock = true;
                lst = webPage.FindByClass("g-price");
                if (lst.Length == 2) //Get discount
                {
                    discount = true;
                    string deb1 = Cleaner(lst[0].Children[0].TextContent.Split(' ')[0]), deb2 = Cleaner(lst[0].Children[1].TextContent);
                    oldPrice = float.Parse(deb1); //Prices if discount==true
                    curentPrice = float.Parse(deb2);
                }
                else if (lst.Length == 1)
                {
                    discount = false;
                    string deb = Cleaner(lst[0].TextContent);
                    curentPrice = float.Parse(deb); //Prices if discount==false
                }
            }

            var list = webPage.FindByClass("attrs__group");//Find tables with other properties
            foreach (var T in list)
            {
                if (T.Children.Count() == 0)
                    continue;
                var sec = doc.CreateElement("section"); //First row of each table is section name
                sec.SetAttribute("name", T.Children[0].Children[0].TextContent);
                foreach (var I in T.Children.Skip(1))
                {
                    var cur = doc.CreateElement("prop");
                    cur.SetAttribute("type", I.Children[0].TextContent); //First cell in each row is name of parameter
                    cur.InnerText = (I.Children[1].TextContent); //Second cell is always the value
                    sec.AppendChild(cur);
                }
                root.AppendChild(sec); //Add all parameters to current section
            }

            return new CatalogItem { Isdiscount = BitConverter.GetBytes(discount), Isinstock = BitConverter.GetBytes(stock), Oldprice = oldPrice, Price = curentPrice, Props = doc.OuterXml };
        }

        public static List<CatalogItem> CatalogGet(string url) //Catalog parser
        {
            List<CatalogItem> result = new();
            WebPage webPage = new(url);

            webPage.Load().Wait();
            var list = webPage.QuerySelector("dt > a.result__link"); //Parse link + name
            Parallel.ForEach(list, item =>
            {
                string link = "", name = "";
                link = item.GetAttribute("href") + "?print";  //Get versions for print
                name = item.Children[1].TextContent;  //Get name
                result.Add(new CatalogItem { Name = name, Link = link }); //Adding item
            });

            return result;
        }
    }
}