using System;

namespace FuelTankPartTwo
{
    class Program
    {
        static void Main(string[] args)
        {

          
            string typeOfFuel = Console.ReadLine();
            double quantityFuel = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();

            double price = 0;

            if (typeOfFuel == "Gas")
            {
                price = 0.93 * quantityFuel;
                if (clubCard == "Yes")
                {
                    price = (0.93 - 0.08) * quantityFuel;
                }
            }
            else if (typeOfFuel == "Gasoline")
            {
                price = 2.22 * quantityFuel;
                if (clubCard == "Yes")
                {
                    price = (2.22 - 0.18) * quantityFuel;
                }
            }
            else if (typeOfFuel == "Diesel")
            {
                price = 2.33 * quantityFuel;
                if (clubCard == "Yes")
                {
                    price = (2.33 - 0.12) * quantityFuel;
                }
            }

            if (quantityFuel >= 20 && quantityFuel <= 25)
            {
                price -= price * 0.08;
            }
            else if (quantityFuel > 25)
            {
                price -= price * 0.10;
            }

            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
