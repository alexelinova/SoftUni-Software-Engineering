using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double p = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double weekendsSofiaVolleyball = (48 - h) * 3 / 4;
            double gamesOnHolidays = p * 2 / 3;
            double allGames = weekendsSofiaVolleyball + h + gamesOnHolidays;
            if (year == "leap")
            {
                Console.WriteLine(Math.Floor(allGames + allGames * 0.15));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Floor(allGames));
            }
        }
    }
}
