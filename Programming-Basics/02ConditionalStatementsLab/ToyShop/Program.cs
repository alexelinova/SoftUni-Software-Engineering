using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForExcursion = double.Parse(Console.ReadLine());
            int numberOfPuzzles = int.Parse(Console.ReadLine());
            int numberOfPuppets = int.Parse(Console.ReadLine());
            int numberOfTeddyBears = int.Parse(Console.ReadLine());
            int numberOfMinions = int.Parse(Console.ReadLine());
            int numberOfTrucks = int.Parse(Console.ReadLine());

            int allToys = numberOfPuzzles + numberOfPuppets + numberOfMinions + numberOfTeddyBears + numberOfTrucks;
            double moneyFromToys = numberOfPuzzles * 2.60 + numberOfPuppets * 3 + numberOfTeddyBears * 4.10 + numberOfMinions * 8.20 + numberOfTrucks * 2;

            if (allToys >= 50)
            {
                moneyFromToys -= moneyFromToys * 0.25;
            }

            double leftMoney = moneyFromToys - 0.10 * moneyFromToys;

            if (leftMoney >= priceForExcursion)
            {
                Console.WriteLine($"Yes! {leftMoney - priceForExcursion:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {priceForExcursion - leftMoney:f2} lv needed.");
            }
        }
    }
}
