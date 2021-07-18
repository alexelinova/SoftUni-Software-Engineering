using System;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            const int start = 1;
            const int end = 100;
            bool hasEnteredValidNumbers = false;

            while (!hasEnteredValidNumbers)
            {
                try
                {
                    Console.WriteLine($"Please enter 10 numbers between {start} and {end}");

                    for (int i = 0; i < 10; i++)
                    {
                        ReadNumber(start, end);
                        if (i == 9)
                        {
                            hasEnteredValidNumbers = true;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void ReadNumber(int start, int end)
        {
            int n = int.Parse(Console.ReadLine());

            if (n < start || n  > end)
            {
                throw new ArgumentException($"The number should be between [{start}...{end}]");
            }
        }
    }
}
