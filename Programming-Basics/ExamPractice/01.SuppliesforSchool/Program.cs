using System;

namespace _01.SuppliesforSchool
{
    class Program
    {
        static void Main(string[] args)
        {

            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            double detergent = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double price = pens * 5.80 + markers * 7.20 + detergent * 1.20;
            double priceWithDiscount = price - price * discount / 100;
            Console.WriteLine($"{priceWithDiscount:f3}");

        }
    }
}
