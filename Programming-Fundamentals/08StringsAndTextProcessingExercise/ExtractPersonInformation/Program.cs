using System;

namespace ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string name = StringBetweenCharacters('@', '|', input);

                string age = StringBetweenCharacters('#', '*', input);

                Console.WriteLine($"{name} is {age} years old.");

            }
        }

        private static string StringBetweenCharacters(char v1, char v2, string input)
        {
            int startIndex = input.IndexOf(v1) + 1;

            int endIndex = input.IndexOf(v2) - startIndex;

            string result = input.Substring(startIndex, endIndex);

            return result;
        }
    }
}
