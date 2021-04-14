using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversedString = new Stack<char>(input.ToCharArray());

            while (reversedString.Count > 0)
            {
                Console.Write(reversedString.Pop());
            }
            Console.WriteLine();
        }
    }
}
