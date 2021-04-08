using System;
using System.Text;
using System.Linq;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int multiplier = int.Parse(Console.ReadLine());

            int remainder = 0;

            StringBuilder result = new StringBuilder();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int current = number[i] - '0';

                remainder += current * multiplier;

                if (remainder > 9)
                {
                    int lastDigit = remainder % 10;

                    remainder /= 10;

                    result.Append(lastDigit);
                }
                else
                {
                    result.Append(remainder);

                    remainder = 0;
                }
            }

            if (remainder > 0)
            {
                result.Append(remainder);
            }

            if (multiplier == 0)
            {
                result.Clear();
                result.Append(0);
            }
            Console.WriteLine(string.Concat(result.ToString().Reverse()));
        }
    }
}
