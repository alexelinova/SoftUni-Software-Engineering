using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_Snowhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dwarfsByHatColour = new Dictionary<string, Dictionary<string, int>>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Once upon a time")
                {
                    break;
                }

                string[] line = input.Split(" <:> ");

                string dwarfName = line[0];

                string dwarfHatColour = line[1];

                int dwarfPhysics = int.Parse(line[2]);

                if (!dwarfsByHatColour.ContainsKey(dwarfHatColour))
                {
                    dwarfsByHatColour.Add(dwarfHatColour, new Dictionary<string, int>());
                }

                if (!dwarfsByHatColour[dwarfHatColour].ContainsKey(dwarfName))
                {
                    dwarfsByHatColour[dwarfHatColour].Add(dwarfName, dwarfPhysics);
                }

                if (dwarfsByHatColour[dwarfHatColour][dwarfName] < dwarfPhysics)
                {
                    dwarfsByHatColour[dwarfHatColour][dwarfName] = dwarfPhysics;
                }

            }

            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();


            foreach (var item in dwarfsByHatColour.OrderByDescending(s => s.Value.Count()))
            {
                foreach (var dwarfs in item.Value)
                {
                    sortedDwarfs.Add($"({item.Key}) {dwarfs.Key} <-> ", dwarfs.Value);
                }
            }

            foreach (var item in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key}{item.Value}");
            }
        }
    }
}
