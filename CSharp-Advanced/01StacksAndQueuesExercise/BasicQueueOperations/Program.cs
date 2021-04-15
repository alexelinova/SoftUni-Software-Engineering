using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicQueueOperations
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

            Queue<int> sequence = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                sequence.Enqueue(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                sequence.Dequeue();
            }

            if (sequence.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (sequence.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(sequence.Min());
            }
        }
    }
}
