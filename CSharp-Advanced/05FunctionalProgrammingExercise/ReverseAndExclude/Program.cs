using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> filter = number => number % divisor != 0;

            Console.WriteLine(string.Join(" ", numbers.Where(filter)));

       
        }
    }
}
