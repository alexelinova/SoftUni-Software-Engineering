using System;
using System.Linq;
using System.Collections.Generic;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] bottlesWithWater = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int wastedWater = 0;

            Stack<int> bottles = new Stack<int>(bottlesWithWater);
            Queue<int> cups = new Queue<int>(cupsCapacity);

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int currentBottle = bottles.Pop();
                int currentCup = cups.Peek();

                if (currentBottle >= currentCup)
                {
                    cups.Dequeue();
                    wastedWater += currentBottle - currentCup;
                }
                else
                {
                    currentCup -= currentBottle;

                    while (currentCup > 0)
                    {
                        currentBottle = bottles.Pop();

                        if (currentBottle > currentCup)
                        {
                            wastedWater += currentBottle - currentCup;
                            currentCup -= currentBottle;
                        }
                        else
                        {
                            currentCup -= currentBottle;
                        }
                    }
                    cups.Dequeue();
                }
            }
            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
