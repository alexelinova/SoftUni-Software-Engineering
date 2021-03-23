using System;

namespace MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int numberOfPeople = int.Parse(Console.ReadLine());

            double transport = 0;
            double ticketsPrice = 0;
            double moneyNeeded = 0;

            if (numberOfPeople <= 4)
            {
                transport = budget * 0.75;
            }
            else if (numberOfPeople <= 9)
            {
                transport = budget * 0.6;
            }
            else if (numberOfPeople <= 24)
            {
                transport = budget * 0.5;
            }
            else if (numberOfPeople <= 49)
            {
                transport = budget * 0.4;
            }
            else if (numberOfPeople >= 50)
            {
                transport = budget * 0.25;
            }

            switch (category)
            {
                case "VIP":
                    ticketsPrice = numberOfPeople * 499.99;
                    break;
                default:
                    ticketsPrice = numberOfPeople * 249.99;
                    break;
            }

            moneyNeeded = transport + ticketsPrice;

            if (moneyNeeded <= budget)
            {
                Console.WriteLine($"Yes! You have {budget - moneyNeeded:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {moneyNeeded - budget:f2} leva.");
            }
        }
    }
}
