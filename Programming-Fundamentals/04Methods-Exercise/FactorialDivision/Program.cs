using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {

            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double factorialNum1 = GetFactorial(num1);
            double factorialNum2 = GetFactorial(num2);

            double result = factorialNum1 / factorialNum2;

            Console.WriteLine($"{result:f2}");
        }

        private static double GetFactorial(int num1)
        {
            double result = 1;

            for (int i = 1; i <= num1; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
