using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int bestLeftsomeIndex = 0;
            int bestSumOnes = 0;
            int bestCounterOnes = 0;
            int bestSample = 1;
            int[] bestArray = new int[length];

            int sample = 0;


            while (input != "Clone them!")
            {
                int[] arr = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int counterOnes = 1;
                int currentIndex = input.Length;
                int sum = 0;

                sample++;

                for (int i = 0; i < arr.Length; i++)
                {

                    int currentNumber = arr[i];

                    if (currentNumber == 0)
                    {
                        continue;

                    }

                    for (int j = i + 1; j < length; j++)
                    {
                        if (currentNumber == arr[j])
                        {
                            counterOnes++;
                            currentIndex = i;
                        }
                        else
                        {
                            break;
                        }
                    }
                    sum += arr[i];

                    if (counterOnes > bestCounterOnes)
                    {
                        bestCounterOnes = counterOnes;
                        bestLeftsomeIndex = currentIndex;
                        bestSample = sample;
                        bestSumOnes = sum;
                        bestArray = arr;
                    }
                    else if (counterOnes == bestCounterOnes)
                    {
                        if (currentIndex < bestLeftsomeIndex)
                        {
                            bestLeftsomeIndex = currentIndex;
                            bestCounterOnes = counterOnes;
                            bestSample = sample;
                            bestSumOnes = sum;
                            bestArray = arr;

                        }
                        else if (currentIndex == bestLeftsomeIndex && sum > bestSumOnes)
                        {

                            bestLeftsomeIndex = currentIndex;
                            bestCounterOnes = counterOnes;
                            bestSample = sample;
                            bestSumOnes = sum;
                            bestArray = arr;
                        }

                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSumOnes}.");
            Console.WriteLine(string.Join(" ", bestArray));
        }
    }
}
