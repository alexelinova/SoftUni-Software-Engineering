using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> sequence = new Stack<int>(numbers);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                input = input.ToLower();

                string[] command = input.Split();
                string action = command[0];

                if (action == "add")
                {
                    sequence.Push(int.Parse(command[1]));
                    sequence.Push(int.Parse(command[2]));
                }
                else
                {
                    int count = int.Parse(command[1]);

                    if (count < sequence.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            sequence.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {sequence.Sum()}");
        }
    }
}
