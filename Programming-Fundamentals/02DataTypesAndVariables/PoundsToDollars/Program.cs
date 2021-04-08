using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal poundsToDollars = pounds * 1.31M;
            Console.WriteLine($"{poundsToDollars:f3}");
         
        }
    }
}
