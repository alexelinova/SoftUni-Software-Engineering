using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "0";
            string place = "0";
            double spentMoney = 0;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    spentMoney = budget * 0.30;
                    place = "Camp";
                }
                else if (season == "winter")
                {
                    spentMoney = budget * 0.7;
                    place = "Hotel";
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    spentMoney = budget * 0.40;
                    place = "Camp";
                }
                else if (season == "winter")
                {
                    spentMoney = budget * 0.8;
                    place = "Hotel";
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                if (season == "summer" || season == "winter")
                {
                    spentMoney = budget * 0.9;
                    place = "Hotel";
                }
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{place} - {spentMoney:f2}");
        }   
    }
}
