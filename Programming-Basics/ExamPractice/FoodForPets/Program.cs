using System;

namespace FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {

            int countOfDays = int.Parse(Console.ReadLine());
            double foodAmount = double.Parse(Console.ReadLine());
            int foodDogTotal = 0;
            int foodCatTotal = 0;
            double totalBiscuits = 0;
            int counter = 0;

            for (int i = 1; i <= countOfDays; i++)
            {
                int foodEatenByDog = int.Parse(Console.ReadLine());
                int foodEatenByCat = int.Parse(Console.ReadLine());
                foodDogTotal += foodEatenByDog;
                foodCatTotal += foodEatenByCat;
                counter++;

                if (counter == 3)
                {
                    totalBiscuits += 0.10 * (foodEatenByCat + foodEatenByDog);
                    counter = 0;
                }
            }

            double foodEatenByBoth = foodCatTotal + foodDogTotal;
            Console.WriteLine($"Total eaten biscuits: {Math.Round(totalBiscuits)}gr.");
            Console.WriteLine($"{(foodCatTotal + foodDogTotal) / foodAmount * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{foodDogTotal / foodEatenByBoth * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{foodCatTotal / foodEatenByBoth * 100:f2}% eaten from the cat.");

        }
    }
}
