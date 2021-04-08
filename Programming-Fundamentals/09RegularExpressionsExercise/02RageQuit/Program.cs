using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace _02RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            Regex regex = new Regex(@"[\D]+)([0-9]+)");
           
            MatchCollection matches = regex.Matches(input);

            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                int count = int.Parse(match.Groups[2].Value);

                string text = match.Groups[1].Value;

                for (int i = 0; i < count; i++)
                {
                    sb.Append(text);
                }
            }

            string unique = new String(sb.ToString().Distinct().ToArray());

            Console.WriteLine($"Unique symbols used: {unique.Length}");
            Console.WriteLine(sb);
        }
    }
}
