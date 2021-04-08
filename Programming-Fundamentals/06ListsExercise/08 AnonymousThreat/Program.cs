using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "3:1")
                {
                    break;
                }

                string[] command = line.Split();

                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex >= input.Count)
                    {
                        continue;
                    }

                    if (startIndex < 0 || endIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex > input.Count - 1)
                    {
                        endIndex = input.Count - 1;
                    }

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        input[startIndex] += input[i + 1];
                    }

                    input.RemoveRange(startIndex + 1, endIndex - startIndex);
                    
                }
                else
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);

                    string element = input[index];

                    input.RemoveAt(index);

                    int partitionSize = element.Length / partitions;

                    List<string> substrings = new List<string>();
                    for (int i = 0; i < partitions - 1; i++)
                    {
                        string substring = element.Substring(i * partitionSize, partitionSize);
                        substrings.Add(substring);
                    }

                    string lastSubstring = element.Substring((partitions - 1) * partitionSize);
                    substrings.Add(lastSubstring);
                    input.InsertRange(index, substrings);
                }

            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
