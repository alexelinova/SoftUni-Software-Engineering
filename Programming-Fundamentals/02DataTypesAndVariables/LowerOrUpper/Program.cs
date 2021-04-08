using System;

namespace LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());

            if (letter == char.ToLower(letter))
            {
                Console.WriteLine("lower-case");
            }
            else
            {
                Console.WriteLine("upper-case");
            }
        }
    }
}
