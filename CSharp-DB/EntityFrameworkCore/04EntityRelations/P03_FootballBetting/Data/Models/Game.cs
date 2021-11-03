using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            Bets = new HashSet<Bet>();
            PlayerStatistics = new HashSet<PlayerStatistic>();
        }
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }

        [InverseProperty("HomeGames")]
        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [InverseProperty("AwayGames")]
        public virtual Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }

        public int Result { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

    }
}
