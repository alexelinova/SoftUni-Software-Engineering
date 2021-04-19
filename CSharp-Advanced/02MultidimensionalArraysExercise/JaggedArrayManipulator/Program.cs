using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                jaggedArray[row] = numbers;
            }

            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    jaggedArray[row] = jaggedArray[row].Select(n => n * 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(n => n * 2).ToArray();
                }
                else
                {
                    jaggedArray[row] = jaggedArray[row].Select(n => n / 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(n => n / 2).ToArray();
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                int row = int.Parse(command[1]);
                int column = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (!isValid(row, jaggedArray.Length) || !isValid(column, jaggedArray[row].Length))
                {
                    continue;
                }

                if (action == "Add")
                {
                    jaggedArray[row][column] += value;
                }
                else
                {
                    jaggedArray[row][column] -= value;
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ",jaggedArray[row]));
            }
        }

        private static bool isValid(int row, int length)
        {
            if (row < 0 || row >= length)
            {
                return false;
            }

            return true;
        }
    }
}
