using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary<double, int> countOfValues = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                double currentNum = numbers[i];

                if (countOfValues.ContainsKey(currentNum))
                {
                    countOfValues[currentNum]++;
                }
                else
                {
                    countOfValues[currentNum] = 1;
                }
            }

            foreach (var kvp in countOfValues)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
