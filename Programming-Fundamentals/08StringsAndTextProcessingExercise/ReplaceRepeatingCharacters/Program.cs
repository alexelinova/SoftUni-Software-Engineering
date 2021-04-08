using System;
using System.Collections.Generic;
using System.Linq;

namespace ReplaceRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<char> result = new List<char>();

            char previous = '\0';

            foreach (char symbol in text)
            {
                if (symbol != previous)
                {
                    result.Add(symbol);
                }
                previous = symbol;
            }

            Console.WriteLine(string.Concat(result));
        }
    }
}
