namespace Code
{
    public class Programm
    {
        private static void Main()
        {
            //Console.WriteLine("Program start: " + DateTime.Now);
            var tasks = new List<Task>();
            var baseCat = new List<string>()
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
            //Category parse
            var subCat = new List<string>[baseCat.Count];
            for (int i = 0; i < subCat.Length; i++)
                subCat[i] = new List<string>();
            for (int i = 0; i < baseCat.Count; i++)
                tasks.Add(Parser.CategoryGet(baseCat[i], subCat[i]));
            Task.WaitAll(tasks.ToArray());
            //Catalog parser
            //var url = subCat[0].ElementAt(1);
            //var result = new List<string>();
            //tasks = new List<Task>();
            //for (int i = 1; i <= 100; i++)
            //    tasks.Add(Parser.CatalogGet(url + $"page:{i}", result));
            //Task.WaitAll(tasks.ToArray());
            //Console.WriteLine("Program end: " + DateTime.Now);
        }
    }
}