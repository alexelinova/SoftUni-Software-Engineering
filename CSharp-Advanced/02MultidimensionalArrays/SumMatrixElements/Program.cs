using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];
            int sum = 0;

            for (int r = 0; r < rows; r++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = numbers[c];
                    sum += numbers[c];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
