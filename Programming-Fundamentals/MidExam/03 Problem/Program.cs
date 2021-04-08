using System;
using System.Linq;

namespace _03_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceTags = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int indexEntryPoint = int.Parse(Console.ReadLine());

            string typeOfItems = Console.ReadLine();

            int leftSum = 0;

            int rightSum = 0;

            if (typeOfItems == "cheap")
            {
                for (int i = indexEntryPoint + 1; i < priceTags.Length; i++)
                {
                    if (priceTags[i] < priceTags[indexEntryPoint])
                    {
                        rightSum += priceTags[i];
                    }
                }

                for (int i = 0; i < indexEntryPoint; i++)
                {
                    if (priceTags[i] < priceTags[indexEntryPoint])
                    {
                        leftSum += priceTags[i];
                    }
                }
            }
            else if (typeOfItems == "expensive")
            {
                for (int i = indexEntryPoint + 1; i < priceTags.Length; i++)
                {
                    if (priceTags[i] >= priceTags[indexEntryPoint])
                    {
                        rightSum += priceTags[i];
                    }
                }
                for (int i = 0; i < indexEntryPoint; i++)
                {
                    if (priceTags[i] >= priceTags[indexEntryPoint])
                    {
                        leftSum += priceTags[i];
                    }
                }
            }

            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else if (rightSum > leftSum)
            {
                Console.WriteLine($"Right - {rightSum}");
            }
           
        }
    }
}
