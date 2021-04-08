using System;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder cypher = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            { 
                char current = (char)(text[i] + 3);

                cypher.Append(current);
            }

            Console.WriteLine(cypher);
        }
    }
}
