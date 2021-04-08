using System;
using System.Linq;
using System.Collections.Generic;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
       
            Dictionary<string, string> forceUsers = new Dictionary<string, string>();

            Dictionary<string, List<string>> forceSides = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains('|'))
                {
                    string[] line = input.Split(" | ");

                    string forceSide = line[0];

                    string forceUser = line[1];

                    if (!forceUsers.ContainsKey(forceUser))
                    {

                        if (!forceSides.ContainsKey(forceSide))
                        {
                            forceSides.Add(forceSide, new List<string>());
                        }

                        forceSides[forceSide].Add(forceUser);

                        forceUsers.Add(forceUser, forceSide);
                    }
                }
                else
                {
                    string[] line = input.Split(" -> ");

                    string forceUser = line[0];
                    string forceSide = line[1];

                    if (forceUsers.ContainsKey(forceUser))
                    {
                        forceSides[forceUsers[forceUser]].Remove(forceUser);

                        forceUsers.Remove(forceUser);
                    }

                    if (!forceSides.ContainsKey(forceSide))
                    {
                        forceSides.Add(forceSide, new List<string>());
                    }

                    forceSides[forceSide].Add(forceUser);
                    forceUsers.Add(forceUser, forceSide);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            Dictionary<string, List<string>> orderedForceSides = forceSides
                .Where(i => i.Value.Count > 0)
                .OrderByDescending(i => i.Value.Count)
                .ThenBy(i => i.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in orderedForceSides)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                kvp.Value.Sort();

                foreach (var forceUser in kvp.Value)
                {
                    Console.WriteLine($"! {forceUser}");
                }
            }
        }
    }
}
