using System;
using System.Linq;
using System.Collections.Generic;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> filters = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Print")
                {
                    break;
                }

                string[] command = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                string filterInfo = command[1] + " " + command[2];

                if (action == "Add filter")
                {
                    filters.Add(filterInfo);
                }
                else
                {
                    filters.Remove(filterInfo);
                }
            }

            foreach (var filter in filters)
            {
                string[] filterInfo = filter.Split();
                string filterType = filterInfo[0];
                string filterParam = filterInfo[filterInfo.Length - 1];

                Predicate<string> predicate = GetPredicate(filterType, filterParam);

                guests.RemoveAll(predicate);
            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(" ", guests));
            }
        }
            

        private static Predicate<string> GetPredicate(string filterType, string filterParam)
        {
            Predicate<string> predicate = null;

            if (filterType == "Starts")
            {
                predicate = (name) =>
                {
                    return name.StartsWith(filterParam);
                };
            }
            else if (filterType == "Ends")
            {
                predicate = (name) =>
                {
                    return name.EndsWith(filterParam);
                };
            }
            else if (filterType == "Length")
            {
                predicate = (name) =>
                {
                    return name.Length == int.Parse(filterParam);
                };
            }
            else if (filterType == "Contains")
            {
                predicate = (name) =>
                {
                    return name.Contains(filterParam);
                };
            }
            return predicate;
        }
    }
}
