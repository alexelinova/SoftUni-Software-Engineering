using System;
using System.Threading.Channels;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            { 
                double currentNumber = char.GetNumericValue(input[i]);
                sum += currentNumber;

            }
            Console.WriteLine(sum);

            //int number = int.Parse(Console.ReadLine());
            //int sum = 0;

            //while (number > 0)
            //{
            //    sum += number % 10;
            //    number = number / 10;
            //}
          
        }
    }
}
