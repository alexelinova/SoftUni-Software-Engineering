using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
           string figure = Console.ReadLine();
           if (figure == "square")
            {
                double squareSide = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(squareSide * squareSide):f3}");
            }
            else if (figure == "rectangle")
            {
                double rectangleSide1 = double.Parse(Console.ReadLine());
                double rectanleSide2 = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(rectangleSide1*rectanleSide2):f3}");
            }
            else if (figure == "circle")
            {
                double circleRadius = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(Math.PI * circleRadius * circleRadius):f3}");
            }
            else if (figure == "triangle")
            {
                double lengthOfSide = double.Parse(Console.ReadLine());
                double lengthOfHeight = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(lengthOfSide * lengthOfHeight/2):f3}");
            }
        } 
    }
}
