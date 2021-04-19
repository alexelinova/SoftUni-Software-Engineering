using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[n, n];

            int startingRow = 0;
            int startingColumn = 0;

            for (int row = 0; row < n; row++)
            {
                char[] fieldElements = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = fieldElements[col];

                    if (field[row, col] == 's')
                    {
                        startingRow = row;
                        startingColumn = col;
                    }
                }
            }

            int currentRow = startingRow;
            int currentCol = startingColumn;
            int totalCoals = field.Cast<char>().Where(c => c == 'c').Count();
            int coalsCollected = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];

                if (currentCommand == "up" && isInsideField(field, currentRow - 1, currentCol))
                {
                    currentRow -= 1;
                }

                if (currentCommand == "right" && isInsideField(field, currentRow, currentCol + 1))
                {
                    currentCol += 1;
                }

                if (currentCommand == "left" && isInsideField(field, currentRow, currentCol - 1))
                {
                    currentCol -= 1;
                }

                if (currentCommand == "down" && isInsideField(field, currentRow + 1, currentCol))
                {
                    currentRow += 1;
                }

                if (field[currentRow, currentCol] == 'c')
                {
                    totalCoals--;
                    coalsCollected++;
                    field[currentRow, currentCol] = '*';

                    if (totalCoals <= 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }
                }

                if (field[currentRow, currentCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }
            }

            Console.WriteLine($"{totalCoals} coals left. ({currentRow}, {currentCol})");
        }

        private static bool isInsideField(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
