using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public float Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:f2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                Student student = new Student
                {
                    FirstName = input[0],
                    SecondName = input[1],
                    Grade = float.Parse(input[2])
                };

                students.Add(student);
            }

            List<Student> ordered = students
                .OrderByDescending(n => n.Grade)
                .ToList();

            foreach (var student in ordered)
            {
                Console.WriteLine(student);
            }
        }
    }
}
