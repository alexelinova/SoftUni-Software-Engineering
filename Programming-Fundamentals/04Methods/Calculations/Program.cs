using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            if (command == "add")
            {
                AddNums(num1, num2);
            }
            else if (command == "substract")
            {
                SubstractNums(num1, num2);
            }
            else if (command == "multiply")
            {
                MultiplyNums(num1, num2);
            }
            else
            {
                DivideNums(num1, num2);
            }
        }

        static void AddNums(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void SubstractNums(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        static void MultiplyNums(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        static void DivideNums(int a, int b)
        {
            Console.WriteLine(a / b);
        }
    }
}
