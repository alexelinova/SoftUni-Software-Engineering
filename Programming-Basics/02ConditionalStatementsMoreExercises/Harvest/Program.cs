using System;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)

        {
            int xLand = int.Parse(Console.ReadLine());
            double yGrapeKgForSquareM = double.Parse(Console.ReadLine());
            int zWineNeeded = int.Parse(Console.ReadLine());
            int numberOfWorkesrs = int.Parse(Console.ReadLine());

            double grapesKg = xLand * yGrapeKgForSquareM;
            double grapesForWine = 0.4 * grapesKg;
            double litresWine = grapesForWine / 2.5;

            if (litresWine >= zWineNeeded)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(litresWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(litresWine - zWineNeeded)} liters left -> {Math.Ceiling((litresWine - zWineNeeded) /numberOfWorkesrs)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(zWineNeeded - litresWine)} liters wine needed.");
            }

        }
    }
}
