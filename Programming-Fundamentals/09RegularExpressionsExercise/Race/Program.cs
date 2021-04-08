using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Race
{
    class Program
    {
        public static object GetNa { get; private set; }

        static void Main(string[] args)
        {

            Dictionary<string, int> raceParticipants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x, x => 0);

            Regex regexName = new Regex(@"[A-Za-z]");

            Regex regexDistance = new Regex(@"\d");

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                string extractedName = GetName(input, regexName);

                int distance = GetDistance(input, regexDistance);

                if (!raceParticipants.ContainsKey(extractedName))
                {
                    continue;
                }
                else
                {
                    raceParticipants[extractedName] += distance;
                }
            }

            List<string> sortedRace = raceParticipants
                        .OrderByDescending(x => x.Value)
                        .Select(x => x.Key)
                        .Take(3)
                        .ToList();

            Console.WriteLine($"1st place: {sortedRace[0]}");
            Console.WriteLine($"2nd place: {sortedRace[1]}");
            Console.WriteLine($"3rd place: {sortedRace[2]}");
        }

        private static int GetDistance(string text, Regex regex)
        {
            MatchCollection matches = regex.Matches(text);

            int sum = 0;

            foreach (Match match in matches)
            {
                int current = int.Parse(match.Value);

                sum += current;
            }

            return sum;
        }

        private static string GetName(string text, Regex regex)
        {
            StringBuilder name = new StringBuilder();

            MatchCollection matchName = regex.Matches(text);

            foreach (Match match in matchName)
            {
                name.Append(match.Value);
            }

            return name.ToString();
        }
    }
}
