using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        passedCars++;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }    
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
