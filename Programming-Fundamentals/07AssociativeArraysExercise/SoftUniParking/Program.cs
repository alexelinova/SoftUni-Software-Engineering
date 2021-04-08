using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> plateNumberByDriver = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "register")
                {
                    string username = input[1];
                    string plateNumber = input[2];

                    if (plateNumberByDriver.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plateNumberByDriver[username]}");
                    }
                    else
                    {
                        plateNumberByDriver.Add(username, plateNumber);
                        Console.WriteLine($"{username} registered {plateNumber} successfully");
                    }
                }
                else
                {
                    string username = input[1];

                    bool removed = plateNumberByDriver.Remove(username);

                    if (removed)
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var kvp in plateNumberByDriver)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
