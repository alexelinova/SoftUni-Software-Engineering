using System;
using System.Linq;
using System.Collections.Generic;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> ordersQuantity = new Queue<int>(orders);

            int biggestOrder = ordersQuantity.Max();
            bool ordersComplete = true;

            while (ordersQuantity.Count != 0)
            {
                if (ordersQuantity.Peek() <= quantityOfFood)
                {
                    quantityOfFood -= ordersQuantity.Peek();
                    ordersQuantity.Dequeue();
                }
                else
                {
                    ordersComplete = false;
                    break;
                }
            }
            Console.WriteLine(biggestOrder);

            if (ordersComplete)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write($"Orders left: ");

                foreach (var order in ordersQuantity)
                {
                    Console.Write($"{order} ");
                }
            }
        }
    }
}
