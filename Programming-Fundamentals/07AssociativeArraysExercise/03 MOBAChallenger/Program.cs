using System;
using System.Collections.Generic;
using System.Linq;


namespace _03_MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playersPool = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {

                string input = Console.ReadLine();

                if (input == "Season end")
                {
                    break;
                }

                if (input.Contains("->"))
                {
                    string[] line = input.Split(" -> ");

                    string playerName = line[0];

                    string playerPosition = line[1];

                    int skill = int.Parse(line[2]);

                    if (!playersPool.ContainsKey(playerName))
                    {
                        playersPool.Add(playerName, new Dictionary<string, int>());
                    }

                    if (!playersPool[playerName].ContainsKey(playerPosition))
                    {
                        playersPool[playerName].Add(playerPosition, skill);
                    }

                    if (playersPool[playerName][playerPosition] < skill)
                    {
                        playersPool[playerName][playerPosition] = skill;
                    }
   
                }
                else
                {
                    string[] line = input.Split(" vs ");

                    string playerOne = line[0];

                    string playerTwo = line[1];

                    if (!playersPool.ContainsKey(playerOne) || !playersPool.ContainsKey(playerTwo))
                    {
                        continue;
                    }

                    bool haveCommonPosition = false;

                    foreach (var position in playersPool[playerOne].Keys)
                    {
                        if (playersPool[playerTwo].ContainsKey(position))
                        {
                            haveCommonPosition = true;
                            break;
                        }
                    }

                    if (haveCommonPosition)
                    {
                        int playerOneSkills = playersPool[playerOne].Values.Sum();

                        int playerTwoSkills = playersPool[playerTwo].Values.Sum();

                        if (playerOneSkills > playerTwoSkills)
                        {
                            playersPool.Remove(playerTwo);
                        }

                        if (playerOneSkills < playerTwoSkills)
                        {
                            playersPool.Remove(playerOne);
                        }

                    }

                }
            }

            Dictionary<string, Dictionary<string, int>> sorted = playersPool
                .OrderByDescending(s => s.Value.Values.Sum())
                .ThenBy(s => s.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");

                foreach (var position in kvp.Value.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}
