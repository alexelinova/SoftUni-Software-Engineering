using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _03PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<char, int> characters = new Dictionary<char, int>();

            string[] input = Console.ReadLine().Split("|");

            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];

            string patternCapLetters = @"(#|\$|\*|&)(?<letters>[A-Z]+)\1";

            string patternLength = @"(\d{2}):(\d{2})";


            string capLetters = Regex.Match(firstPart, patternCapLetters).Groups["letters"].Value;

            characters = capLetters
                .ToCharArray()
                .ToDictionary(x => x, x => 0);


            MatchCollection matchLength = Regex.Matches(secondPart, patternLength);

            foreach (var letter in capLetters)
            {
                foreach (Match pair in matchLength)
                {
                    if (letter == int.Parse(pair.Groups[1].Value))
                    {
                        int count = GetCount(pair.Groups[2].Value);

                        characters[letter] = count;
                    }
                }
            }

            string[] words = thirdPart.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var kvp in characters)
            {
                foreach (var word in words)
                {
                    if (kvp.Key == word[0] && kvp.Value == word.Length - 1)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
            
        }

        private static int GetCount(string value)
        {
            int count = int.Parse(value);

            if (count / 10 < 0)
            {
                count = count % 10;
            }

            return count;
        }
    }
}
