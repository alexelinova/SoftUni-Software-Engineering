using System;

namespace _01_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());
           
            double totalEggPrice = students * eggPrice * 10;

            double totalApronPrice = Math.Ceiling(students + students * 0.2) * apronPrice;

            int freeFlour = students / 5;

            double totalFlourPrice = (students - freeFlour) * flourPrice;

            double totalPrice = totalApronPrice + totalEggPrice + totalFlourPrice;


            if (totalPrice <= budget)
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
            else
            {
                Console.WriteLine($"{totalPrice - budget:f2}$ more needed.");
            }


        }
    }
}
