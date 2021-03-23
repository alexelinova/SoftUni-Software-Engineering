using System;

namespace Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 1;
            double sumMarks = 0;
            int expelled = 0;

            while (grade <= 12)
            {
                double mark = double.Parse(Console.ReadLine());
                if (mark < 4)
                {
                    expelled++;
                    if (expelled > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break;
                    }
                }
                else
                {
                    grade++;
                    sumMarks += mark;
                }
            }
            if (expelled <= 1)
            {
                Console.WriteLine($"{name} graduated. Average grade: {sumMarks / 12:f2}");
            }
        
        }
    }
}
