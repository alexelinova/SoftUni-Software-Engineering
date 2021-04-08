using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_ListManipulationAdvances
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool print = false;
            
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Contains":
                        int number = int.Parse(tokens[1]);
                        PrintIfContainsNumber(numbers, number);
                        break;

                    case "PrintEven":
                        PrintEven(numbers);
                        break;

                    case "PrintOdd":
                        PrintOdd(numbers);
                        break;

                    case "GetSum":
                        PrintSum(numbers);
                        break;

                    case "Filter":
                        string sign = tokens[1];
                        int num = int.Parse(tokens[2]);
                        Filter(numbers, sign, num);
                        break;

                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        print = true;
                        break;

                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        print = true;
                        break;

                    case "RemoveAt":
                        int indexToRemove = int.Parse(tokens[1]);
                        numbers.RemoveAt(indexToRemove);
                        print = true;
                        break;

                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        print = true;
                        break;

                }
            }

            if (print)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static void PrintIfContainsNumber(List<int> numbers, int number)
        {
            if (numbers.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
           
        }

        private static void Filter(List<int> numbers, string sign, int num)
        {
            if (sign == "<")
            {
                Console.WriteLine(string.Join(" ", numbers.FindAll(n => n < num)));
            }
            else if (sign == "<=")
            {
                Console.WriteLine(string.Join(" ", numbers.FindAll(n => n <= num)));
            }
            else if (sign == ">")
            {
                Console.WriteLine(string.Join(" ", numbers.FindAll(n => n > num)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers.FindAll(n => n >= num)));
            }
        }

        private static void PrintSum(List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
        }

        private static void PrintOdd(List<int> numbers)
        {
            foreach (int item in numbers)
            {
                if (item % 2 == 1)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }

        private static void PrintEven(List<int> numbers)
        {
            foreach (int item in numbers)
            {
                if (item % 2 == 0)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
