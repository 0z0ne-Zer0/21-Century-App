namespace Code
{
    public class Programm
    {
        private static void Main()
        {
            //Console.WriteLine("Program start: " + DateTime.Now);
            int[][] pageCount = new int[18][];
            var subCat = new List<string>[18];
            List<string>[] catalog;
            Console.WriteLine("Starting parsing main categories.\t" + DateTime.Now);
            ParseLibs.CategoryParser(subCat);
            var tasks = new List<Task>();
            for (int i = 0; i < subCat.Length; i++)
                tasks.Add(ParseLibs.PageParser(subCat[i], pageCount[i] = new int[subCat[i].Count], i));
            Task.WaitAll(tasks.ToArray());
            //for (int i = 0; i < subCat.Length; i++)
            //{
            //    Console.WriteLine($"OPID{i + 1}.\tStarting parsing catalog {baseCat[i]} now.\t" + DateTime.Now);
            //    CatalogParser(subCat[i], pageCount[i], catalog = new List<string>[subCat[i].Count]);
            //}
            Console.WriteLine("Program end:\t" + DateTime.Now);
            Console.ReadKey();
        }
    }
}