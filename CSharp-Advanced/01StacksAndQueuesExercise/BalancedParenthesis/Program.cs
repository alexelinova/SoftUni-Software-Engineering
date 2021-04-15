using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Stack<char> openBrackets = new Stack<char>();

            bool isBalanced = true;

            foreach (char symbol in input)
            {
                if (symbol == '{' || symbol == '[' || symbol == '(')
                {
                    openBrackets.Push(symbol);
                }
                else if (openBrackets.Count > 0)
                {
                    if (symbol == '}' && openBrackets.Peek() == '{'
                         || symbol == ']' && openBrackets.Peek() == '['
                         || symbol == ')' && openBrackets.Peek() == '('
                         )
                    {
                        openBrackets.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
                else
                {
                    isBalanced = false;
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
