using System;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            string product = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            Console.WriteLine(6 * 1.2);

            double price = 0.00;

            if (town == "Sofia")
            {
                if (product == "coffee")
                {
                    price = quantity * 0.5;
                }
                else if (product == "water")
                {
                    price = quantity * 0.8;
                }
                else if (product == "beer")
                {
                    price = quantity * 1.20;
                }
                else if (product == "sweets")
                {
                    price = quantity * 1.45;
                }
                else if (product == "peanuts")
                {
                    price = quantity * 1.60;
                }

            }
            else if (town == "Plovdiv")
            {
                if (product == "coffee")
                {
                    price = quantity * 0.4;
                }
                else if (product == "water")
                {
                    price = quantity * 0.7;
                }
                else if (product == "beer")
                {
                    price = quantity * 1.15;
                }
                else if (product == "sweets")
                {
                    price = quantity * 1.30;
                }
                else if (product == "peanuts")
                {
                    price = quantity * 1.60;
                }

            }
            else if (town == "Varna")
            {
                if (product == "coffee")
                {
                    price = quantity * 0.45;
                }
                else if (product == "water")
                {
                    price = quantity * 0.7;
                }
                else if (product == "beer")
                {
                    price = quantity * 1.1;
                }
                else if (product == "sweets")
                {
                    price = quantity * 1.35;
                }
                else if (product == "peanuts")
                {
                    price = quantity * 1.60;
                }
            }

            Console.WriteLine(price);
        }
    }
}
