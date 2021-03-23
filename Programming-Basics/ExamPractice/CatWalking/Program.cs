using System;

namespace CatWalking
{
    class Program
    {
        static void Main(string[] args)

        {

            int minutes = int.Parse(Console.ReadLine());
            int numberOfWalking = int.Parse(Console.ReadLine());
            double caloriesPerDay = double.Parse(Console.ReadLine());

            int totalMinutes = minutes * numberOfWalking;
            double caloriesBurnt = totalMinutes * 5 * 1.0;
           
           
            if (caloriesPerDay * 0.5 <= caloriesBurnt)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriesBurnt}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriesBurnt}.");
            }
        }
    }
}
