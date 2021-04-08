using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double budget = 0.00;


            while (command != "Start")
            {
                double coin = double.Parse(command);

                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    budget += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }

                command = Console.ReadLine();
            }

            string product = Console.ReadLine();
            bool isRealProduct = true;

            double price = 0.00;

            while (product != "End")
            {
                if (product == "Nuts")
                {
                    price = 2.0;
                }
                else if (product == "Water")
                {
                    price = 0.7;
                }
                else if (product == "Crisps")
                {
                    price = 1.5;
                }
                else if (product == "Soda")
                {
                    price = 0.8;
                }
                else if (product == "Coke")
                {
                    price = 1.0;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    isRealProduct = false;
                }

                if (isRealProduct)
                {
                    if (budget >= price)
                    {
                        budget -= price;
                        Console.WriteLine($"Purchased {product.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }


                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {budget:f2}");
        }
    }
}
