using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysforStay = int.Parse(Console.ReadLine());
            string accommodation = Console.ReadLine();
            string review = Console.ReadLine();
            double price = 0;

            int nights = daysforStay - 1;

            if (nights < 10)
            {
                if (accommodation == "room for one person")
                {
                    price = 18 * nights;
                }
                else if (accommodation == "apartment")
                {
                    price = nights * 25 - nights * 25 * 0.3;
                }
                else if (accommodation == "president apartment")
                {
                    price = nights * 35 - nights * 35 * 0.1;
                }
            }
            else if (nights >= 10 && nights <= 15)
            {
                if (accommodation == "room for one person")
                {
                    price = 18 * nights;
                }
                else if (accommodation == "apartment")
                {
                    price = nights * 25 - nights * 25 * 0.35;
                }
                else if (accommodation == "president apartment")
                {
                    price = nights * 35 - nights * 35 * 0.15;
                }
            }
            else if (nights > 15)
            {
                if (accommodation == "room for one person")
                {
                    price = 18 * nights;
                }
                else if (accommodation == "apartment")
                {
                    price = nights * 25 - nights * 25 * 0.5;
                }
                else if (accommodation == "president apartment")
                {
                    price = nights * 35 - nights * 35 * 0.2;
                }
            }
            if (review == "positive")
            {
                price += price * 0.25;
            }
            else if (review == "negative")
            {
                price -= price * 0.10;
            }
            Console.WriteLine($"{price:f2}");
               
        }
    }
}
