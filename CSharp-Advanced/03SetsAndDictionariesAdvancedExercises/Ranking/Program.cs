using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordsByContest = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of contests")
                {
                    break;
                }

                string[] contestData = input.Split(":");
                passwordsByContest.Add(contestData[0], contestData[1]);
            }

            SortedDictionary<string, Dictionary<string, int>> contestsByUser = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of submissions")
                {
                    break;
                }

                string[] contestData = input.Split("=>");
                string contest = contestData[0];
                string password = contestData[1];
                string username = contestData[2];
                int points = int.Parse(contestData[3]);

                if (!passwordsByContest.ContainsKey(contest) || passwordsByContest[contest] != password)
                {
                    continue;
                }

                if (!contestsByUser.ContainsKey(username))
                {
                    contestsByUser.Add(username, new Dictionary<string, int>());
                }

                if (!contestsByUser[username].ContainsKey(contest))
                {
                    contestsByUser[username][contest] = points;
                }

                else if (contestsByUser[username].ContainsKey(contest) && contestsByUser[username][contest] < points)
                {
                    contestsByUser[username][contest] = points;
                }
            }

            KeyValuePair<string, int> bestCandidate = contestsByUser
                 .Select(s => new KeyValuePair<string, int>(s.Key, s.Value.Values.Sum()))
                 .OrderByDescending(s => s.Value)
                 .First();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value} points.");
            Console.WriteLine($"Ranking:");

            foreach (var item in contestsByUser)
            {
                Console.WriteLine(item.Key);
                foreach (var contests in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contests.Key} -> {contests.Value}");
                }
            }
        }
    }
}
