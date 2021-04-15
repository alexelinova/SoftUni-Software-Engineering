using System;
using System.Linq;
using System.Collections.Generic;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxOfClothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> clothes = new Stack<int>(boxOfClothes);
            int racksCapacity = int.Parse(Console.ReadLine());

            int currentRacksCapacity = racksCapacity;

            int racksCount = 1;

            while (clothes.Count != 0)
            {
                if (clothes.Peek() > currentRacksCapacity)
                {
                    racksCount++;
                    currentRacksCapacity = racksCapacity;
                }

                currentRacksCapacity -= clothes.Pop();
            }

            Console.WriteLine(racksCount);
        }
    }
}
