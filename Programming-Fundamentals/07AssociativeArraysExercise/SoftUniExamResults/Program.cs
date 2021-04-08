using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> pointsByStudent = new Dictionary<string, int>();

            Dictionary<string, int> countsByLanguage = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "exam finished")
                {
                    break;
                }

                string[] commands = input.Split("-");

                if (commands.Count() == 3)
                {
                    string username = commands[0];

                    string language = commands[1];

                    int points = int.Parse(commands[2]);

                    if (pointsByStudent.ContainsKey(username))
                    {
                       if(pointsByStudent[username] < points)
                        {
                            pointsByStudent[username] = points;
                        }
                    }
                    else
                    {
                        pointsByStudent.Add(username, points);
                    }

                    if (countsByLanguage.ContainsKey(language))
                    {
                        countsByLanguage[language]++;
                    }
                    else
                    {
                        countsByLanguage.Add(language, 1);
                    }
                }
                else
                {

                    string username = commands[0];

                    pointsByStudent.Remove(username);
                }
            }

            Dictionary<string, int> orderedPointsByStudent = pointsByStudent
                   .OrderByDescending(i => i.Value)
                   .ThenBy(i => i.Key)
                   .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");

            foreach (var kvp in orderedPointsByStudent)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Dictionary<string, int> orderedCountByLanguage = countsByLanguage
                .OrderByDescending(i => i.Value)
                .ThenBy(i => i.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Submissions:");

            foreach (var kvp in orderedCountByLanguage)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
