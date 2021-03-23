using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //Напишете програма, която до получаване на командата "Stop", чете цели числа, въведени от потребителя, и
            //намира най-голямото измежду тях. Въвежда се по едно число на ред.
            string input = Console.ReadLine();
            int maxNumber = int.MinValue;

            while (input != "Stop")
            {
                int currentNum = int.Parse(input);
                if (currentNum > maxNumber)
                {
                    maxNumber = currentNum;
                }
                input = Console.ReadLine();

            }
            Console.WriteLine(maxNumber);
        }
    }
}
