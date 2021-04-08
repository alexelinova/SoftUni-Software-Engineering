using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();


            for (int i = 0; i < numbers.Count/2; i++)
            {
                Console.Write($"{numbers[i] + numbers[numbers.Count - 1 - i]} ");

            }
            if (numbers.Count % 2 == 1)
            {
                Console.WriteLine(numbers[numbers.Count / 2]);
            }

        }
    }
}
