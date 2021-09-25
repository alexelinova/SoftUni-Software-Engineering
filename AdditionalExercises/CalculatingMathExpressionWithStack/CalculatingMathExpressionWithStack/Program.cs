using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatingMathExpressionWithStack
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "(-15-(-6))/3+ 49*(2+5*-1)";
            double result = Evalutate(expression);
            Console.WriteLine(result);
        }

        private static double Evalutate(string expression)
        {
            string validOperators = "+-/*";

            Stack<double> numbers = new Stack<double>();
            Stack<char> operators = new Stack<char>();
            char sign = default;
            int openbracket = default;

            for (int i = 0; i < expression.Length; i++)
            {
                char @char = expression[i];

                if (@char == '(')
                {
                    operators.Push(@char);
                    openbracket++;
                }
                else if (@char == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        char operation = operators.Pop();
                        double operandOne = numbers.Pop();
                        double operandTwo = numbers.Pop();
                        double newValue = ApplyOperation(operation, operandTwo, operandOne);
                        numbers.Push(newValue);
                    }

                    operators.Pop();
                    openbracket--;
                }
                else if (validOperators.Contains(@char))
                {
                    if (operators.Count - openbracket == numbers.Count)
                    {
                        sign = @char;
                    }
                    else
                    {
                        while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(@char))
                        {
                            char operation = operators.Pop();
                            double operandOne = numbers.Pop();
                            double operandTwo = numbers.Pop();
                            double newValue = ApplyOperation(operation, operandTwo, operandOne);
                            numbers.Push(newValue);
                        }

                        operators.Push(@char);

                    }

                }
                else if (char.IsDigit(@char) || @char == '.')
                {
                    StringBuilder currentNum = new StringBuilder();

                    if (sign != default)
                    {
                        currentNum.Append(sign);
                        sign = default;
                    }

                    while (char.IsDigit(@char) || @char == '.')
                    {
                        currentNum.Append(@char);
                        i++;
                        if (i == expression.Length)
                        {
                            break;
                        }

                        @char = expression[i];
                    }

                    numbers.Push(double.Parse(currentNum.ToString()));
                    i--;
                }
            }

            while (operators.Count > 0)
            {
                char operation = operators.Pop();
                double operandOne = numbers.Pop();
                double operandTwo = numbers.Pop();
                double newValue = ApplyOperation(operation, operandTwo, operandOne);
                numbers.Push(newValue);
            }

            return numbers.Pop();
        }

        static double ApplyOperation(char operation, double operandOne, double operandTwo)
        {
            switch (operation)
            {
                case '+': return operandOne + operandTwo;
                case '-': return operandOne - operandTwo;
                case '*': return operandOne * operandTwo;
                case '/': return operandOne / operandTwo;
                default: return 0.0;
            }
        }

        static int Priority(char operation)
        {
            switch (operation)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: return 0;
            }
        }
    }
}
