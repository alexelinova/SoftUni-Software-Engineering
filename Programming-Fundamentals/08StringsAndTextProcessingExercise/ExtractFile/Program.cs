using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            int index = path.LastIndexOf('\\');

            string[] file = path.Substring(++index).Split(".");

            string fileName = file[0];
            string extension = file[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");

        }
    }
}
