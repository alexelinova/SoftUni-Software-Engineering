using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            int rowNum = -1;
            int colNum = -1;
            bool matchFound = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbol == matrix[row,col])
                    {
                        rowNum = row;
                        colNum = col;
                        matchFound = true;
                        break;
                    }
                }

                if (matchFound)
                {
                    break;
                }
            }

            if (matchFound)
            {
                Console.WriteLine($"({rowNum}, {colNum})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }

        }
    }
}
