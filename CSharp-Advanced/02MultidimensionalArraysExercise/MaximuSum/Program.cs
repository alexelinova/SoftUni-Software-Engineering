using System;
using System.Linq;

namespace MaximuSum
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 3;

            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum = int.MinValue;
            int startingRow = 0;
            int startingColumn = 0;

            for (int row = 0; row < matrix.GetLength(0) - n + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - n + 1; col++)
                {
                    int currentSum = 0;

                    for (int currentRow = row; currentRow < row + n; currentRow++)
                    {
                        for (int currentcol = col; currentcol < col + n; currentcol++)
                        {
                            currentSum += matrix[currentRow, currentcol];

                            if (currentSum > sum)
                            {
                                sum = currentSum;
                                startingColumn = col;
                                startingRow = row;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int row = startingRow; row < startingRow + n; row++)
            {
                for (int col = startingColumn; col < startingColumn + n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
