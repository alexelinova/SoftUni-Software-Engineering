using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> quantityByResource = new Dictionary<string, int>();

            while (true)
            {
                string material = Console.ReadLine();

                if (material == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (quantityByResource.ContainsKey(material))
                {
                    quantityByResource[material] += quantity;
                }
                else
                {
                    quantityByResource.Add(material, quantity);
                }
            }

            foreach (var kvp in quantityByResource)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
