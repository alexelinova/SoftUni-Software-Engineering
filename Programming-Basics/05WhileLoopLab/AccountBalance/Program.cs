using System;
using System.Diagnostics.CodeAnalysis;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double balance = 0.00;
            while (input != "NoMoreMoney")
            {
                double amount = double.Parse(input);
                if (amount < 0 )
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Increase: {amount:f2}");
                    balance += amount;
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}
