using System;

namespace TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double lengthCm = lenght * 100;
            double widthCm = width * 100;

            double widthMinusCorridor = widthCm - 100;
            double desksinrow = Math.Floor(widthMinusCorridor / 70);

            double rows = Math.Floor(lengthCm / 120);

            double numberOfDesks = desksinrow * rows - 3;
            Console.WriteLine(numberOfDesks);
        }
    }
}
