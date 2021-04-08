using System;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isSpecialNumber = false;

            for (int i = 1; i <= number; i++)
            {
                int currentNumber = i;
                int sum = 0;
                while (currentNumber > 0)
                {
                    sum += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }

                isSpecialNumber = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", i, isSpecialNumber);

            }

        }

    }
}
