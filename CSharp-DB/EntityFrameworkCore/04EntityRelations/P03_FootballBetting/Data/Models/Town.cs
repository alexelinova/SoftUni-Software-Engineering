using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace P03_FootballBetting.Data.Models
{
    public class Town
    {
        public Town()
        {
            Teams = new HashSet<Team>();
        }

        public int TownId { get; set; }

        [Required]
        [MaxLength(90)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
