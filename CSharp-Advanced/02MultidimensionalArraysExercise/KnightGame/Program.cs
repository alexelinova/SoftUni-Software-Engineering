using System;


namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[n, n];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = input[col];
                }
            }

            int countReplaced = 0;
            int rowKnightKiller = 0;
            int columnKnightKiller = 0;

            while (true)
            {
                int maxAttacks = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char currentSymbol = chessBoard[row, col];
                        int attacks = 0;

                        if (currentSymbol == 'K')
                        {
                            attacks = GetAttacks(chessBoard, row, col, attacks);

                            if (attacks > maxAttacks)
                            {
                                maxAttacks = attacks;
                                rowKnightKiller = row;
                                columnKnightKiller = col;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    chessBoard[rowKnightKiller, columnKnightKiller] = '0';
                    countReplaced++;
                }
                else
                {
                    Console.WriteLine(countReplaced);
                    break;
                } 
            }
        }

        private static int GetAttacks(char[,] chessBoard, int row, int col, int attacks)
        {
            if (isIndise(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
            {
                attacks++;
            }

            if (isIndise(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
            {
                attacks++;
            }

            if (isIndise(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (isIndise(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
            {
                attacks++;
            }

            if (isIndise(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (isIndise(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
            {
                attacks++;
            }

            if (isIndise(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
            {
                attacks++;
            }

            if (isIndise(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }

        private static bool isIndise(char[,] chessBoard, int row, int column)
        {
            return row >= 0 && row < chessBoard.GetLength(0)
                  && column >= 0 && column < chessBoard.GetLength(1);
        }
    }
}
