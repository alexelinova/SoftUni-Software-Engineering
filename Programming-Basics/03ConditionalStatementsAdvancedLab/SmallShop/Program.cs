using System;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //чете продукт(низ), град(низ) и количество(десетично число),
            string productName = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;

            if (town == "Sofia")
            {
                //coffee water beer sweets peanuts
                if (productName == "coffee")
                {
                    price = quantity * 0.5;
                }

                else if (productName == "water")
                {
                    price = quantity * 0.8;
                }

                else if (productName == "beer")
                {
                    price = quantity * 1.20;
                }

                else if (productName == "sweets")
                {
                    price = quantity * 1.45;
                }

                else if (productName == "peanuts")
                {
                    price = quantity * 1.60;
                }
            }
            else if (town == "Plovdiv")
            {
                if (productName == "coffee")
                {
                    price = quantity * 0.4;
                }

                else if (productName == "water")
                {
                    price = quantity * 0.7;
                }

                else if (productName == "beer")
                {
                    price = quantity * 1.15;
                }

                else if (productName == "sweets")
                {
                    price = quantity * 1.30;
                }

                else if (productName == "peanuts")
                {
                    price = quantity * 1.50;
                }
            }
            else if (town == "Varna")
            {
                if (productName == "coffee")
                {
                    price = quantity * 0.45;
                }

                else if (productName == "water")
                {
                    price = quantity * 0.7;
                }

                else if (productName == "beer")
                {
                    price = quantity * 1.10;
                }

                else if (productName == "sweets")
                {
                    price = quantity * 1.35;
                }

                else if (productName == "peanuts")
                {
                    price = quantity * 1.55;
                }
            }

            Console.WriteLine(price);
        }
    }
}
