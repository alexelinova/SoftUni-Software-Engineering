using System;
using System.Linq;
using System.Collections.Generic;

namespace TeamWorkProjects
{
    class Team
    {
        public Team()
        {
            Members = new List<string>();
        }
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }


    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] input = Console.ReadLine().Split("-");

                string creator = input[0];

                string teamName = input[1];

                if (isExistingUser(teams, creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team existingTeam = GetTeam(teams, teamName);

                if (existingTeam != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                Team team = new Team()
                {
                    Name = teamName,
                    Creator = creator
                };

                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");

            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of assignment")
                {
                    break;
                }

                string[] input = line.Split("->");

                string user = input[0];

                string teamToJoin = input[1];

                Team existingTeam = GetTeam(teams, teamToJoin);

                if (existingTeam == null)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }

                if (isExistingMember(teams, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamToJoin}!");
                    continue;
                }

                existingTeam.Members.Add(user);

            }

            List<Team> sorted = teams
                .OrderByDescending(n => n.Members.Count)
                .ThenBy(n => n.Name)
                .ToList();

            foreach (Team team in sorted)
            {
                if (team.Members.Count == 0)
                {
                    break;
                }

                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");

                List<string> sortedMembers = team.Members
                    .OrderBy(m => m)
                    .ToList();

                foreach (var member in sortedMembers)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            List<Team> disbandedTeams = teams
                 .Where(n => n.Members.Count == 0)
                 .OrderBy(n => n.Name)
                 .ToList();

            Console.WriteLine($"Teams to disband:");

            foreach (var team in disbandedTeams)
            {
                Console.WriteLine(team.Name);
            }

        }

        private static Team GetTeam(List<Team> teams, string teamToJoin)
        {
            foreach (var team in teams)
            {

                if (team.Name == teamToJoin)
                {
                    return team;
                }
            }

            return null;
        }

        private static bool isExistingMember(List<Team> teams, string user)
        {
            foreach (Team team in teams)
            {
                if (team.Creator == user)
                {
                    return true;
                }

                foreach (string member in team.Members)
                {
                    if (member == user)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool isExistingUser(List<Team> teams, string user)
        {
            foreach (Team team in teams)
            {
                if (team.Creator == user)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
