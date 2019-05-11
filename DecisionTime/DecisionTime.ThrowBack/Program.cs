using DecisionTime.Core;
using System;

namespace DecisionTime.ThrowBack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("*     The apocalpyse happened!!!     *");
            Console.WriteLine("*     You Are a District Rep!!!!     *");
            Console.WriteLine("*   These Are Your Constituents...   *");
            Console.WriteLine("**************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var game = new Game();
            game.GenerateDistrict();

            foreach (var district in game.Districts)
            {
                Console.WriteLine($"District {game.Districts.IndexOf(district) + 1}:");
                
                foreach (var citizen in district.Citizens)
                {
                    Console.WriteLine($"\t{citizen.Name}");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to abandon them forever!");
            Console.ReadLine();
        }
    }
}
