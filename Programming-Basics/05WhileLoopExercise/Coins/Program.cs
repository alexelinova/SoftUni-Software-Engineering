using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double convert = change * 100;
            int cents = (int) convert;
            int coinsCounter = 0;

            int reminder = cents % 200;
            coinsCounter += cents / 200;
            cents = reminder;

            reminder = cents % 100;
            coinsCounter += cents / 100;
            cents = reminder;

            reminder = cents % 50;
            coinsCounter += cents / 50;
            cents = reminder;

            reminder = cents % 20;
            coinsCounter += cents / 20;
            cents = reminder;

            reminder = cents % 10;
            coinsCounter += cents / 10;
            cents = reminder;

            reminder = cents % 5;
            coinsCounter += cents / 5;
            cents = reminder;

            reminder = cents % 2;
            coinsCounter += cents / 2;
            cents = reminder;

            reminder = cents % 1;
            coinsCounter += cents / 1;
            cents = reminder;

            Console.WriteLine(coinsCounter);

        }

    }
}
