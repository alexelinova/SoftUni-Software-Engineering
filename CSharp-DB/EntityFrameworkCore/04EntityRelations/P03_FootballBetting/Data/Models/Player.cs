﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
        }
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        public int SquadNumber { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public bool IsInjured { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
