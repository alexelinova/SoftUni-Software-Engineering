using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> courses = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "no more time")
                {
                    break;
                }

                string[] line = input.Split(" -> ");

                string username = line[0];
                string contest = line[1];
                int points = int.Parse(line[2]);

                if (!courses.ContainsKey(contest))
                {
                    courses.Add(contest, new Dictionary<string, int>());

                }

                if (!courses[contest].ContainsKey(username))
                {
                    courses[contest].Add(username, points);
                }

                if (courses[contest][username] < points)
                {
                    courses[contest][username] = points;
                }


                if (!students.ContainsKey(username))
                {
                    students.Add(username, new Dictionary<string, int>());
                }

                if (!students[username].ContainsKey(contest))
                {
                    students[username].Add(contest, points);
                }

                if (students[username][contest] < points)
                {
                    students[username][contest] = points;
                }
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count} participants");

                int i = 1;

                foreach (var kvp in course.Value.OrderByDescending(p => p.Value).ThenBy( p => p.Key))
                {
                    Console.WriteLine($"{i++}. {kvp.Key} <::> {kvp.Value}");

                }

            }
            Console.WriteLine("Individual standings:");

            Dictionary<string, int> pointsByStudent = students
                 .Select(s => new KeyValuePair<string, int>(s.Key, s.Value.Values.Sum()))
                 .OrderByDescending(s => s.Value)
                 .ThenBy(s => s.Key)
                 .ToDictionary(s => s.Key, s => s.Value);

            int counter = 1;

            foreach (var student in pointsByStudent)
            {
                Console.WriteLine($"{counter++}. {student.Key} -> {student.Value}");
            }
        }
    }
}
