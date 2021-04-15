using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bulletsSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> bullets = new Stack<int>(bulletsSize);

            int[] locksSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> locks = new Queue<int>(locksSize);

            int intelligenceValue = int.Parse(Console.ReadLine());

            int countOfBullets = 0;
            int currentBarrel = gunBarrelSize;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int currentBullet = bullets.Pop();
                countOfBullets++;
                currentBarrel--;

                if (currentBullet <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currentBarrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currentBarrel = gunBarrelSize;
                }
            }

            int moneyForBullets = countOfBullets * bulletPrice;
            intelligenceValue -= moneyForBullets;

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue}");
            }
        }
    }
}
