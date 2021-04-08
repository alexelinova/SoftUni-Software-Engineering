using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> likedMeals = new Dictionary<string, List<string>>();

            int countOfDislikedMeals = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }

                string[] command = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string taste = command[0];
                string guestName = command[1];
                string meal = command[2];

                if (taste == "Like")
                {
                    if (!likedMeals.ContainsKey(guestName))
                    {
                        likedMeals.Add(guestName, new List<string>());
                    }

                    if (!likedMeals[guestName].Contains(meal))
                    {
                        likedMeals[guestName].Add(meal);
                    }
                }
                else
                {
                    if (!likedMeals.ContainsKey(guestName))
                    {
                        Console.WriteLine($"{guestName} is not at the party.");
                        continue;
                    }

                    if (!likedMeals[guestName].Contains(meal))
                    {
                        Console.WriteLine($"{guestName} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        likedMeals[guestName].Remove(meal);
                        Console.WriteLine($"{guestName} doesn't like the {meal}.");

                        countOfDislikedMeals++;
                    }
                }
            }

            Dictionary<string, List<string>> sorted = likedMeals
                .OrderByDescending(n => n.Value.Count)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sorted)
            {
                Console.Write($"{kvp.Key}: ");
                Console.WriteLine(string.Join(", ",kvp.Value));
            }

            Console.WriteLine($"Unliked meals: {countOfDislikedMeals}");
        }
    }
}
