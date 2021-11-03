using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FootballBettingContext dbcontext = new FootballBettingContext();
            dbcontext.Database.EnsureDeleted();
            dbcontext.Database.EnsureCreated();
        }
    }
}
