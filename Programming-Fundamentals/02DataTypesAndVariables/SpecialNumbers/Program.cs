using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int sumOfDigits = 0;
                int digits = i;

                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits = digits / 10;
                }

                if (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11 )
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
