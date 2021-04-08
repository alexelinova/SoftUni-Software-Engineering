using System;
using System.Text;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            int strength = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '>')
                {
                    strength += sequence[i + 1] - '0';

                    result.Append(sequence[i]);
                }
                else if (strength > 0)
                {
                    strength -= 1;
                }
                else
                {
                    result.Append(sequence[i]);
                }

            }

            Console.WriteLine(result);
        }
    }
}
