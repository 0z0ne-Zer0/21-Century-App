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

        public static void CategoryParser(List<string>[] subCat) //Category parse
        {
            var tasks = new List<Task>();
            for (int i = 0; i < subCat.Length; i++)
                subCat[i] = new List<string>();
            for (int i = 0; i < baseCat.Count; i++)
                tasks.Add(ParserCore.CategoryGet(baseCat[i], subCat[i]));
            Task.WaitAll(tasks.ToArray());
        }

        public static async Task PageParser(List<string> subCat, int[] pageCount, int o) //Page counting for URL subset
        {
            Console.WriteLine($"OPID{o + 1}.\tStarting parsing {baseCat[o]} for page counts now.\t" + DateTime.Now);
            var tasks = new List<Task<int>>();
            for (int i = 0; i < subCat.Count; i++)
                tasks.Add(ParserCore.PageCountGet(subCat[i]));
            await Task.WhenAll(tasks.ToArray());
            for (int i = 0; i < subCat.Count; i++)
                pageCount[i] = tasks[i].Result;
        }

        public static void CatalogParser(List<string> subCat, int[] pageCount, List<string>[] goods) //Catalog subset parse
        {
            var tasks = new List<Task>();
            for (int i = 0; i < subCat.Count; i++)
                goods[i] = new List<string>();
            for (int i = 0; i < subCat.Count; i++)
            {
                tasks.Clear();
                Console.WriteLine($"OPID{i + 1}.\tStarting parsing {subCat[i]} now.\t" + DateTime.Now);
                for (int j = 1; j <= pageCount[i]; j++)
                    tasks.Add(ParserCore.CatalogGet(subCat[i] + $"page:{j}", goods[i]));
                Task.WaitAll(tasks.ToArray());
            }
        }
    }
}