using Pastel;

namespace Code
{
    internal class ParseLibs
    {
        private static List<string> baseCat = new List<string>()
            {
                {"https://www.21vek.by/kitchen/" },
                {"https://www.21vek.by/electronics/" },
                {"https://www.21vek.by/computers/" },
                {"https://www.21vek.by/furniture/" },
                {"https://www.21vek.by/house/" },
                {"https://www.21vek.by/sanitary_engineering/" },
                {"https://www.21vek.by/repairs/" },
                {"https://www.21vek.by/repairing_tools/" },
                {"https://www.21vek.by/garden/" },
                {"https://www.21vek.by/cars/" },
                {"https://www.21vek.by/kids/" },
                {"https://www.21vek.by/beauty/" },
                {"https://www.21vek.by/beauty_and_health/" },
                {"https://www.21vek.by/sport/" },
                {"https://www.21vek.by/tourism_activities/" },
                {"https://www.21vek.by/pet_supplies/" },
                {"https://www.21vek.by/business/" },
                {"https://www.21vek.by/hobby_supplies/" }
            };

        private static object syncObject = new object();

        public static void CategoryParser(List<List<Tuple<string, string>>> subCat) //Category parse
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 18; i++)
                subCat.Add(new List<Tuple<string, string>>());
            for (int i = 0; i < baseCat.Count; i++)
                tasks.Add(ParserCore.CategoryGet(baseCat[i], subCat[i]));
            Task.WaitAll(tasks.ToArray());
            for (int i = 0; i < 18; i++)
                SQLWorker.InsertList<string, string>(subCat[i], "Name", "URL", $"INSERT OR REPLACE INTO subcat (Name, URL, MCID) VALUES(?,?,{i + 1})");
        }

        public static async Task PageParser(List<Tuple<string>> subCat) //Page counting for URL subset
        {
            Console.WriteLine(($"Starting parsing {subCat} for page counts now.\t" + DateTime.Now).Pastel("#FFFF00"));
            var tasks = new List<Task<int>>();
            for (int i = 0; i < subCat.Count; i++)
                tasks.Add(ParserCore.PageCountGet(subCat[i].Item1));
            await Task.WhenAll(tasks.ToArray());
            Console.WriteLine(($"\tPages for {subCat} counted.\t" + DateTime.Now).Pastel("#00FF00"));
            List<Tuple<int, string>> res = new List<Tuple<int, string>>();
            for (int i = 0; i < subCat.Count; i++)
                res.Add(Tuple.Create(tasks[i].Result, subCat[i].Item1));
            try
            {
                Monitor.Enter(syncObject);
                SQLWorker.InsertList<int, string>(res, "page", "url", $"UPDATE subcat SET Pages=page WHERE URL=url");
            }
            finally
            {
                Monitor.Exit(syncObject);
            }
        }

        public static void CatalogParser(List<Tuple<string, int>> subCat) //Catalog subset parse
        {
            var tasks = new List<Task>();
            List<List<Tuple<string>>> goods = new List<List<Tuple<string>>>();
            for (int i = 0; i < subCat.Count; i++)
                goods[i] = new List<Tuple<string>>();
            for (int i = 0; i < subCat.Count; i++)
            {
                tasks.Clear();
                Console.WriteLine(($"OPID{i + 1}.\tStarting parsing {subCat[i].Item1} now.\t" + DateTime.Now).Pastel("#FFFF00"));
                for (int j = 1; j <= subCat[i].Item2; j++)
                    tasks.Add(ParserCore.CatalogGet(subCat[i].Item1 + $"page:{j}", goods[i]));
                Task.WaitAll(tasks.ToArray());
            }
        }
    }
}