using System;

namespace PrintPartOfAsciiTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());

            for (int i = start; i <= finish; i++)
            {
                char currentChar = (char)i;
                Console.Write($"{currentChar} ");

            }
        }
    }
}
