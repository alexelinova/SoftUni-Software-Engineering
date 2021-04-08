using System;

namespace _01_RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Random rnd = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                int index = rnd.Next(0, input.Length);

                string temp = input[i];

                input[i] = input[index];

                input[index] = temp;
            }

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
