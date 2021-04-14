using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Queue<string> children = new Queue<string>(names);
            int n = int.Parse(Console.ReadLine());
            int count = 0;

            while (children.Count != 1)
            {
                string child = children.Dequeue();
                count++;

                if (count == n)
                {
                    Console.WriteLine($"Removed {child}");
                    count = 0;
                    continue;
                }
                children.Enqueue(child);
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
