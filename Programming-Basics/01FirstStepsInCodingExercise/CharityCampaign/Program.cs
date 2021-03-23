using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            //Торта - 45 лв.
            //гофрета - 5.80 лв.
            //Палачинка – 3.20 лв
            const double priceOfCake = 45;
            const double priceOfWaffle = 5.80;
            const double priceOfPancake = 3.20;
            int numberOfDays = int.Parse(Console.ReadLine());
            int cooks = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());
            //6.Калкукалации
            double priceForCakesPerCook = cakes * priceOfCake;
            double priceForWafflesPerCook = waffles * priceOfWaffle;
            double priceForPancakesPerCook = pancakes * priceOfPancake;
            double sum = (priceForWafflesPerCook+ priceForPancakesPerCook+ priceForCakesPerCook)*cooks*numberOfDays;
            double total = sum - sum / 8;
            Console.WriteLine(total);

              
           

        }
    }
}
