using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char current = expression[i];

                if (current == '(')
                {
                    indexes.Push(i);
                }
                else if (current == ')')
                {
                    int startIndex = indexes.Pop();
                    int endIndex = i;

                    string result = expression.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(result);
                }
                
            }
        }
    }
}
