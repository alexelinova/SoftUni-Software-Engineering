using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();
            Stack<string> expression = new Stack<string>(input);

            while (expression.Count > 1)
            {
                int firstNum = int.Parse(expression.Pop());
                string sign = expression.Pop();
                int secondNum = int.Parse(expression.Pop());

                if (sign == "+")
                {
                    expression.Push((firstNum + secondNum).ToString());
                }
                else
                {
                    expression.Push((firstNum - secondNum).ToString());
                }
            }
            Console.WriteLine(expression.Pop());
        }
    }
}
