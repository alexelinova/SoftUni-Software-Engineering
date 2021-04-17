using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[n][];

            for (int row = 0; row < n; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                jaggedArray[row] = numbers;
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] command = input.Split();

                string action = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (action == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else
                {
                    jaggedArray[row][col] -= value;
                }
            }

            foreach (var array in jaggedArray)
            {
                Console.WriteLine(string.Join(" ",array));
            }
        }
    }
}
