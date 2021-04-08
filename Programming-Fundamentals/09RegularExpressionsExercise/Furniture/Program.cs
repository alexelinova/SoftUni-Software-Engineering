using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<furniture>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)");

            double sum = 0;

            List<string> furniture = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                double price = double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);

                string name = match.Groups["furniture"].Value;

                sum += price;

                furniture.Add(name);

            }

            Console.WriteLine("Bought furniture:");

            foreach (var item in furniture)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
