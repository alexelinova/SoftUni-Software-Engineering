﻿using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNum = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
                if (number > maxNum)
                {
                    maxNum = number;
                }

            }

            int sumWithoutMaxNumber = sum - maxNum;

            if (sumWithoutMaxNumber == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(maxNum - sumWithoutMaxNumber)}");
            }
        }
    }
}
