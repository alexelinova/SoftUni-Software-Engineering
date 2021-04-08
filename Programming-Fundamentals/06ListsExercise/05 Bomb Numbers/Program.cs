using System;
using System.Collections.Generic;
using System.Linq;


namespace _05_Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bomb = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bomb[0];
            int power = bomb[1];

            while (true)
            {
                int index = numbers.IndexOf(bombNumber);

                if (index == -1)
                {
                    break;
                }

                int startIndex = index - power;

                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                int count = 2 * power + 1;

                if (count > numbers.Count - startIndex)
                {
                    count = numbers.Count - startIndex;
                }

                numbers.RemoveRange(startIndex, count);
              
            }
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}
