using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> priceByProduct = new Dictionary<string, double>();

            Dictionary<string, int> quantityByProduct = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] parts = input.Split();

                string product = parts[0];

                double price = double.Parse(parts[1]);

                int quantity = int.Parse(parts[2]);

                if (priceByProduct.ContainsKey(product))
                {
                    priceByProduct[product] = price;
                    quantityByProduct[product] += quantity;
                }
                else
                {
                    priceByProduct.Add(product, price);
                    quantityByProduct.Add(product, quantity);
                }
            }

            foreach (var item in priceByProduct)
            {
                Console.WriteLine($"{item.Key} -> {item.Value * quantityByProduct[item.Key]:f2}");
            }
        }
    }
}
