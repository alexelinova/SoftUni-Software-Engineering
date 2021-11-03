﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            Bets = new HashSet<Bet>();
        }
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
