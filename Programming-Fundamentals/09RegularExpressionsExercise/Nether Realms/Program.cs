using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Nether_Realms
{
    public class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Regex hpregex = new Regex(@"[^\d*+\-/.]");

            Regex numbersRegex = new Regex(@"[+\-]{0,1}\d+\.?\d*");

            Regex ampliefiersRegex = new Regex(@"[*\/]");

            List<Demon> dem = new List<Demon>();

            foreach (var demon in demons)
            {
                int health = hpregex.Matches(demon)
                    .Select(n => char.Parse(n.Value))
                    .Sum(x => x);

                double damage = numbersRegex.Matches(demon)
                    .Select(n => double.Parse(n.Value))
                    .Sum(x => x);

                MatchCollection amplifiers = ampliefiersRegex.Matches(demon);

                foreach (Match match in amplifiers)
                {
                    if (match.Value == "*")
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                dem.Add(new Demon
                {
                    Name = demon,
                    Damage = damage,
                    Health = health
                });
            }

            List<Demon> sorted = dem
                .OrderBy(n => n.Name)
                .ToList();

            foreach (Demon demon in sorted)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }
        }
    }
}
