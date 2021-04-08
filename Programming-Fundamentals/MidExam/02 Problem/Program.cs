using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Report")
                {
                    break;
                }

                string[] command = input.Split();

                string action = command[0];

                if (action == "Blacklist")
                {
                    string name = command[1];

                    if (friendsList.Contains(name))
                    {
                        int indexName = friendsList.IndexOf(name);
                        friendsList[indexName] = "Blacklisted";

                        Console.WriteLine($"{name} was blacklisted.");
                    }

                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (action == "Error")
                {
                    int index = int.Parse(command[1]);

                    if (friendsList[index] != "Blacklisted" && friendsList[index] != "Lost")
                    {
                        string name = friendsList[index];

                        friendsList[index] = "Lost";

                        Console.WriteLine($"{name} was lost due to an error.");
                    }
                }
                else if (action == "Change")
                {
                    int index = int.Parse(command[1]);

                    string newName = command[2];

                    if (index >= 0 && index < friendsList.Count)
                    {
                        string oldName = friendsList[index];

                        friendsList[index] = newName;

                        Console.WriteLine($"{oldName} changed his username to {newName}.");
                    }
                }
            }

            List<string> blackilisted = friendsList.Where(n => n == "Blacklisted").ToList();
            List<string> lostFriends = friendsList.Where(n => n == "Lost").ToList();

            Console.WriteLine($"Blacklisted names: {blackilisted.Count}");
            Console.WriteLine($"Lost names: {lostFriends.Count}");
            Console.WriteLine(string.Join(" ", friendsList));
        }
    }
}
