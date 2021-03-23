using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryCount = int.Parse(Console.ReadLine());

            int gradeCount = 0;
            double sumAllGrades = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Finish")
                {
                    break;
                }

                double sumOfGrades = 0;

                for (int i = 0; i < juryCount; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumOfGrades += grade;
                    gradeCount++;
                    sumAllGrades += grade;
                }
                double average = sumOfGrades / juryCount;
                Console.WriteLine($"{input} - {average:f2}.");

            }

            double finalAverage = sumAllGrades / gradeCount;
            Console.WriteLine($"Student's final assessment is {finalAverage:f2}.");
        }
    }
}
