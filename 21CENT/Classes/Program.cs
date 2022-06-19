using Pastel;

namespace _21CENT.Classes
{
    public class Programm
    {

        private static void Main()
        {
            var db = new Services.PostDatabaseControl();
            Services.PostDatabaseControl.Host = "192.168.0.110";
            Console.WriteLine($"{DateTime.Now}\tProgram start".Pastel("#00FF00"));
            Console.WriteLine(db.SubCats.First().Link);
            Console.ReadKey();
            Console.WriteLine($"{DateTime.Now}\tProgram end.".Pastel("#00FF00"));
        }
    }
}