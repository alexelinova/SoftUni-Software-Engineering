using System;

namespace _1._3_LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
         
            double firstPairx1 = double.Parse(Console.ReadLine());
            double firstPairy1 = double.Parse(Console.ReadLine());
            double firstPairx2 = double.Parse(Console.ReadLine());
            double firstPairy2 = double.Parse(Console.ReadLine());
            double secondPairx1 = double.Parse(Console.ReadLine());
            double secondPairy1 = double.Parse(Console.ReadLine());
            double secondPairx2 = double.Parse(Console.ReadLine());
            double secondPairy2 = double.Parse(Console.ReadLine());

           double firstLength= GetLineLength(firstPairx1, firstPairy1, firstPairx2, firstPairy2);
           double secondLength = GetLineLength(secondPairx1, secondPairy1, secondPairx2, secondPairy2);

            if (firstLength > secondLength)
            {
                PrintClosestPoint(firstPairx1, firstPairy1, firstPairx2, firstPairy2);
            }
            else
            {
                PrintClosestPoint(secondPairx1, secondPairy1, secondPairx2, secondPairy2);
            }
        }

        private static double GetLineLength(double firstPairx1, double firstPairy1, double firstPairx2, double firstPairy2)
        {
            double length = Math.Sqrt(Math.Pow(firstPairx2 - firstPairx1, 2) + Math.Pow(firstPairy2 - firstPairy1, 2));

            return length;
        }
        private static void PrintClosestPoint(double x1, double y1, double x2, double y2)
        {
            double firstDiagonal = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));

            double secondDiagonal = Math.Sqrt(Math.Pow(Math.Abs(x2), 2) + Math.Pow(Math.Abs(y2), 2));

            if (firstDiagonal <= secondDiagonal)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }
    }
}
