
using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string operators = (Console.ReadLine());
            double sum = 0;

            switch (operators)
            {
                case "+":
                    sum = n1 + n2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {operators} {n2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {operators} {n2} = {sum} - odd");
                    }
                    break;
                case "-":
                    sum = n1 - n2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {operators} {n2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {operators} {n2} = {sum} - odd");
                    }
                    break;
                case "*":
                    sum = n1 * n2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {operators} {n2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {operators} {n2} = {sum} - odd");
                    }
                    break;
                case "/":
                    if (n2 != 0)
                    {
                        sum = n1 / n2;
                        Console.WriteLine($"{n1} {operators} {n2} = {sum:f2}");
                    }
                    else 
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    }
                    break;
                case "%":
                    if (n2 != 0)
                    {
                        Console.WriteLine($"{n1} {operators} {n2} = {n1 % n2}");
                    }
                    else if (true)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    }
                    break;
                    
            }
        }   
    }
}
