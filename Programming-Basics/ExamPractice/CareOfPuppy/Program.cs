using System;

namespace CareOfPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodBought = int.Parse(Console.ReadLine());
            int foodBoughtGrams = foodBought * 1000;
            int foodEaten = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Adopted")
                {
                    break;
                }

                int gramsPerDay = int.Parse(command);
                foodEaten += gramsPerDay;

            }

            if (foodEaten <= foodBoughtGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodBoughtGrams - foodEaten} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {foodEaten - foodBoughtGrams} grams more.");
            }
        }
    }
}
