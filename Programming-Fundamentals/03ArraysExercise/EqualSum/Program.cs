using System;
using System.Linq;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool isFound = false;

            for (int current = 0; current < arr.Length; current++)
            {
                int rightSum = 0;

                for (int i = current + 1; i < arr.Length; i++)
                {
                    rightSum += arr[i];
                }

                int leftSum = 0;

                for (int i = current - 1; i >= 0; i--)
                {
                    leftSum += arr[i];
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(current);
                    isFound = true;
                    break;
                }

            }

            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
