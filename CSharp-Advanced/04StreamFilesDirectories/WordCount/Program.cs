using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] textOne = File.ReadAllText("words.txt").Split(new char[] { ' ', '-', ',', '!', '?', '.', '\'' }, StringSplitOptions.RemoveEmptyEntries);
            string[] textTwo = File.ReadAllText("input.txt").Split(new char[] { ' ', '-', ',', '!', '?', '.', '\'' }, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;

            Dictionary<string, int> repeatingWords = new Dictionary<string, int>();

            foreach (var word in textOne)
            {
                foreach (var text in textTwo)
                {
                    if (word.ToLower() == text.ToLower())
                    {
                        count++;

                        if (!repeatingWords.ContainsKey(word))
                        {
                            repeatingWords.Add(word, 0);
                        }
                        repeatingWords[word]++;
                    }
                }

                count = 0;
            }

            foreach (var word in repeatingWords.OrderByDescending(v => v.Value))
            {
                File.AppendAllText("output.txt", $"{word.Key} - {word.Value}{Environment.NewLine}");
            }
        }
    }
}
