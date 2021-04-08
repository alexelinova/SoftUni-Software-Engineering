using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> gradesByStudent = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                double grade = double.Parse(Console.ReadLine());

                if (!gradesByStudent.ContainsKey(name))
                {
                    gradesByStudent.Add(name, new List<double>());
                }

                gradesByStudent[name].Add(grade);
            }

            Dictionary<string, double> sortedByAverageGrade = gradesByStudent
                .Select(s => new KeyValuePair<string, double>(s.Key, s.Value.Average()))
                .Where(i => i.Value >= 4.50)
                .OrderByDescending(i => i.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var student in sortedByAverageGrade)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }
    }
}
