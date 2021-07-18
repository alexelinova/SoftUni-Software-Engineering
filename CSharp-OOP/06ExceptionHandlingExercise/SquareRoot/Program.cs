using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(Sqrt(n));
            }
            catch (SystemException ex)
            when (ex is ArgumentOutOfRangeException || ex is OverflowException)
            {

                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }

        }

        public static double Sqrt(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Math.Sqrt(value);
        }
    }
}
