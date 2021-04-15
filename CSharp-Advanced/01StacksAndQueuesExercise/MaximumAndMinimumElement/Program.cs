using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "1")
                {
                    numbers.Push(int.Parse(input[1]));
                }
                else if (input[0] == "2" && numbers.Count > 0)
                {
                    numbers.Pop();
                }
                else if (input[0] == "3" && numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Max());
                }
                else if (input[0] == "4" && numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Min());
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
