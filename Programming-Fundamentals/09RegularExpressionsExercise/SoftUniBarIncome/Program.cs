using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = 0.00;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                Regex regex = new Regex(@"%(?<customerName>[A-Z][a-z]+)%[^|$%.]*?\<(?<product>\w+)\>[^|$%.]*?\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)\$");

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["customerName"].Value;
                string product = match.Groups["product"].Value;
                double totalPrice = int.Parse(match.Groups["count"].Value) * double.Parse(match.Groups["price"].Value);

                income += totalPrice;

                Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
