using System;
using System.Linq;

namespace LadyBug
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            bool[] field = new bool[fieldSize];

            int[] initialIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            foreach (var index in initialIndexes)
            {
                if (index < 0 || index >= field.Length)
                {
                    continue;
                }

                field[index] = true;
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] commands = line.Split();

                int index = int.Parse(commands[0]);
                string direction = commands[1];
                int length = int.Parse(commands[2]);

                if (index < 0 || index >= field.Length || !field[index])
                {
                    continue;
                }

                field[index] = false;

                while (true)
                {
                    if (direction == "right")
                    {
                        index += length;
                    }
                    else
                    {
                        index -= length;
                    }


                    //index + length -> cell outside of the field
                    if (index >= field.Length || index < 0)
                    {
                        break;
                    }

                    //index + length -> empty cell
                    if (!field[index])
                    {
                        field[index] = true;
                        break;
                    }
                }

            }

            foreach (var cell in field)
            {
                if (cell)
                {
                    Console.Write("1 ");
                }
                else
                {
                    Console.Write("0 ");
                }
            }
        }
    }
}
