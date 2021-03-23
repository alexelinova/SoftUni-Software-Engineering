using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            const double premierPrice = 12.00;
            const double normalPrice = 7.50;
            const double discountPrice = 5.00;

            string typeOfMovie = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double income = 0;

            switch (typeOfMovie)
            {
                case "Premiere":
                    income = rows * columns * premierPrice;
                    break;
                case "Normal":
                    income = rows * columns * normalPrice;
                    break;
                case "Discount":
                    income = rows * columns * discountPrice;
                    break;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
