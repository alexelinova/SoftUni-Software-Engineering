using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repetition = int.Parse(Console.ReadLine());

            string result = RepeatString(input, repetition);
        }

        static string RepeatString(string input, int count)
        {
            string result = "";

            for (int i = 0; i < count; i++)
            {
                Console.Write(input);
            }
            return result;
        }
    }
}
