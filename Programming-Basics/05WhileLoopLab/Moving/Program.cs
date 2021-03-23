using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());

            int volume = x * y * z;
            bool hasSpace = true;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Done")
                {
                    break;
                }
                int boxes = int.Parse(input);
                volume -= boxes;
                if (volume <= 0)
                {
                    hasSpace = false;
                    break;
                }

            }
            if (hasSpace)
            {
                Console.WriteLine($"{volume} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
            }

        }
    }
}
