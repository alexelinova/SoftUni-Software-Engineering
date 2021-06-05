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

            string[] words = File.ReadAllLines("words.txt");

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                wordsCount.Add(words[i].ToLower(), 0);
            }

            string[] text = File.ReadAllText("text.txt").Split(new char[] { '-', ',', '.', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower()).ToArray();

            foreach (var word in text)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
            }

            foreach (var kvp in wordsCount)
            {
                string result = $"{kvp.Key} - {kvp.Value}";

                File.AppendAllText("actualResult.txt", result + Environment.NewLine);
                
            }

            foreach (var kvp in wordsCount.OrderByDescending(v => v.Value))
            {
                string result = $"{kvp.Key} - {kvp.Value}";

                File.AppendAllText("expectedResult.txt", result + Environment.NewLine);

            }
        }
    }
}
