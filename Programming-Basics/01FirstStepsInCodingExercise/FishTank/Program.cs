using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());
            int capacity = length * height * width;
            double litres = capacity*0.001;
            double litresNeeded = litres * (1 - percentage/100);
            Console.WriteLine(litresNeeded); 
        }
    }
}
