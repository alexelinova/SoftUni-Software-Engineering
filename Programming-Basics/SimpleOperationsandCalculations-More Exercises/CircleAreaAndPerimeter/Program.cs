using System;

namespace CircleAreaAndPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double circleArea = Math.PI * Math.Pow(r, 2);

            double perimeter = 2 * Math.PI * r;
            Console.WriteLine($"{circleArea:f2}");
            Console.WriteLine($"{perimeter:f2}");
        }
    }
}
