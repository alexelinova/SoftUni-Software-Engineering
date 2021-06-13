using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string type = carInfo[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, type);
              
                Tire[] tires = new Tire[4]
                {
                    new Tire(double.Parse(carInfo[5]), int.Parse(carInfo[6])),
                    new Tire(double.Parse(carInfo[7]), int.Parse(carInfo[8])),
                    new Tire(double.Parse(carInfo[9]), int.Parse(carInfo[10])),
                    new Tire(double.Parse(carInfo[11]), int.Parse(carInfo[12]))

                };

                Car currentCar = new Car(model, engine, cargo, tires);

                cars.Add(currentCar);
            }

            string command = Console.ReadLine();

            List<Car> filtered = new List<Car>();

            if (command == "fragile")
            {
               filtered = cars.Where(car => car.Cargo.Type == "fragile" && car.Tires.Any(n => n.Pressure < 1)).ToList();
            }
            else if (command == "flamable")
            {
               filtered = cars.Where(car => car.Cargo.Type == "flamable" && car.Engine.Power > 250).ToList();
            }

            foreach (Car car in filtered)
            {
                Console.WriteLine(car.Model);
            }
           
        }
    }
}
