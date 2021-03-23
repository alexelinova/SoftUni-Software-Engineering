using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double volume = width * height * length * 0.001;

            double percentageTotal = percentage / 100;

            double volumeTotal = volume * percentageTotal;

            Console.WriteLine(volume - volumeTotal);
        }
    }
}
