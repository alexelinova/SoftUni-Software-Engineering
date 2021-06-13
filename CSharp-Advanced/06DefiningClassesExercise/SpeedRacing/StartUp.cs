using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
     public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionPerKm = double.Parse(carData[2]);

                Car currentcar = new Car(model, fuelAmount, fuelConsumptionPerKm);
                cars.Add(currentcar);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] carData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carData[1];
                double distance = double.Parse(carData[2]);

                cars.Where(x => x.Model == model).ToList().ForEach(c => c.Drive(distance)); 
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
