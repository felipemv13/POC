using System;

namespace ClassProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizzard cWizzard = new Wizzard();

            cWizzard.Age = 18;
            cWizzard.Age = 300;

            Console.WriteLine("The age is {0}.", cWizzard.Age);

            Console.Read();
        }
    }
}
