using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _04SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            List<string> goodChildren = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string decrypted = Decrypted(input, key);


                Regex regex = new Regex(@"@(?<name>[A-Za-z]+)[^@\-!:>]+!(?<behaviour>(G|N))!");

                Match match = regex.Match(decrypted);

                if (!match.Success)
                {
                    continue;
                }

                string childName = match.Groups["name"].Value;

                char behaviour = char.Parse(match.Groups["behaviour"].Value);

                if (behaviour == 'G')
                {
                    goodChildren.Add(childName);
                }

            }

            foreach (var child in goodChildren)
            {
                Console.WriteLine(child);
            }

        }

        private static string Decrypted(string text, int number)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var letter in text)
            {
                char current = letter;

                current = (char)(current - number);

                sb.Append(current);
            }

            return sb.ToString();
        }
    }
}
