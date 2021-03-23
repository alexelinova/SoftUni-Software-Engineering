using System;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int FoodLeftKg = int.Parse(Console.ReadLine());
            double foodPerDayDogKg = double.Parse(Console.ReadLine());
            double foodPerDayForCatKg = double.Parse(Console.ReadLine());
            double foodPerDayForTurtleGrams = double.Parse(Console.ReadLine());

            double eatenFood = foodPerDayDogKg * days + foodPerDayForCatKg * days + foodPerDayForTurtleGrams * days / 1000;

            if (eatenFood > FoodLeftKg)
            {
                Console.WriteLine($"{Math.Ceiling(eatenFood - FoodLeftKg)} more kilos of food are needed.");
            }
            else
            {
                Console.WriteLine($"{Math.Floor(FoodLeftKg - eatenFood)} kilos of food left.");
            }
        }
    }
}
