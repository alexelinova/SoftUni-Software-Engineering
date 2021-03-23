using System;

namespace SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            int numberofSuitcases = 0;
            int thirdSuitcaseCounter = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine("Congratulations! All suitcases are loaded!");
                    break;
                }
                double suitcase = double.Parse(command);
                thirdSuitcaseCounter++;
                if (thirdSuitcaseCounter == 3)
                {
                    suitcase += suitcase * 0.10;
                    thirdSuitcaseCounter = 0;
                }
                capacity -= suitcase;
                
                if (capacity <= 0)
                {
                    Console.WriteLine("No more space!");
                    break;
                }
                numberofSuitcases++;
            }
            Console.WriteLine($"Statistic: {numberofSuitcases} suitcases loaded.");
        }
    }
}
