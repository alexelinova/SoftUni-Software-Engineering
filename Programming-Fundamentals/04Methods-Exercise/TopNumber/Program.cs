using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (Divisible(i) && HoldsOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool HoldsOddDigit(int i)
        {
            while (i != 0)
            {
                int lastDigit = i % 10;

                if (lastDigit % 2 == 1)
                {
                    return true;
                }

                i /= 10;
            }
            return false;
        }

        private static bool Divisible(int i)
        {
            int sum = 0;

            while ( i != 0)
            {
                int lastDigit = i % 10;
                sum += lastDigit;
                i /= 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
