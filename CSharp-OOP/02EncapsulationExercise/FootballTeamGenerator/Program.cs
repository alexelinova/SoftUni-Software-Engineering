using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teamsByName = new Dictionary<string, Team>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] command = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string action = command[0];

                try
                {
                    if (action == "Add")
                    {
                        string teamName = command[1];

                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        string playerName = command[2];
                        int endurance = int.Parse(command[3]);
                        int sprint = int.Parse(command[4]);
                        int dribble = int.Parse(command[5]);
                        int passing = int.Parse(command[6]);
                        int shooting = int.Parse(command[7]);

                        Team team = teamsByName[teamName];

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player);
                    }
                    else if (action == "Remove")
                    {
                        string teamName = command[1];
                        string playerName = command[2];

                        Team team = teamsByName[teamName];
                        team.RemovePlayer(playerName);
                    }
                    else if (action == "Rating")
                    {
                        string teamName = command[1];

                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        Team team = teamsByName[teamName];
                        Console.WriteLine($"{teamName} - {team.AverageRating}");

                    }
                    else if (action == "Team")
                    {
                        string teamName = command[1];

                        Team team = new Team(teamName);
                        teamsByName.Add(teamName, team);
                    }
                }
                catch (Exception ex)
                when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
