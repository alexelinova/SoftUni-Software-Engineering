using System;

namespace AddAndSubstract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum = GetSum(num1, num2);
            int result = GetSubstraction(sum, num3);

            Console.WriteLine(result);
        }

        private static int GetSubstraction(int sum, int num3)
        {
            return sum - num3;
        }

        private static int GetSum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
