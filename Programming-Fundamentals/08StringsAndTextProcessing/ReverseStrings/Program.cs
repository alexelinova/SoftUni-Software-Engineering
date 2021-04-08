using System;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                string reversed = string.Empty;

                if (input == "end")
                {
                    break;
                }

                for (int i = input.Length -1; i >= 0; i--)
                {
                    reversed += input[i];
                }

                Console.WriteLine($"{input} = {reversed}");
            }
        }
    }
}
