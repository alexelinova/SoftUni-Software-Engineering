using System;

namespace MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secondsForMeter = double.Parse(Console.ReadLine());

            double numberOfDelays = Math.Floor(distance / 50);

            double georgesScore = distance * secondsForMeter + numberOfDelays * 30;

            if (georgesScore < record)
            {
                Console.WriteLine($"Yes! The new record is {georgesScore:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {georgesScore - record:f2} seconds slower.");
            }
       
        }
    }
}
