using System;

namespace HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double frontBackWall = x * x * 2;
            double frontDoor = 1.2 * 2;

            double sideWalls = x * y * 2;
            double windows = 1.5 * 1.5 * 2;

            double allWalls = frontBackWall - frontDoor + sideWalls - windows;

            double greenPaint = allWalls / 3.4;

            double roofArea = x * y * 2 + (x * h / 2) * 2;
            double redPaint = roofArea / 4.3;

            Console.WriteLine($"{greenPaint:f2}");
            Console.WriteLine($"{redPaint:f2}");


        }
    }
}
