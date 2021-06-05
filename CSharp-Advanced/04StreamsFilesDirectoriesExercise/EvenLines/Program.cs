using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader("text.txt");

            char[] signsToReplace = new char[] { '-', ',', '.', '!', '?' };

            int count = 0;

            string line = reader.ReadLine();

            while (line != null)
            {
                if (count % 2 == 0)
                {
                    line = ReplaceAll(signsToReplace, '@', line);
                    line = ReverseWords(line);

                    Console.WriteLine(line);
                }

                line = reader.ReadLine();
                count++;
            }
        }

        private static string ReplaceAll(char[] charToReplace, char v, string line)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var symbol in line)
            {
                if (charToReplace.Contains(symbol))
                {
                    sb.Append('@');
                }
                else
                {
                    sb.Append(symbol);
                }
            }
            return sb.ToString().TrimEnd();
        }

        static string ReverseWords(string line)
        {
            string[] words = line.Split();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                sb.Append(words[words.Length - 1 - i] + " ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
