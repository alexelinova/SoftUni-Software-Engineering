using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 255;

            for (int i = 0; i < n; i++)
            {
                int litres = int.Parse(Console.ReadLine());
                capacity -= litres;

                if (capacity < 0)
                {
                    Console.WriteLine("Insufficient capacity!");
                    capacity += litres;
                }
            }
            Console.WriteLine(255 - capacity);
        }
    }
}
