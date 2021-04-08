using System;

namespace SumofChars
{
    class Program
    {
        static void Main(string[] args)
        {


            int n = int.Parse(Console.ReadLine());
            int sumOfAllChars = 0;

            for (int i = 0; i < n; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                sumOfAllChars += (int)currentChar;

            }
            Console.WriteLine($"The sum equals: {sumOfAllChars}");
        }
    }
}
