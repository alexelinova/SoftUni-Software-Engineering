using System;
using System.Linq;

namespace _01Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Sign up")
                {
                    break;
                }

                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Case")
                {
                    string letterType = command[1];

                    if (letterType == "lower")
                    {
                        username = username.ToLower();
                    }
                    else
                    {
                        username = username.ToUpper();
                    }

                    Console.WriteLine(username);
                }
                else if (command[0] == "Reverse")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (IsValidIndex(username, startIndex) && IsValidIndex(username, endIndex))
                    {
                        string substring = username.Substring(startIndex, endIndex - startIndex + 1);

                        substring = string.Concat(substring.Reverse());

                        Console.WriteLine(substring);
                    }
                }
                else if (command[0] == "Cut")
                {
                    string substring = command[1];

                    if (username.Contains(substring))
                    {
                        int startIndex = username.IndexOf(substring);
                        username = username.Remove(startIndex, substring.Length);

                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                }

                else if (command[0] == "Replace")
                {
                    char symbol = char.Parse(command[1]);

                    username = username.Replace(symbol, '*');

                    Console.WriteLine(username);
                }

                else if (command[0] == "Check")
                {
                    char symbol = char.Parse(command[1]);

                    if (username.Contains(symbol))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {symbol}.");
                    }
                }
            }
        }

        private static bool IsValidIndex(string text, int index)
        {
            if (index >= 0 && index < text.Length)
            {
                return true;
            }

            return false;
        }
    }
}
