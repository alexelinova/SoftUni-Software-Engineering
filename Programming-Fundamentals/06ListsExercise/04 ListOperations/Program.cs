using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] command = input.Split();

                string action = command[0];
                int number;
                int index;
                int count;

                if (action == "Add")
                {
                    number = int.Parse(command[1]);
                    numbers.Add(number);
                }

                else if (action == "Insert")
                {
                    number = int.Parse(command[1]);
                    index = int.Parse(command[2]);

                    if (!IsValid(index, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(index, number);
                }

                else if (action == "Remove")
                {
                    index = int.Parse(command[1]);

                    if (!IsValid(index, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(index);
                }

                else if (action == "Shift")
                {
                    if (command[1] == "left")
                    {
                        count = int.Parse(command[2]);

                        for (int i = 0; i < count; i++)
                        {
                            int firstNumber = numbers[0];

                            numbers.RemoveAt(0);
                            numbers.Add(firstNumber);
                        }
                    }
                    else
                    {
                        count = int.Parse(command[2]);

                        for (int i = 0; i < count; i++)
                        {
                            int lastNumber = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count-1);
                            numbers.Insert(0, lastNumber);
                            
                        }
                    }
                }

            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool IsValid(int index, List<int> numbers)
        {
            return index >= 0 && index < numbers.Count;
        }
    }
}
