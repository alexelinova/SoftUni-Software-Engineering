using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            double allGrades = 0;
            int twoCounter = 0;
            int threeCounter = 0;
            int fourCounter = 0;
            int fivePlusCounter = 0;

            for (int i = 1; i <= students; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                allGrades += grade;

                if (grade >= 2 && grade <= 2.99)
                {
                    twoCounter++;
                }
                else if (grade >= 3 && grade <= 3.99)
                {
                    threeCounter++;
                }
                else if (grade >= 4 && grade <= 4.99)
                {
                    fourCounter++;
                }
                else if (grade >= 5)
                {
                    fivePlusCounter++;
                }
            }

            double numberOfAllGrades = twoCounter + threeCounter + fourCounter + fivePlusCounter;

            Console.WriteLine($"Top students: {fivePlusCounter / numberOfAllGrades * 100:f2}% ");
            Console.WriteLine($"Between 4.00 and 4.99: {fourCounter / numberOfAllGrades * 100:f2}% ");
            Console.WriteLine($"Between 3.00 and 3.99: {threeCounter / numberOfAllGrades * 100:f2}%");
            Console.WriteLine($"Fail: {twoCounter / numberOfAllGrades * 100:f2}%");
            Console.WriteLine($"Average: {allGrades/numberOfAllGrades:f2}");
        }
    }
}
