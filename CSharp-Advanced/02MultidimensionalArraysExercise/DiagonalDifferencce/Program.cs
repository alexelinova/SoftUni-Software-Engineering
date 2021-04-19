using System;
using System.Linq;

namespace DiagonalDifferencce
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());

            int[,] square = new int[squareSize, squareSize];

            for (int row = 0; row < square.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < square.GetLength(1); col++)
                {
                    square[row, col] = numbers[col];
                }
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int row = 0; row < square.GetLength(0); row++)
            {
                primaryDiagonal += square[row, row];
                secondaryDiagonal += square[square.GetLength(0) -1 - row, row];
            }

            int diagonalDiff = Math.Abs(primaryDiagonal - secondaryDiagonal);
            Console.WriteLine(diagonalDiff);
        }
    }
}
