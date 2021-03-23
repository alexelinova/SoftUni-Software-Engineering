using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());
            double priceOfBoat = 0;

            switch (season)
            {
                case "Summer":
                case "Autumn":
                    priceOfBoat = 4200;
                    break;
                case "Winter":
                    priceOfBoat = 2600;
                    break;
                case "Spring":
                    priceOfBoat = 3000;
                    break;
            }
            if ( fishermen > 0 && fishermen <= 6)
            {
                priceOfBoat -= priceOfBoat * 0.10;
            }
             else if (fishermen >= 12)
            {
                priceOfBoat -= priceOfBoat * 0.25;
            }
            else
            {
                priceOfBoat -= priceOfBoat * 0.15;
            }
            if (fishermen % 2 == 0 && season != "Autumn")
            {
                priceOfBoat -= priceOfBoat * 0.05;
            }

            if (budget >= priceOfBoat)
            {
                Console.WriteLine($"Yes! You have {budget - priceOfBoat:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {priceOfBoat - budget:f2} leva.");
            }
        }
    }
}
