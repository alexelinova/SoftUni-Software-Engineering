using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            int start = boundaries[0];
            int end = boundaries[1];

            Predicate<int> predicate = (num) =>
                {
                    if (command == "even")
                    {
                        return num % 2 == 0;
                    }

                    return num % 2 != 0;
                };

            List<int> sequence = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    sequence.Add(i);
                }
            }

            Console.WriteLine(string.Join (" ", sequence));
        }
    }
}
