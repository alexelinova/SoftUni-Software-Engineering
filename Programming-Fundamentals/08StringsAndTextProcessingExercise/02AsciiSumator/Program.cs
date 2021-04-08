using System;

namespace _02AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            int char1 = char.Parse(Console.ReadLine());
            int char2 = char.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > char1 && input[i] < char2)
                {
                    sum += input[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
