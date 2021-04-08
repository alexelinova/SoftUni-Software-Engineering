using System;
using System.Linq;
using System.Collections.Generic;

namespace _03_MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            List<int> second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            int length = Math.Max(first.Count, second.Count);

            for (int i = 0; i < length; i++)
            {
                if (i < first.Count)
                {
                    result.Add(first[i]);
                }

                if (i < second.Count)
                {
                    result.Add(second[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
