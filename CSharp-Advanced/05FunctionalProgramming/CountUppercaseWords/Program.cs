using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(word => char.IsUpper(word[0]))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));     
        }
    }
}
