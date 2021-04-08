using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_PokermonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            while (sequence.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int capturedPokemon = 0;

                if (index < 0)
                {
                    capturedPokemon = sequence[0];
                    sequence[0] = sequence[sequence.Count - 1];
                    RecalculateDistance(sequence, capturedPokemon);
                }
                else if (index >= sequence.Count)
                {
                    capturedPokemon = sequence[sequence.Count - 1];
                    sequence[sequence.Count - 1] = sequence[0];
                    RecalculateDistance(sequence, capturedPokemon);
                }
                else
                {
                    capturedPokemon = sequence[index];
                    sequence.RemoveAt(index);
                    RecalculateDistance(sequence, capturedPokemon);
                }

                sum += capturedPokemon;

            }

            Console.WriteLine(sum);
        }

        private static void RecalculateDistance(List<int> sequence, int capturedPokemon)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] <= capturedPokemon)
                {
                    sequence[i] += capturedPokemon;
                }
                else
                {
                    sequence[i] -= capturedPokemon;
                }
            }
        }
    }
}


