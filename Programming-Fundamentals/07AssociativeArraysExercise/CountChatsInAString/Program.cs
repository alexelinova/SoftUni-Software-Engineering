using System;
using System.Collections.Generic;

namespace CountChatsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> countByChar = new Dictionary<char, int>();

            foreach (char letter in input)
            {
                if (letter == ' ')
                {
                    continue;
                }

                if (countByChar.ContainsKey(letter))
                {
                    countByChar[letter]++;
                }
                else
                {
                    countByChar.Add(letter, 1);
                }
            }

            foreach (var item in countByChar)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
