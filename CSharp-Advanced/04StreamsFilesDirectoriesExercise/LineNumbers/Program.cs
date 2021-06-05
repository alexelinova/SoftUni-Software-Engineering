using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                int numberOfLetters = CountLetters(lines[i]);
                int numberOfSigns = CountPunctuationMarks(lines[i]);

                lines[i] = $"Line {i + 1}: {lines[i]} ({numberOfLetters})({numberOfSigns})";
            }

            File.WriteAllLines("output.txt", lines);
        }

        private static int CountLetters(string text)
        {
            int count = 0;

            foreach (var symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountPunctuationMarks(string text)
        {
            int count = 0;

            foreach (var symbol in text)
            {
                if (char.IsPunctuation(symbol))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
