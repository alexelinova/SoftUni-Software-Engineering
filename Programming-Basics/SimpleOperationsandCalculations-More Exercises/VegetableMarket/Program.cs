using System;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForVegetables = double.Parse(Console.ReadLine());
            double priceForFruits = double.Parse(Console.ReadLine());
            int kgVegetables = int.Parse(Console.ReadLine());
            int kgFruits = int.Parse(Console.ReadLine());

            double income = (priceForVegetables * kgVegetables + priceForFruits * kgFruits) / 1.94;
            Console.WriteLine($"{income:f2}");



        }
    }
}
