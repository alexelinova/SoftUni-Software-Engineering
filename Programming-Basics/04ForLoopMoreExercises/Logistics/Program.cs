using System;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int load = int.Parse(Console.ReadLine());

            int tonsBus = 0;
            int tonsTruck = 0;
            int tonsTrain = 0;


            for (int i = 1; i <= load ; i++)
            {
                int tons = int.Parse(Console.ReadLine());

                if (tons <= 3)
                {
                    tonsBus += tons;
                }
                else if (tons <= 11)
                {
                    tonsTruck += tons;
                }
                else if (tons >= 12)
                {
                    tonsTrain += tons;
                }
            }

            double allTons = tonsTrain + tonsTruck + tonsBus;
            int priceforAllTons = tonsTrain * 120 + tonsTruck * 175 + tonsBus * 200;
            double averagePrice = priceforAllTons / allTons;

            Console.WriteLine($"{averagePrice:f2}");
            Console.WriteLine($"{tonsBus / allTons * 100:f2}%");
            Console.WriteLine($"{tonsTruck / allTons * 100:f2}%");
            Console.WriteLine($"{tonsTrain / allTons * 100:f2}%");

        }
    }
}
