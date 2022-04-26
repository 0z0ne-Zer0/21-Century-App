using Pastel;

namespace Code
{
    internal class ParseLibs
    {
        private static List<Tuple<string>> baseCat;

        private static object syncObject;

        public ParseLibs()
        {
            baseCat = SQLWorker.Read<string>("SELECT URL FROM maincat");
            syncObject = new object();
        }

        public void CategoryParser(List<List<Tuple<string, string>>> subCat) //Category parse
        {
            var tasks = new List<Task>();
            for (int i = 0; i < baseCat.Count; i++)
                subCat.Add(new List<Tuple<string, string>>());
            for (int i = 0; i < baseCat.Count; i++)
                tasks.Add(ParserCore.CategoryGet(baseCat[i].Item1, subCat[i]));
            Task.WaitAll(tasks.ToArray());
            for (int i = 0; i < baseCat.Count; i++)
                SQLWorker.Insert<string, string>(subCat[i], "Name", "URL", $"INSERT OR IGNORE INTO subcat (Name, URL, MCID) VALUES(?,?,{i + 1})");
        }

        public void PageParser(List<Tuple<string>> subCat, int ID)
        {
            Console.WriteLine($"{DateTime.Now}\tBegan counting for {baseCat[ID]}".Pastel("#00FF00"));
            List<Tuple<int, string>> res = new List<Tuple<int, string>>();
            int[] vs = new int[subCat.Count];
            Parallel.For(0, subCat.Count, i =>
             {
                 vs[i] = PageParserAux(subCat[i], ID);
             });
            for (int i = 0; i < subCat.Count; i++)
                res.Add(Tuple.Create(vs[i], subCat[i].Item1));
            try
            {
                Monitor.Enter(syncObject);
                SQLWorker.Insert<int, string>(res, "Pages", "URL", $"UPDATE subcat SET Pages=@Pages WHERE URL=@URL");
                Console.WriteLine($"{DateTime.Now}\tPages for {baseCat[ID]} counted.".Pastel("#00FF00"));
            }
            finally
            {
                Monitor.Exit(syncObject);
            }
        }

        private int PageParserAux(Tuple<string> subCat, int ID) //Page counting for URL subset
        {
            Task<int> task = null;
            try
            {
                task = Task.Run(() => ParserCore.PageCountGet(subCat.Item1));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}. Thread ID{ID}: {ex.Message}.\nAttempting restart".Pastel("#FF0000"));
                PageParserAux(subCat, ID);
            }
            return task.Result;
        }

        public void CatalogParser(List<Tuple<string, int>> subCat) //Catalog subset parse
        {
            var tasks = new List<Task>();
            List<List<Tuple<string>>> goods = new List<List<Tuple<string>>>();
            for (int i = 0; i < subCat.Count; i++)
                goods[i] = new List<Tuple<string>>();
            for (int i = 0; i < subCat.Count; i++)
            {
                tasks.Clear();
                Console.WriteLine($"{DateTime.Now}\tOPID{i + 1}.\tStarting parsing {subCat[i].Item1} now".Pastel("#FFFF00"));
                for (int j = 1; j <= subCat[i].Item2; j++)
                    tasks.Add(ParserCore.CatalogGet($"{subCat[i].Item1}page:{j}", goods[i]));
                Task.WaitAll(tasks.ToArray());
            }
        }
    }
}