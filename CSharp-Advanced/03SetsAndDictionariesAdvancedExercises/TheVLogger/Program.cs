using System;
using System.Linq;
using System.Collections.Generic;

namespace TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] vloggerData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vlogger = vloggerData[0];
                string action = vloggerData[1];

                if (action == "joined" && !vloggers.ContainsKey(vlogger))
                {
                    vloggers.Add(vlogger, new Dictionary<string, SortedSet<string>>());
                    vloggers[vlogger].Add("following", new SortedSet<string>());
                    vloggers[vlogger].Add("followers", new SortedSet<string>());
                }

                else if (action == "followed")
                {
                    string secondVlogger = vloggerData[2];

                    if (vloggers.ContainsKey(vlogger) && vloggers.ContainsKey(secondVlogger) && vlogger != secondVlogger)
                    {
                        vloggers[secondVlogger]["followers"].Add(vlogger);
                        vloggers[vlogger]["following"].Add(secondVlogger);
                    }
                }
            }

            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedVloggers = vloggers
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"The V-Logger has a total of {sortedVloggers.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var kvp in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value["followers"].Count} followers, {kvp.Value["following"].Count} following");
                if (counter == 1)
                {
                    foreach (var follower in kvp.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;
            }
        }
    }
}
