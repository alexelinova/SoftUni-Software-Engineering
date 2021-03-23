using System;

namespace PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            int p1 = int.Parse(Console.ReadLine());
            int p2 = int.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double litresFromBothPipes = p1 * h + p2 * h;

            if (v >= litresFromBothPipes)
            {
                Console.WriteLine($"The pool is {litresFromBothPipes / v * 100}% full. Pipe 1: {(p1 * h) / litresFromBothPipes * 100:f2}%. Pipe 2: {(p2 * h) / litresFromBothPipes * 100:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {h} hours the pool overflows with {litresFromBothPipes - v} liters.");
            }

        }
    }
}
