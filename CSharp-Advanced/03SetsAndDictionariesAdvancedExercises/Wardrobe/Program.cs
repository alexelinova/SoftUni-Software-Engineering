using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothesByColour = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] clothesinfo = Console.ReadLine().Split(" -> ");
                string colour = clothesinfo[0];
                string[] clothes = clothesinfo[1].Split(",");

                if (!clothesByColour.ContainsKey(colour))
                {
                    clothesByColour.Add(colour, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currentPiece = clothes[j];

                    if (!clothesByColour[colour].ContainsKey(currentPiece))
                    {
                        clothesByColour[colour].Add(currentPiece, 0);
                    }

                    clothesByColour[colour][currentPiece]++;
                }

            }

            string[] neededPieceOfClothes = Console.ReadLine().Split(" ");
            string neededColour = neededPieceOfClothes[0];
            string neededClothes = neededPieceOfClothes[1];

            foreach (var kvp in clothesByColour)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var clothes in kvp.Value)
                {
                    if (kvp.Key == neededColour && clothes.Key == neededClothes)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
