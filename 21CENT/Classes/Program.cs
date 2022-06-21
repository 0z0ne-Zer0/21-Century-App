using Pastel;
using Parser = _21CENT.Services.ParserCore;
namespace _21CENT.Classes
{
    public class Programm
    {
        private static void CatalogParse(PostgreSQL.DatabaseContext db)
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

        private static void PropParse(PostgreSQL.DatabaseContext db)
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

        private static void DatabaseSync(PostgreSQL.DatabaseContext P, SQlite.DatabaseContext L, bool P2L = false, bool L2P = false)
        {
            //Post2SQLite Sync
            if (P2L)
            {
                //Main category sync
                var sourceMain = P.MainCats.ToList();
                var destMain = L.MainCats;
                foreach (var T in sourceMain)
                {
                    SQlite.MainCat C = new SQlite.MainCat{Mid = T.Mid, Name = T.Name, Link = T.Link};
                    var F = destMain.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destMain.Add(C);
                    else
                    {
                        F.Link=C.Link;
                        F.Name=C.Link;
                    }
                }
                L.SaveChanges();

                //Subcategories sync
                var sourceSub = P.SubCats.ToList();
                var destSub = L.SubCats;
                foreach (var T in sourceSub)
                {
                    SQlite.SubCat C = new SQlite.SubCat{Sid = T.Sid, Title = T.Title, Link = T.Link, Pages = T.Pages, Pmid = T.Pmid};
                    var F = destSub.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destSub.Add(C);
                    else
                    {
                        F.Link = C.Link;
                        F.Pages = C.Pages;
                        F.Pmid = C.Pmid;
                        F.Title = C.Title;
                    }
                }
                L.SaveChanges();

                //Catalog items sync
                var sourceCat = P.CatalogItems;
                var destCat = L.CatalogItems;
                foreach (var T in sourceCat)
                {
                    var discount = BitConverter.GetBytes((bool)T.Isdiscount);
                    var availiable = BitConverter.GetBytes((bool)T.Isinstock);
                    SQlite.CatalogItem C = new SQlite.CatalogItem{Cid = T.Cid, Name = T.Name, Link = T.Link, Price = T.Price, Oldprice = T.Oldprice, Props = T.Props, Psid = T.Psid, Isdiscount = discount, Isinstock = availiable};
                    var F = destCat.FirstOrDefault(c => c.Cid == C.Cid);
                    if (F == null)
                        destCat.Add(C);
                    else
                    {
                        F.Name = C.Name;
                        F.Link = C.Link;
                        F.Price = C.Price;
                        F.Oldprice = C.Oldprice;
                        F.Props = C.Props;
                        F.Psid = C.Psid; 
                        F.Isdiscount = C.Isdiscount;
                        F.Isinstock = C.Isinstock;
                    }
                }
                L.SaveChanges();
            }
            //Post2SQLite Sync
            if (L2P)
            {
                //Main category sync
                var sourceMain = L.MainCats;
                var destMain = P.MainCats;
                foreach (var T in sourceMain)
                {
                    PostgreSQL.MainCat C = new PostgreSQL.MainCat{Mid = Convert.ToInt32(T.Mid), Name = T.Name, Link = T.Link};
                    var F = destMain.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destMain.Add(C);
                    else
                    {
                        F.Link=C.Link;
                        F.Name=C.Link;
                    }
                }
                P.SaveChanges();

                //Subcategories sync
                var sourceSub = L.SubCats;
                var destSub = P.SubCats;
                foreach (var T in sourceSub)
                {
                    PostgreSQL.SubCat C = new PostgreSQL.SubCat{Sid = Convert.ToInt32(T.Sid), Title = T.Title, Link = T.Link, Pages = Convert.ToInt32(T.Pages), Pmid = Convert.ToInt32(T.Pmid)};
                    var F = destSub.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destSub.Add(C);
                    else
                    {
                        F.Link = C.Link;
                        F.Pages = C.Pages;
                        F.Pmid = C.Pmid;
                        F.Title = C.Title;
                    }
                }
                P.SaveChanges();

                //Catalog items sync
                var sourceCat = L.CatalogItems;
                var destCat = P.CatalogItems;
                foreach (var T in sourceCat)
                {
                    bool discount=false, availiable=false;

                    discount = BitConverter.ToBoolean(T.Isdiscount);
                    availiable = BitConverter.ToBoolean(T.Isinstock);
                    PostgreSQL.CatalogItem C = new PostgreSQL.CatalogItem{Cid = Convert.ToInt32(T.Cid), Name = T.Name, Link = T.Link, Price = Convert.ToInt32(T.Price), Oldprice = Convert.ToInt32(T.Oldprice), Props = T.Props, Psid = Convert.ToInt32(T.Psid), Isdiscount = discount, Isinstock = availiable};
                    var F = destCat.FirstOrDefault(c => c.Cid == C.Cid);
                    if (F == null)
                        destCat.Add(C);
                    else
                    {
                        F.Name = C.Name;
                        F.Link = C.Link;
                        F.Price = C.Price;
                        F.Oldprice = C.Oldprice;
                        F.Props = C.Props;
                        F.Psid = C.Psid; 
                        F.Isdiscount = C.Isdiscount;
                        F.Isinstock = C.Isinstock;
                    }
                }
                P.SaveChanges();
            }
        }

        private static void Main()
        {
            var SQLite_DB = new SQlite.DatabaseContext();
            var PostSQL_DB = new PostgreSQL.DatabaseContext();

            PostgreSQL.DatabaseContext.DataSource = "localhost";
            SQlite.DatabaseContext.DataSource = "Resources/Database.sqlite";
            
            Console.WriteLine($"{DateTime.Now}\tProgram start".Pastel("#00FF00"));
            DatabaseSync(PostSQL_DB, SQLite_DB, P2L:true);
            Console.WriteLine($"{DateTime.Now}\tProgram end.".Pastel("#00FF00"));
        }
    }
}