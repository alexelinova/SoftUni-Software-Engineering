using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double amountBananas = double.Parse(Console.ReadLine());
            double amountOranges = double.Parse(Console.ReadLine());
            double amountRaspberries = double.Parse(Console.ReadLine());
            double amountStrawberries = double.Parse(Console.ReadLine());
            double raspberriesPrice = strawberriesPrice / 2;
            double orangesPrice = raspberriesPrice - raspberriesPrice * 0.4;
            double bananasPrice = raspberriesPrice - 0.8 * raspberriesPrice;
            double neededMoney = raspberriesPrice * amountRaspberries + orangesPrice * amountOranges + bananasPrice * amountBananas + strawberriesPrice * amountStrawberries;
            Console.WriteLine($"{neededMoney:f2}");
        }
    }
}
