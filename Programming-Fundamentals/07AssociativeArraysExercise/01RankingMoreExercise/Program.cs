using System;
using System.Linq;
using System.Collections.Generic;

namespace _01RankingMoreExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordByContest = new Dictionary<string, string>();

            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of contests")
                {
                    break;
                }

                string[] line = input.Split(":");

                string contest = line[0];
                string password = line[1];

                passwordByContest.Add(contest, password);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of submissions")
                {
                    break;
                }

                string[] line = input.Split("=>");

                string contest = line[0];

                string password = line[1];

                string username = line[2];

                int points = int.Parse(line[3]);

                if (!passwordByContest.ContainsKey(contest))
                {
                    continue;
                }

                if (passwordByContest.ContainsKey(contest) && passwordByContest[contest] != password)
                {
                    continue;
                }

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new Dictionary<string, int>());

                    users[username].Add(contest, points);
                }
                else
                {
                    if (users[username].ContainsKey(contest) && users[username][contest] < points)
                    {
                        users[username][contest] = points;
                    }
                    else if (!users[username].ContainsKey(contest))
                    {
                        users[username].Add(contest, points);
                    }
                }

            }

           
            string bestStudent = users
                .OrderByDescending(p => p.Value.Values.Sum())
                .First()
                .Key ;

            int bestPoints = users
                .OrderByDescending(p => p.Value.Values.Sum())
                .First()
                .Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestStudent} with total {bestPoints} points.");

            Console.WriteLine("Ranking:");

            foreach (var user in users)
            {
                Console.WriteLine(user.Key);

                foreach (var kvp in user.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
