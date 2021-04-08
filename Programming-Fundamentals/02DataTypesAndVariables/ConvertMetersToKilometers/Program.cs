using System;

namespace ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            float kilometers = meters * 0.001F;
            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
