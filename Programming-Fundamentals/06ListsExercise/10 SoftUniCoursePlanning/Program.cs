using System;
using System.Linq;
using System.Collections.Generic;

namespace _10_SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "course start")
                {
                    break;
                }

                string[] line = input.Split(":");

                string command = line[0];
                string course = line[1];

                bool CourseExists = schedule.Contains(course);

                if (command == "Add" && !CourseExists)
                {
                    schedule.Add(course);
                }
                else if (command == "Insert" && !CourseExists)
                {
                    int index = int.Parse(line[2]);
                    schedule.Insert(index, course);
                }
                else if (command == "Remove" && CourseExists)
                {
                    schedule.Remove(course);

                    string exercise = $"Exercise:{course}";

                    if (schedule.Contains(exercise))
                    {
                        schedule.Remove(exercise);
                    }
                }
                else if (command == "Swap")
                {
                    string courseTwo = line[2];

                    int indexCourse = schedule.IndexOf(course);

                    int indexCourseTwo = schedule.IndexOf(courseTwo);

                    if (indexCourse != -1 && indexCourseTwo != -1)
                    {
                        schedule[indexCourse] = courseTwo;
                        schedule[indexCourseTwo] = course;

                        string courseExercise = $"{course}-Exercise";
                       
                        if (schedule.Contains(courseExercise))
                        {
                            int indexCourseExercise = indexCourse + 1;
                            schedule.RemoveAt(indexCourseExercise);
                            indexCourseExercise = schedule.IndexOf(course);
                            schedule.Insert(indexCourseExercise+1, courseExercise);
                        }

                        string courseExerciseTwo = $"{courseTwo}-Exercise";
                    
                        if (schedule.Contains(courseExerciseTwo))
                        {
                            int indexCourseExerciseTwo = indexCourseTwo + 1;
                            schedule.RemoveAt(indexCourseExerciseTwo);
                            indexCourseExerciseTwo = schedule.IndexOf(courseTwo);
                            schedule.Insert(indexCourseExerciseTwo+1, courseExerciseTwo);
                        }
                    }
                }
                else if (command == "Exercise")
                {
                    int index = schedule.IndexOf(course);
                    string exercise = $"{course}-Exercise";

                    bool LessonIncluded = schedule.Contains(course);
                    bool ExerciseIncluded = schedule.Contains(exercise);

                    if (LessonIncluded && !ExerciseIncluded)
                    {
                        schedule.Insert(index + 1, exercise);
                    }
                    else if(!LessonIncluded)
                    {
                        schedule.Add(course);
                        schedule.Add(exercise);
                    }
                }

            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i+1}.{schedule[i]}");
            }
        }
    }
}
