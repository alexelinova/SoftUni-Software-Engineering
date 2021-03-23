using System;

namespace SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOff = int.Parse(Console.ReadLine());

            int timeForPlay = daysOff * 127 + (365 - daysOff) * 63;
        

            if (timeForPlay < 30000)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{(30000 -timeForPlay)/60} hours and {(30000 - timeForPlay) % 60} minutes less for play");
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{(timeForPlay - 30000)/60} hours and {(timeForPlay - 30000) % 60} minutes more for play");
            }
        }
    }
}
