using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());
            double climbers = 0;
            int musalaClibers = 0;
            int monblanClimbers = 0;
            int kilimandjaroClimbers = 0;
            int k2Climbers = 0;
            int everestClimbers = 0;

            for (int i = 1; i <= numberOfGroups; i++)
            {
                int numberOfPeople = int.Parse(Console.ReadLine());
                climbers += numberOfPeople;

                if (numberOfPeople <= 5)
                {
                    musalaClibers += numberOfPeople;
                }
                else if (numberOfPeople > 5 && numberOfPeople <= 12)
                {
                    monblanClimbers += numberOfPeople;
                }
                else if (numberOfPeople > 12 && numberOfPeople <= 25)
                {
                    kilimandjaroClimbers += numberOfPeople;
                }
                else if (numberOfPeople > 25 && numberOfPeople <= 40)
                {
                    k2Climbers += numberOfPeople;

                }
                else if (numberOfPeople >= 41)
                {
                    everestClimbers += numberOfPeople;
                }
            }
            Console.WriteLine($"{musalaClibers / climbers * 100:f2}%");
            Console.WriteLine($"{monblanClimbers / climbers * 100:f2}%");
            Console.WriteLine($"{kilimandjaroClimbers / climbers * 100:f2}%");
            Console.WriteLine($"{k2Climbers / climbers * 100:f2}%");
            Console.WriteLine($"{everestClimbers / climbers * 100:f2}%");


        }
    }
}
