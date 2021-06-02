using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                int counter = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}


