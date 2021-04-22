using System;
using System.Linq;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers[number] = 1;
                }
            }

            Dictionary<int, int> evenNum = numbers.Where(n => n.Value % 2 == 0).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in evenNum)
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
