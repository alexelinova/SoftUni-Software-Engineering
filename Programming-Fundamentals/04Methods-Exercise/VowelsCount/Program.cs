using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            input = input.ToLower();

            PrintVowelsCount(input);
        }

        private static void PrintVowelsCount(string input)
        {
            int sumOfVowels = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a'
                    || input[i] == 'o'
                    || input[i] == 'i'
                    || input[i] == 'u'
                    || input[i] == 'e')
                {
                    sumOfVowels++;
                }
            }

            Console.WriteLine(sumOfVowels); ;
        }
    }
}
