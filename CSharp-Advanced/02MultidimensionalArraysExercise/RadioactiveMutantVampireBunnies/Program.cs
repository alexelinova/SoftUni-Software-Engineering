using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] gameField = new char[dimensions[0], dimensions[1]];

            int initialRow = 0;
            int initialCol = 0;

            for (int row = 0; row < gameField.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < gameField.GetLength(1); col++)
                {
                    gameField[row, col] = input[col];

                    if (gameField[row, col] == 'P')
                    {
                        initialRow = row;
                        initialCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();
            bool hasWon = false;
            bool hasDied = false;
            int startingRow = initialRow;
            int startingCol = initialCol;
            gameField[initialRow, initialCol] = '.';

            for (int i = 0; i < commands.Length; i++)
            {
                char action = commands[i];

                if (action == 'U' && isInsideField(gameField, startingRow - 1, startingCol))
                {
                    startingRow--;
                }
                else if (action == 'L' && isInsideField(gameField, startingRow, startingCol - 1))
                {
                    startingCol--;
                }
                else if (action == 'R' && isInsideField(gameField, startingRow, startingCol + 1))
                {
                    startingCol++;
                }
                else if (action == 'D' && isInsideField(gameField, startingRow + 1, startingCol))
                {
                    startingRow++;
                }
                else
                {
                    hasWon = true;
                }

                Queue<int> coordinates = new Queue<int>();


                for (int row = 0; row < gameField.GetLength(0); row++)
                {
                    for (int col = 0; col < gameField.GetLength(1); col++)
                    {
                        if (gameField[row, col] == 'B')
                        {
                            coordinates.Enqueue(row);
                            coordinates.Enqueue(col);
                        }
                    }
                }

                SpreadBunnies(gameField, coordinates);

                if (hasWon)
                {
                    break;
                }

                if (gameField[startingRow, startingCol] == 'B')
                {
                    hasDied = true;
                    break;
                }
            }

            PrintMatrix(gameField);

            if (hasDied)
            {
                Console.WriteLine($"dead: {startingRow} {startingCol}");
            }
            else if (hasWon)
            {
                Console.WriteLine($"won: {startingRow} {startingCol}");
            }
        }

        private static void SpreadBunnies(char[,] gameField, Queue<int> coordinates)
        {
            while (coordinates.Count > 0)
            {
                int bunnyRow = coordinates.Dequeue();
                int bunnyCol = coordinates.Dequeue();

                if (isInsideField(gameField, bunnyRow - 1, bunnyCol))
                {
                    gameField[bunnyRow - 1, bunnyCol] = 'B';
                }

                if (isInsideField(gameField, bunnyRow, bunnyCol + 1))
                {
                    gameField[bunnyRow, bunnyCol + 1] = 'B';
                }

                if (isInsideField(gameField, bunnyRow + 1, bunnyCol))
                {
                    gameField[bunnyRow + 1, bunnyCol] = 'B';
                }

                if (isInsideField(gameField, bunnyRow, bunnyCol - 1))
                {
                    gameField[bunnyRow, bunnyCol - 1] = 'B';
                }

            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool isInsideField(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
