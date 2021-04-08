using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>
            {
                {"shards",0 },
                {"fragments", 0},
                {"motes", 0 }
            };

            SortedDictionary<string, int> junkItems = new SortedDictionary<string, int>();

            string bestMaterial = string.Empty;

            bool isRunning = true;

            while (isRunning)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (legendaryItems.ContainsKey(material))
                    {
                        legendaryItems[material] += quantity;

                        if (legendaryItems[material] >= 250)
                        {
                            bestMaterial = material;
                            legendaryItems[material] -= 250;
                            isRunning = false;
                            break;
                        }
                    }
                    else
                    {
                       if (junkItems.ContainsKey(material))
                        {
                            junkItems[material] += quantity;
                        }
                        else
                        {
                            junkItems.Add(material, quantity);
                        }
                    }

                }
            }

            if (bestMaterial == "shards")
            {
                Console.WriteLine($"Shadowmourne obtained!");
            }
            else if (bestMaterial == "fragments")
            {
                Console.WriteLine($"Valanyr obtained!");
            }
            else
            {
                Console.WriteLine($"Dragonwrath obtained!");
            }

            Dictionary<string, int> sorted = legendaryItems
                .OrderByDescending(i => i.Value)
                .ThenBy(i => i.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
