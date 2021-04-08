using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            double startingYield = double.Parse(Console.ReadLine());
            int days = 0;
            double sumOfYield = 0;

            while (startingYield >= 100)
            {
                days++;
                sumOfYield += startingYield;
                sumOfYield -= 26;
                startingYield -= 10;

            }

            if (sumOfYield < 26)
            {
                sumOfYield = 0;
            }
            else
            {
                sumOfYield -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(sumOfYield);

        }


    }
}

