using Pastel;

namespace Code
{
    internal class ParseLibs
    {
        private static List<Tuple<string>> baseCat;
        private static object syncObject;

        public ParseLibs()
        {
            baseCat = PGRSQLWorker.Read<string>("SELECT URL FROM maincat");
            syncObject = new object();
        }

        public void CategoryParser(List<List<Tuple<string, string>>> subCat) //Category parse
        {
            var tasks = new List<Task>();
            for (int i = 0; i < baseCat.Count; i++)
                subCat.Add(new List<Tuple<string, string>>());
            Parallel.For(0, subCat.Count, i => ParserCore.CategoryGet(baseCat[i].Item1, subCat[i]));
            for (int i = 0; i < baseCat.Count; i++)
                PGRSQLWorker.Insert<string, string>(subCat[i], "Name", "URL", $"INSERT OR IGNORE INTO subcat (Name, URL, MCID) VALUES(@Name, @URL, {i + 1})");
        }

        public void PageParser(List<Tuple<string>> subCat, int ID)
        {
            Console.WriteLine($"{DateTime.Now}\tBegan counting for {baseCat[ID]}".Pastel("#00FF00"));
            List<Tuple<int, string>> res = new List<Tuple<int, string>>();
            int[] vs = new int[subCat.Count];
            Parallel.For(0, subCat.Count, i =>
             {
                 vs[i] = ParserCore.PageCountGet(subCat[i].Item1);
             });
            for (int i = 0; i < subCat.Count; i++)
                res.Add(Tuple.Create(vs[i], subCat[i].Item1));
            Console.WriteLine("asd");
            try
            {
                Monitor.Enter(syncObject);
                PGRSQLWorker.Insert<int, string>(res, "Pages", "URL", $"UPDATE subcat SET Pages=@Pages WHERE URL=@URL");
                Console.WriteLine($"{DateTime.Now}\tPages for {baseCat[ID]} counted.".Pastel("#00FF00"));
            }
            finally
            {
                Monitor.Exit(syncObject);
            }
        }

        public void CatalogParser(List<Tuple<string, long, long>> subCat) //Catalog subset parse
        {
            List<Tuple<string, string, long>> goods = new List<Tuple<string, string, long>>();
            Parallel.ForEach(subCat, cat =>
            {
                Console.WriteLine($"{DateTime.Now}\tStarting parsing {cat.Item1} now".Pastel("#FFFF00"));
                Parallel.For(0, cat.Item2, i => ParserCore.CatalogGet($"{cat.Item1}page:{i+1}", cat.Item3, goods));
            });
            PGRSQLWorker.Insert<string, string, long>(goods, "Name", "URL", "SCID", $"INSERT OR IGNORE INTO goods (Name, URL, SCID) VALUES(@NAME, @URL, @SCID)");
        }
    }
}