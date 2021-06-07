using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }

                string[] command = input.Split();

                string action = command[0];
                string filter = command[1];
                string predicateArg = command[2];

                Predicate<string> predicate = GetPredicate(filter, predicateArg);
                    
                if (action == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else if (action == "Double")
                {
                    List<string> guestsToDouble = guests.Where(name => predicate(name)).ToList();
                    guests.AddRange(guestsToDouble);
                }

            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string filter, string predicateArg)
        {
            Predicate<string> predicate = null;

            if (filter == "StartsWith")
            {
                predicate = (name) =>
                    {
                        return name.StartsWith(predicateArg);
                    };
            }
            else if (filter == "EndsWith")
            {
                predicate = (name) =>
                {
                    return name.EndsWith(predicateArg);
                };
            }
            else if (filter == "Length")
            {
                predicate = (name) =>
                {
                    return name.Length == int.Parse(predicateArg);
                };
            }

            return predicate;
        }
    }
}
