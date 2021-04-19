using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] action = input.Split();

                if (!input.StartsWith("swap") || action.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int rowOne = int.Parse(action[1]);
                int colOne = int.Parse(action[2]);
                int rowTwo = int.Parse(action[3]);
                int colTwo = int.Parse(action[4]);

                if (!isValidIndex(rowOne, matrix.GetLength(0)) || !isValidIndex(rowTwo, matrix.GetLength(0))
                    || !isValidIndex(colOne, matrix.GetLength(1)) || !isValidIndex(colTwo, matrix.GetLength(1)))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string firstValue = matrix[rowOne, colOne];
                matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
                matrix[rowTwo, colTwo] = firstValue;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static bool isValidIndex(int index, int length)
        {
            if (index < 0 || index >= length)
            {
                return false;
            }
            return true;
        }
    }
}
