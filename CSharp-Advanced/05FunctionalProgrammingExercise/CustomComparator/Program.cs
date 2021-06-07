using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Comparison<int> comparator = (a, b) =>
            {
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }
                else if (b % 2 == 0 && a % 2 != 0)
                {
                    return 1;
                }
                return a.CompareTo(b);
            };

            Array.Sort<int>(numbers, comparator);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
