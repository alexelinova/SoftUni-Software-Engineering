using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(Parse)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }

        static int Parse(string str)
        {
            int number = 0;

            foreach (var ch in str)
            {
                number *= 10;
                number += ch - '0';
            }
            return number;
        }
    }
}
