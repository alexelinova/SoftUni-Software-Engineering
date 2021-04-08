using System;
using System.Collections.Generic;

namespace _04_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] information = input.Split();

                string firstName = information[0];
                string lastName = information[1];
                int age = int.Parse(information[2]);
                string hometown = information[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Hometown = hometown;
                student.Age = age;

                students.Add(student);
            }

            string city = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.Hometown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }
}
