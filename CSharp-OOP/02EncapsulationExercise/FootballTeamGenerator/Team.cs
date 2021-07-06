using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;

        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "A name should not be empty.");
                this.name = value;
            }
        }

        public double AverageRating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                
                return Math.Round(players.Average(p => p.AverageSkillPoints));
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }

            players.Remove(playerToRemove);
        }
    }
}
