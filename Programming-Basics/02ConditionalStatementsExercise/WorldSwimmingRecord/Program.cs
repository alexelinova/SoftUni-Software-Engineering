using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distanceMetres = double.Parse(Console.ReadLine());
            double secondsForMeter = double.Parse(Console.ReadLine());

            double time = distanceMetres * secondsForMeter;
            double delay = Math.Floor(distanceMetres / 15);
            double totalTime = time + (delay * 12.5);

            if (totalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(totalTime - record):f2} seconds slower.");
            }

        }
    }
}
