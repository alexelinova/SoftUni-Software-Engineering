using System;
using System.Linq;

namespace EvenAndOddSubstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumEvenNumbers = 0;
            int sumOddNumbers = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber % 2 == 0)
                {
                    sumEvenNumbers += currentNumber;
                }
                else
                {
                    sumOddNumbers += currentNumber;
                }
            }
            Console.WriteLine(sumEvenNumbers - sumOddNumbers);
        }
    }
}
