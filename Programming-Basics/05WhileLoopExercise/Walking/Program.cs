using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int walkingTarget = 10000;
            string stepsPerDay = Console.ReadLine();
            int sumSteps = 0;

            while (stepsPerDay != "Going home")

            {
                int steps = int.Parse(stepsPerDay);
                sumSteps += steps;

                if (sumSteps >= walkingTarget)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{sumSteps - walkingTarget} steps over the goal!");
                    break;
                }
                stepsPerDay = Console.ReadLine();
            }

            if (stepsPerDay == "Going home")
            {
                int steps = int.Parse(Console.ReadLine());
                sumSteps += steps;
                if (sumSteps < walkingTarget)
                {
                    Console.WriteLine($"{walkingTarget - sumSteps} more steps to reach goal.");
                }
                else
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{sumSteps - walkingTarget} steps over the goal!");
                }
                 
            }
        }
    }
}
