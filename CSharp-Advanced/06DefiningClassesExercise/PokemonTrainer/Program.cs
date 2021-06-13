using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Tournament")
                {
                    break;
                }

                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHEalth = int.Parse(data[3]);

                if (!trainers.Any(t=> t.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                Trainer trainer = trainers.Find(t => t.Name == trainerName);
                trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHEalth));
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;

                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.RemoveAt(i);
                                i--;
                            }
                        }     
                    }
                }

            }

            List<Trainer> sorted = trainers.OrderByDescending(t => t.Badges).ToList();

            foreach (var trainer in sorted)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
