using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            bool isBigger = true;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int element = numbers[j];

                    if (element >= currentNum)
                    {
                        isBigger = false;
                        break;
                    }
                }

                if (isBigger)
                {
                    Console.Write(currentNum + " ");
                }
                isBigger = true;
            }
        }
    }
}
