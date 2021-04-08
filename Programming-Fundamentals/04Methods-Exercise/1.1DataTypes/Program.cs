using System;

namespace _1._1DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string input = Console.ReadLine();

            if (type == "int")
            {
                int number = int.Parse(input);
                PrintResult(number);
            }
            else if (type == "real")
            {
                double number = double.Parse(input);
                PrintResult(number);
            }
            else
            {
                PrintResult(input);
            }
        }

        private static void PrintResult(string input)
        {
            Console.WriteLine($"${input}$");
        }

        private static void PrintResult(double number)
        {
            Console.WriteLine($"{number * 1.5:f2}");
        }

        private static void PrintResult(int number)
        {
            Console.WriteLine(number * 2);
        }
    }
}
