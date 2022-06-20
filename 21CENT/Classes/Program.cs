using Pastel;
using _21CENT.Services;
using Parser = _21CENT.Services.ParserCore;
using AngleSharp;

namespace _21CENT.Classes
{
    public class Programm
    {
        private static void CatalogParse(PostDatabaseControl db)
        {
            var categories = db.SubCats.ToList();
            foreach (var T in categories)
            {
                Console.WriteLine($"{DateTime.Now}\tParsing {T.Link}".Pastel("#007ACC"));
                var tmp = Parser.CatalogGet(T.Link + "page:1");
                foreach (var I in tmp)
                    I.Psid = T.Sid;
                db.AddRange(tmp);
                db.SaveChanges();
            }
        }

        private static void PropParse(PostDatabaseControl db)
        {
            var len = (int)Math.Ceiling((double)(db.CatalogItems.Count()/1000));
            for (int i = 0; i <= len; i++)
            {
                int curl = i*1000, curh = (i+1)*1000;
                Console.WriteLine($"{DateTime.Now}\tParsing item props indexed from {curl} to {curh}".Pastel("#007ACC"));
                Thread.Sleep(500);
                var items = db.CatalogItems.Where(c=> c.Cid>=curl && c.Cid<curh).ToList();
                Parallel.ForEach(items, T => 
                {
                    Console.WriteLine($"{DateTime.Now}\tDebug: Parsing {T.Name} props @ {T.Link}".Pastel("#515559"));
                    var _ = Parser.GetProperties(T.Link);
                    T.Isdiscount = _.Isdiscount;
                    T.Isinstock = _.Isinstock;
                    T.Price = _.Price;
                    T.Oldprice = _.Oldprice;
                    T.Props = T.Props;
                });
                db.UpdateRange(items);
                db.SaveChanges();
            }
        }

        private static void Main()
        {
            var db = new PostDatabaseControl();
            PostDatabaseControl.Host = "192.168.0.110";
            Console.WriteLine($"{DateTime.Now}\tProgram start".Pastel("#00FF00"));
            var test = db.CatalogItems.First().Link.Replace("?print", "");
            var t = new Models.WebPage(test);
            t.Load().Wait();
            Console.WriteLine($"{DateTime.Now}\tProgram end.".Pastel("#00FF00"));
        }
    }
}