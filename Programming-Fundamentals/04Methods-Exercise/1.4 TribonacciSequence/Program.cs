using System;

namespace _1._4_TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintTribonacciSequence(num);
        }

        private static void PrintTribonacciSequence(int num)
        {
            if (num == 1)
            {
                Console.WriteLine(num);
                return;
            }
            else if (num == 2)
            {
                Console.WriteLine("1 1");
                return;
            }
            int[] sequence = new int[num];
            sequence[0] = sequence[1] = 1;
            sequence[2] = 2;

            for (int i = 3; i < sequence.Length; i++)
            {
                sequence[i] = sequence[i - 1] + sequence[i - 2] + sequence[i - 3];
            }

            foreach (var numbers in sequence)
            {
                Console.Write($"{numbers} ");
            }
        }

    }
}
