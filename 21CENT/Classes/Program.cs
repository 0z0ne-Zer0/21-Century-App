using Pastel;

namespace _21CENT.Classes
{
    public class Programm
    {
        private static void Main()
        {
            Console.WriteLine($"{DateTime.Now}\tProgram start".Pastel("#00FF00"));

            Console.WriteLine($"{DateTime.Now}\tProgram end.".Pastel("#00FF00"));
        }
    }
}