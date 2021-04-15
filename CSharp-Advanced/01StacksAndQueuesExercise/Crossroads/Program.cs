using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int passedCars = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (input == "green")
                {
                    int currentLight = greenLightDuration;
                    int currentFreeWindow = freeWindowDuration;

                    while (currentLight > 0 && cars.Count > 0)
                    {
                        string currentCar = cars.Dequeue();

                        if (currentCar.Length <= currentLight)
                        {
                            currentLight -= currentCar.Length;
                            passedCars++;
                        }
                        else if (currentCar.Length <= currentLight + currentFreeWindow)
                        {
                            currentLight = 0;
                            passedCars++;
                        }
                        else
                        {
                            int hitIndex = currentLight + currentFreeWindow;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[hitIndex]}.");
                            return;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
