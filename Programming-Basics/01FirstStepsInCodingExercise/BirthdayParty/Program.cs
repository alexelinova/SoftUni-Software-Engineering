using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double rentForHall = double.Parse(Console.ReadLine());
            double priceForCake = rentForHall * 0.2;
            double priceForDrinks = priceForCake - (priceForCake * 0.45);
            double priceForAnimator = rentForHall / 3;
            double sum = rentForHall + priceForCake + priceForDrinks + priceForAnimator;
            Console.WriteLine(sum);

        }
    }
}
