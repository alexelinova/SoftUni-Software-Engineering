using System;

namespace GodzillaVsKingKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statist = int.Parse(Console.ReadLine());
            double clothesForStatist = double.Parse(Console.ReadLine());

            double priceForClothes = statist * clothesForStatist;
            double decor = budget * 0.10;

            if (statist > 150)
            {
                priceForClothes -= priceForClothes * 0.1; 
            }

            double totalCosts = priceForClothes + decor;

            if (totalCosts > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(totalCosts - budget):f2} leva more.");
            }

            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - totalCosts):f2} leva left.");
            }
  
        }
    }
}
