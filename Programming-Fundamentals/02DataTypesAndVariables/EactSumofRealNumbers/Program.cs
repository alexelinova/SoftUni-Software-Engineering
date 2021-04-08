using System;

namespace EactSumofRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal sum = 0M;

            for (int i = 0; i < n; i++)
            {
                decimal currentNumber = decimal.Parse(Console.ReadLine());
                sum += currentNumber;
            }
            Console.WriteLine(sum);
        }
    }
}
