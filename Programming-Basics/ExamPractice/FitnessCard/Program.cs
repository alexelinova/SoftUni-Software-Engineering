using System;

namespace FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string sex = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double priceForFitnessCard = 0;
           

            if (sex == "m")
            {
                switch (sport)
                {
                    case "Gym":
                        priceForFitnessCard = 42;
                        break;
                    case "Boxing":
                        priceForFitnessCard = 41;
                        break;
                    case "Yoga":
                        priceForFitnessCard = 45;
                        break;
                    case "Zumba":
                        priceForFitnessCard = 34;
                        break;
                    case "Dances":
                        priceForFitnessCard = 51;
                        break;
                    case "Pilates":
                        priceForFitnessCard = 39;
                        break;
                }
            }
            else if (sex == "f")
            {
                switch (sport)
                {
                    case "Gym":
                        priceForFitnessCard = 35;
                        break;
                    case "Boxing":
                        priceForFitnessCard = 37;
                        break;
                    case "Yoga":
                        priceForFitnessCard = 42;
                        break;
                    case "Zumba":
                        priceForFitnessCard = 31;
                        break;
                    case "Dances":
                        priceForFitnessCard = 53;
                        break;
                    case "Pilates":
                        priceForFitnessCard = 37;
                        break;
                }
            }
            if (age <= 19 )
            {
                priceForFitnessCard -= priceForFitnessCard * 0.2;

            }

            if (budget >= priceForFitnessCard)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");

            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${priceForFitnessCard- budget:f2} more.");
            }
        }
    }
}
