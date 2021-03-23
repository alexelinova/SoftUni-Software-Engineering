using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();

                if (destination == "End")
                {
                    break;
                }

                double budget = double.Parse(Console.ReadLine());

                double savedMoney = 0;

                while (savedMoney < budget)
                {
                    double income = double.Parse(Console.ReadLine());
                    savedMoney += income;
                }
                Console.WriteLine($"Going to {destination}!");
            }
        }
    }
}
