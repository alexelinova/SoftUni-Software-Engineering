using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> sequence = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                sequence.Push(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                sequence.Pop();
            }

            if (sequence.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (sequence.Contains(x))
            {
                Console.WriteLine("true"); ;
            }
            else
            {
                Console.WriteLine(sequence.Min());
            }
        }
    }
}
