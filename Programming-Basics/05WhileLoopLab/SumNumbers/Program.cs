using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());
            int sum = 0;

            while (true)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
                if (sum >= input)
                {
                    break;
                }
            }
            Console.WriteLine(sum);
            
        }
    }
}
