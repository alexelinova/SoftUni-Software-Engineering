using System;

namespace MathOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            double num2 = int.Parse(Console.ReadLine());

            double result = Calculate(num1, operation, num2);
            Console.WriteLine(result);

        }

        private static double Calculate(double num1, string operation, double num2)
        {
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = (double)num1 / num2;
                    break;
            }
            return result;
        }
    }
}
