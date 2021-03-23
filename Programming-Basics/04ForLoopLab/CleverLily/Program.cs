using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double machinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());
            double savings = 0;
            double presentMoney = 10;
            int toys = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savings += presentMoney;
                    presentMoney += 10;
                    savings -= 1;

                }
                else
                {
                    toys += 1;
                }
            }
            savings += toys * toyPrice;
            if (machinePrice <= savings)
            {
                Console.WriteLine($"Yes! {savings - machinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {machinePrice - savings:f2}");
            }
                
        }
    }
}
