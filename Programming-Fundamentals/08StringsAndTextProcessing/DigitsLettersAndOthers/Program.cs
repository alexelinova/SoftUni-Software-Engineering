using System;
using System.Text;

namespace DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            char[] symbols = input.ToCharArray();

            StringBuilder numbers = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder symbol = new StringBuilder();

            for (int i = 0; i < symbols.Length; i++)
            {
                if (char.IsDigit(symbols[i]))
                {
                    numbers.Append(symbols[i]);
                }
                else if (char.IsLetter(symbols[i]))
                {
                    letters.Append(symbols[i]);
                }
                else
                {
                    symbol.Append(symbols[i]);
                }
            }

            Console.WriteLine(numbers);
            Console.WriteLine(letters);
            Console.WriteLine(symbol);
        }
    }
}
