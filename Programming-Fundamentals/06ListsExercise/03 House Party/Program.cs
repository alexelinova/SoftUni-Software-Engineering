using System;
using System.Collections.Generic;

namespace _03_House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string input = Console.ReadLine();
                string[] command = input.Split();
                string name = command[0];

                if (command[2] == "not")
                {
                    if (!names.Remove(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else
                {
                    if (names.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!"); 
                    }
                    else
                    {
                        names.Add(name);
                    }
                    
                    
                }
            }

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
