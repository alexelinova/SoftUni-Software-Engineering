using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] studentData = line.Split();

                string name = studentData[0];

                string id = studentData[1];

                int age = int.Parse(studentData[2]);

                Student student = new Student()
                {
                    Name = name,
                    ID = id,
                    Age = age
                };

                students.Add(student);

            }

            List<Student> orderedStudents = students
                   .OrderBy(a => a.Age)
                   .ToList();

            foreach (Student person in orderedStudents)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}
