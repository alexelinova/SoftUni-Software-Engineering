using System;

namespace MultiplyEvenByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            number = Math.Abs(number);

            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumofOddDigits(number);
            int multipliedSums = GetMultipleOfEvenAndOdds(evenSum, oddSum);

            Console.WriteLine(multipliedSums);

        }

        private static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }

        private static int GetSumofOddDigits(int num)
        {
            int sum = 0;

            while (num != 0)
            {
                int lastDigit = num % 10;

                if (lastDigit % 2 == 1)
                {
                    sum += lastDigit;
                }
                num /= 10;
            }

            return sum;
        }

        private static int GetSumOfEvenDigits(int num)
        {
            int sum = 0;

            while (num != 0)
            {
                int lastDigit = num % 10;
                if (lastDigit % 2 == 0)
                {
                    sum += lastDigit;
                }
                num /= 10;
            }

            return sum;
        }
    }
}
