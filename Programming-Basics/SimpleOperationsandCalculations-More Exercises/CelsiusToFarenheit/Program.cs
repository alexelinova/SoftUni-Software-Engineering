using System;

namespace CelsiusToFarenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double Celsius = double.Parse(Console.ReadLine());

            double CelsiusToFahrenheit = Celsius * 1.8 + 32;
            Console.WriteLine($"{CelsiusToFahrenheit:f2}");

        }
    }
}
