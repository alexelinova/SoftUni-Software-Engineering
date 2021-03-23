using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSeconds = 0;
            totalSeconds += int.Parse(Console.ReadLine());
            totalSeconds += int.Parse(Console.ReadLine());
            totalSeconds += int.Parse(Console.ReadLine());
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            Console.WriteLine($"{minutes}:{seconds:d2}");
              
        }
    }
}
