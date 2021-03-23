using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int failedLimit = int.Parse(Console.ReadLine());
            string assignment = Console.ReadLine();
            double gradesSum = 0.00;
            int numberOfAssignments = 0;
            string lastProblem = "";
            int poorGrades = 0;
            bool isFailed = false;

            while (assignment != "Enough")
            {
                lastProblem = assignment;
                int grade = int.Parse(Console.ReadLine());
                gradesSum += grade;
                numberOfAssignments++;

                if (grade <= 4)
                {
                    poorGrades++;
                    if (poorGrades >= failedLimit)
                    {
                        isFailed = true;
                        break;
                    }
                }
                assignment = Console.ReadLine();

            }

            double averageGrade = gradesSum / numberOfAssignments;

            if (isFailed)
            {
                Console.WriteLine($"You need a break, {poorGrades} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {averageGrade:f2}");
                Console.WriteLine($"Number of problems: {numberOfAssignments}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
