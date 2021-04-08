using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] line = input.Split(" : ");

                string course = line[0];

                string student = line[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }

                courses[course].Add(student);
                
            }

            Dictionary<string, List<string>> sortedCourses = courses
                .OrderByDescending(i => i.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var course in sortedCourses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                course.Value.Sort();

                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
