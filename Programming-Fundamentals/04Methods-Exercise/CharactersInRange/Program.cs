using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());

            char start;
            char end;

            if (a < b)
            {
                start = a;
                end = b;
            }
            else
            {
                start = b;
                end = a;
            }
            PrintBetweenChars(start, end);
        }

        private static void PrintBetweenChars(char start, char end)
        {
            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
