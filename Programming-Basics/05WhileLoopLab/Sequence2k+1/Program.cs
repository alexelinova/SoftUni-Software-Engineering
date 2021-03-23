using System;

namespace Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = 1;

            while (number <= input)
            {
                Console.WriteLine(number);
                number = number * 2 + 1;
            }
            
        }
    }
}
