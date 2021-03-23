using System;

namespace Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfChrysanthemums = int.Parse(Console.ReadLine());
            int numberOfRoses = int.Parse(Console.ReadLine());
            int numberOfTulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holiday = Console.ReadLine();

            double price = 0;
           

            switch (season)
            {
                case "Spring":
                case "Summer":
                    price = numberOfChrysanthemums * 2 + numberOfRoses * 4.10 + numberOfTulips * 2.50;
                    if (numberOfTulips > 7 && season == "Spring")
                    {
                        price -= price * 0.05;
                    }
                    break;
                case "Winter":
                case "Autumn":
                    price = numberOfChrysanthemums * 3.75 + numberOfRoses * 4.50 + numberOfTulips * 4.15;
                    if (numberOfRoses >= 10 && season == "Winter")
                    {
                        price -= price * 0.10;
                    }
                    break;

            }
            if (numberOfRoses + numberOfChrysanthemums + numberOfTulips > 20)
            {
                price -= price * 0.20;
            }
            if (holiday == "Y")
            {
                price += price * 0.15;
            }
            Console.WriteLine($"{price+2:f2}");

        }
    }
}
