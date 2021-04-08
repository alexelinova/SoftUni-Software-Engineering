using System;

namespace RefactorVolumeofPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double volume = (length * height * width) / 3;
            Console.WriteLine($"Length: Width: Height: Pyramid Volume: {volume:f2}");
        }
    }
}
