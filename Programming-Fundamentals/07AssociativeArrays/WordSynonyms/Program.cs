using System;
using System.Collections.Generic;

namespace WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < number; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (dictionary.ContainsKey(word))
                {
                    dictionary[word].Add(synonym);
                }
                else
                {
                    dictionary[word] = new List<string>();
                    dictionary[word].Add(synonym);
                }

            }

            foreach (var word in dictionary)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
