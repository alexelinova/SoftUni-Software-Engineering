using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Regex regexKey = new Regex(@"[STARstar]");
            Regex regexPlanet = new Regex(@"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attack>[A|D])![^@\-!:>]*->(?<soldiers>\d+)");

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                int key = regexKey.Matches(input).Count;

                string decrypted = SubstractKey(input, key);

                Match planets = regexPlanet.Match(decrypted);

                if (!planets.Success)
                {
                    continue;
                }

                string attack = planets.Groups["attack"].Value;
                string planetName = planets.Groups["planet"].Value;

                if (attack == "A")
                {
                    attackedPlanets.Add(planetName);
                }
                else
                {
                    destroyedPlanets.Add(planetName);
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var item in attackedPlanets.OrderBy(n => n))
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var item in destroyedPlanets.OrderBy(n => n))
            {
                Console.WriteLine($"-> {item}");
            }
          
        }

        private static string SubstractKey(string text, int key)
        {
            StringBuilder stringbuilder = new StringBuilder();

            foreach (var item in text)
            {
                char current = (char)(item - key);

                stringbuilder.Append(current);
            }

            return stringbuilder.ToString();
        }
    }
}
