using System;
using System.Linq;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[] firstArr = new int[rows];
            int[] secondArr = new int[rows];
            int[] numbers = new int[2];

            for (int i = 0; i < rows; i++)
            {
                numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    firstArr[i] = numbers[0];
                    secondArr[i] = numbers[1];
                }
                else
                {
                    firstArr[i] = numbers[1];
                    secondArr[i] = numbers[0];
                }

            }
            Console.WriteLine(string.Join(" ", firstArr));
            Console.WriteLine(string.Join(" ", secondArr));
        }
    }
}
