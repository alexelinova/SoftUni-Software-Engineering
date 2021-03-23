using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            const double rosesPrices = 5.00;
            const double dahliaPrice = 3.80;
            const double tulipPrice = 2.80;
            const double narcissusPrice = 3;
            const double gladiolusPrice = 2.50;

            string typeOfFlowers = Console.ReadLine();
            int countOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double totalMoney = 0;
            if (typeOfFlowers == "Roses")
            {
                if (countOfFlowers > 80)
                {
                    totalMoney -= countOfFlowers * rosesPrices * 0.10;
                }

                totalMoney += countOfFlowers * rosesPrices;
            }
            else if (typeOfFlowers == "Dahlias")
            {
                if (countOfFlowers > 90)
                {
                    totalMoney -= countOfFlowers * dahliaPrice * 0.15;
                }
                totalMoney += countOfFlowers * dahliaPrice;
            }
            else if (typeOfFlowers == "Tulips")
            {
                if (countOfFlowers > 80)
                {
                    totalMoney -= countOfFlowers * tulipPrice * 0.15;
                }
                totalMoney += countOfFlowers * tulipPrice;
            }
            else if (typeOfFlowers == "Narcissus")
            {
                if (countOfFlowers < 120)
                {
                    totalMoney += countOfFlowers * narcissusPrice * 0.15;
                }
                totalMoney += countOfFlowers * narcissusPrice;
            }
            else if (typeOfFlowers == "Gladiolus")
            {
                if (countOfFlowers < 80)
                {
                    totalMoney += countOfFlowers * gladiolusPrice * 0.20;
                }
                totalMoney += countOfFlowers * gladiolusPrice;
            }

            if (budget >= totalMoney)
            {
                Console.WriteLine($"Hey, you have a great garden with {countOfFlowers} {typeOfFlowers} and {budget - totalMoney:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalMoney - budget:f2} leva more.");
            }
        }
    }
}
