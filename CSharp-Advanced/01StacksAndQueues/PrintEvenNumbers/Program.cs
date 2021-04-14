using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> evenNum = new Queue<int>(numbers);

            int count = evenNum.Count;

            for (int i = 0; i < count; i++)
            {
                int num = evenNum.Dequeue();

                if (num % 2 == 0)
                {
                    evenNum.Enqueue(num);
                }
            }
            
            Console.WriteLine(string.Join(", ", evenNum));
        }
    }
}
