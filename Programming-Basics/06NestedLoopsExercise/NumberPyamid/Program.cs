using System;

namespace NumberPyamid
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int row = 1;
            int currentNum = 1;
            bool isEqual = false;

            while (isEqual == false)
            {
                for (int i = 1; i <= row; i++)
                {
                    Console.Write($"{ currentNum} ");
                    currentNum++;

                    if (currentNum > number)
                    {
                        isEqual = true;
                        break;
                    }

                }
                Console.WriteLine();
                row++;
            }
        }
    }
}
