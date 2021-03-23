using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int minNumber = int.MaxValue;

            while (input != "Stop")
            {
                int currentNum = int.Parse(input);
                if (currentNum < minNumber)
                {
                    minNumber = currentNum;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(minNumber);
        }
    }
}
