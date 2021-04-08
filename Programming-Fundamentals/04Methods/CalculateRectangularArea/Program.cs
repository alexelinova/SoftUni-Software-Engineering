using System;

namespace CalculateRectangularArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = RectangularArea(width, height);
            Console.WriteLine(area);
        }

        static double RectangularArea(double width, double height)
        {
            return width * height;
        }
    }
}
