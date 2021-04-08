using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            long originalPokePower = long.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            byte exhaustinFactor = byte.Parse(Console.ReadLine());
            long pokePower = originalPokePower;

            int pokedTargets = 0;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                pokedTargets++;
                if (pokePower == (double)originalPokePower/2 && exhaustinFactor > 0)
                { 
                        pokePower = pokePower / exhaustinFactor;
   
                }

            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);
        }
    }
}
