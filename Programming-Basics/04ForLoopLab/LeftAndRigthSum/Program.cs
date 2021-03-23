using System;

namespace LeftAndRigthSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int rightSum = 0;
            int leftSum = 0;

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                rightSum += number;
            }
            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                leftSum += number;
            }

            if (rightSum == leftSum)
            {
                Console.WriteLine($"Yes, sum = {rightSum}"); 
            }
            else
            {
                int difference = Math.Abs(rightSum - leftSum);
                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
