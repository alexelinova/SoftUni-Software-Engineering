using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int, bool> filter = (dividers, num) => dividers.All(d => num % d == 0);

            List<int> numbers = Enumerable.Range(1, n).Where(num => filter(dividers, num)).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
