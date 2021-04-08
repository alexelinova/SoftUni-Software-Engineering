using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_ChangeList
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

                if (input == "end")
                {
                    break;
                }

                string[] command = input.Split();

                if (command[0] == "Delete")
                {
                    int elementToRemove = int.Parse(command[1]);

                    numbers.RemoveAll(n => n == elementToRemove);
                }
                else
                {
                    
                    int elementToAdd = int.Parse(command[1]);
                    int position = int.Parse(command[2]);

                    numbers.Insert(position, elementToAdd);
                }

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
