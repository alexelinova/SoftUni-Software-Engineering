using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            int wagonCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] input = command.Split();

                if (input[0] == "Add")
                {
                    wagons.Add(int.Parse(input[1]));
                }
                else
                {
                    int people = int.Parse(input[0]);

                    wagons = AddPeopletoWagons(wagons, people, wagonCapacity);
                }

            }
            Console.WriteLine(string.Join(" ", wagons));
        }

        private static List<int> AddPeopletoWagons(List<int> wagons, int people, int wagonCapacity)
        {
            List<int> train = new List<int>();
            for (int i = 0; i < wagons.Count; i++)
            {
                train.Add(wagons[i]);
            }
            for (int i = 0; i < train.Count; i++)
            {
                if (train[i] + people <= wagonCapacity)
                {
                    train[i] += people;
                    break;
                }
            }
            return train;
        }
    }
}
