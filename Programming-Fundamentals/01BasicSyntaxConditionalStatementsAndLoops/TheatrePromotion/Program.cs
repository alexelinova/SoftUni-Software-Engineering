using System;

namespace TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOfWeek = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());

            if (dayOfWeek == "weekday")
            {
                if (age >= 0 && age <= 18 || age > 64 && age <= 122)
                {
                    Console.WriteLine("12$");
                }
                else if (age > 18 && age <= 64)
                {
                    Console.WriteLine("18$");
                }
            }
            else if (dayOfWeek == "weekend")
            {
                if (age >= 0 && age <= 18 || age > 64 && age <= 122)
                {
                    Console.WriteLine("15$");
                }
                else if (age > 18 && age <= 64)
                {
                    Console.WriteLine("20$");
                }
            }
            else if (dayOfWeek == "holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    Console.WriteLine("5$");
                }
                else if (age > 18 && age <= 64)
                {
                    Console.WriteLine("12$");
                }
                else if (age > 64 && age <= 122)
                {
                    Console.WriteLine("10$");
                }
            }

            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
            }

        }
    }
}
