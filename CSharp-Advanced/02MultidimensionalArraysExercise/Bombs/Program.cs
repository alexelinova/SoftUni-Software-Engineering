using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int bombs = 0; bombs < coordinates.Length; bombs++)
            {
                int[] coordinate = coordinates[bombs].Split(",").Select(int.Parse).ToArray();

                int bombRow = coordinate[0];
                int bombColumn = coordinate[1];

                if (matrix[bombRow, bombColumn] <= 0)
                {
                    continue;
                }
                BombExplosion(matrix, bombRow, bombColumn);

            }

            int countLiveCells = matrix.Cast<int>().Where(x => x > 0).Count();
            int sumLiveCells = matrix.Cast<int>().Where(x => x > 0).Sum();

            Console.WriteLine($"Alive cells: { countLiveCells}");
            Console.WriteLine($"Sum: {sumLiveCells}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }

        private static void BombExplosion(int[,] matrix, int row, int col)
        {
            if (isValid(row, col + 1, matrix) && matrix[row, col + 1] > 0)
            {
                matrix[row, col + 1] -= matrix[row, col];
            }

            if (isValid(row, col - 1, matrix) && matrix[row, col - 1] > 0)
            {
                matrix[row, col - 1] -= matrix[row, col];
            }

            if (isValid(row - 1, col, matrix) && matrix[row - 1, col] > 0)
            {
                matrix[row - 1, col] -= matrix[row, col];
            }

            if (isValid(row - 1, col + 1, matrix) && matrix[row - 1, col + 1] > 0)
            {
                matrix[row - 1, col + 1] -= matrix[row, col];
            }

            if (isValid(row - 1, col - 1, matrix) && matrix[row - 1, col - 1] > 0)
            {
                matrix[row - 1, col - 1] -= matrix[row, col];
            }

            if (isValid(row + 1, col, matrix) && matrix[row + 1, col] > 0)
            {
                matrix[row + 1, col] -= matrix[row, col];
            }

            if (isValid(row + 1, col - 1, matrix) && matrix[row + 1, col - 1] > 0)
            {
                matrix[row + 1, col - 1] -= matrix[row, col];
            }

            if (isValid(row + 1, col + 1, matrix) && matrix[row + 1, col + 1] > 0)
            {
                matrix[row + 1, col + 1] -= matrix[row, col];
            }

            matrix[row, col] = 0;
        }

        private static bool isValid(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
