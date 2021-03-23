using System;

namespace FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactuses = int.Parse(Console.ReadLine());
            double priceForPresent = double.Parse(Console.ReadLine());

            double moneyEarned = m * 3.25 + z * 4 + roses * 3.5 + cactuses * 8;
            moneyEarned -= 0.05 * moneyEarned;

            if (moneyEarned >= priceForPresent)
            {
                Console.WriteLine($"She is left with {Math.Floor(moneyEarned - priceForPresent)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(priceForPresent - moneyEarned)} leva.");
            }


        }
    }
}
