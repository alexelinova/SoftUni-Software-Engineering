using System;

namespace Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int NumberTwo = int.Parse(Console.ReadLine());
            if (numberOne > NumberTwo)
            {
                Console.WriteLine(numberOne);
            }
            else
            {
                Console.WriteLine(NumberTwo);
            }
        }
    }
}
