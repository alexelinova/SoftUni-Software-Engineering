using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor(minSalary * 0.35);
            double schlorashipForExcellence = Math.Floor(grade * 25);

            if (grade >= 5.50)
            {
                if (schlorashipForExcellence >= socialScholarship || income > minSalary)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {schlorashipForExcellence} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                }
            }
            else if (income < minSalary && grade > 4.50)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}