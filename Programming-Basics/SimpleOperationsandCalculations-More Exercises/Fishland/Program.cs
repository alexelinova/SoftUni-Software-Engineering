using System;

namespace Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForMackerel = double.Parse(Console.ReadLine());
            double priceForSpratFish = double.Parse(Console.ReadLine());

            double BonitoKg = double.Parse(Console.ReadLine());
            double horseMackerelKG = double.Parse(Console.ReadLine());
            double clamsKg = double.Parse(Console.ReadLine());

            double BonitoPrice = (0.6 * priceForMackerel + priceForMackerel) * BonitoKg;
            double horseMackerelPrice = (0.8 * priceForSpratFish + priceForSpratFish) * horseMackerelKG;
            double priceForClams = 7.50 * clamsKg;
            Console.WriteLine($"{BonitoPrice + horseMackerelPrice + priceForClams:f2}");
        }
    }
}
