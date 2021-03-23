using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {

            int sumPrime = 0;
            int sumNonPrime = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "stop")
                {
                    break;
                }
                int number = int.Parse(command);
                if (number <0)
                {
                    Console.WriteLine($"Number is negative.");
                    continue;
                }

                int count = 0; 

                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    sumPrime += number;
                }
                else
                {
                    sumNonPrime += number;
                }

            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");

        }
    }
}
