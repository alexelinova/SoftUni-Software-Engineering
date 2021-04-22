using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> countOfLetters = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char currentLetter = text[i];

                if (!countOfLetters.ContainsKey(currentLetter))
                {
                    countOfLetters.Add(currentLetter, 0);
                }

                countOfLetters[currentLetter]++;
            }

            foreach (var kvp in countOfLetters)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
