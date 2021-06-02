using System;
using System.IO;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] partOne = File.ReadAllLines("input1.txt");
            string[] partTwo = File.ReadAllLines("input2.txt");

            File.WriteAllLines("output.txt", partOne);
            File.AppendAllLines("output.txt", partTwo);
        }
    }
}
