using System;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                Console.WriteLine(isPalindrome(input));
            }
        }

        private static bool isPalindrome(string input) 
        {
            for (int i = 0; i < input.Length/2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        } 
    }
}
