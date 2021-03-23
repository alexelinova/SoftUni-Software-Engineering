using System;

namespace GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfMoves = int.Parse(Console.ReadLine());

            int toNineCounter = 0;
            int toNineteenCounter = 0;
            int toTwentyNineCounter = 0;
            int toThirtyNineCounter = 0;
            int toFiftyCounter = 0;
            int invalidCounter = 0;
            double points = 0;

            for (int i = 1; i <= numberOfMoves; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0 || number > 50)
                {
                    invalidCounter++;
                    points = points / 2;
                }
                else if (number <= 9)
                {
                    toNineCounter++;
                    points += 0.20 * number;
                }
                else if (number <= 19)
                {
                    toNineteenCounter++;
                    points += 0.3 * number;
                }
                else if (number <= 29)
                {
                    toTwentyNineCounter++;
                    points += 0.40 * number;
                }
                else if (number <= 39)
                {
                    toThirtyNineCounter++;
                    points += 50;
                }
                else if (number <= 50)
                {
                    toFiftyCounter++;
                    points += 100;
                }
            }
            Console.WriteLine($"{points:f2}");
            Console.WriteLine($"From 0 to 9: {toNineCounter / numberOfMoves * 100:f2}% ");
            Console.WriteLine($"From 10 to 19: {toNineteenCounter / numberOfMoves * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {toTwentyNineCounter / numberOfMoves * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {toThirtyNineCounter / numberOfMoves * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {toFiftyCounter / numberOfMoves * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {invalidCounter / numberOfMoves * 100:f2}%");

        }
    }
}
