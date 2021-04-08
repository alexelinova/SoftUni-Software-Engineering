using System;
using System.Text.RegularExpressions;

namespace _02Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(@"(\*|@)([A-Z][a-z]{2,})\1:\s\[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|$");

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                Match match = regex.Match(message);

                if (!match.Success)
                {
                    Console.WriteLine($"Valid message not found!");
                    continue;
                }
                string tag = match.Groups[2].Value;

                int groupOne = char.Parse(match.Groups[3].Value);
                int groupTwo = char.Parse(match.Groups[4].Value);
                int groupThree = char.Parse(match.Groups[5].Value);

                Console.WriteLine($"{tag}: {groupOne} {groupTwo} {groupThree}");
            }
        }
    }
}
