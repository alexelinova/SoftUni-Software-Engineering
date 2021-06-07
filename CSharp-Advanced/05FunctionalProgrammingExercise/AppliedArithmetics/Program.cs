using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "add")
                {
                    Calc(numbers, num => num + 1);
                }
                else if (command == "multiply")
                {
                    Calc(numbers, num => num * 2);
                }
                else if (command == "subtract")
                {
                    Calc(numbers, num => num - 1);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }

        }

        static int[] Calc(int[] sequence, Func<int, int> func)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = func(sequence[i]);
            }
            return sequence;
        }
    }
}
