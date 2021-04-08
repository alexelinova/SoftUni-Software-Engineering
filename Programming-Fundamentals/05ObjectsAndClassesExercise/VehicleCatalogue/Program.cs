using System;
using System.Collections.Generic;

namespace VehicleCatalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] input = line.Split();

                string typeOfVehicle = input[0];

                if (typeOfVehicle == "car")
                {
                    typeOfVehicle = "Car";
                }
                else
                {
                    typeOfVehicle = "Truck";
                }
                string model = input[1];
                string colour = input[2];
                int horsepower = int.Parse(input[3]);

                Vehicle vehicle = new Vehicle()
                {
                    Type = typeOfVehicle,
                    Model = model,
                    Color = colour,
                    Horsepower = horsepower

                };

                catalogue.Add(vehicle);
            }

            while (true)
            {
                string model = Console.ReadLine();

                if (model == "Close the Catalogue")
                {
                    break;
                }

                Vehicle currentModel = GetModel(catalogue, model);

                if (currentModel == null)
                {
                    continue;
                }

                Console.WriteLine($"Type: {currentModel.Type}");
                Console.WriteLine($"Model: {currentModel.Model}");
                Console.WriteLine($"Color: {currentModel.Color}");
                Console.WriteLine($"Horsepower: {currentModel.Horsepower}");
            }


            double averageHorsepowerCars = GetAverageHorsepower(catalogue, "Car");
            Console.WriteLine($"Cars have average horsepower of: {averageHorsepowerCars:f2}.");


            double averageHorsepowerTrucks = GetAverageHorsepower(catalogue, "Truck");
            Console.WriteLine($"Trucks have average horsepower of: {averageHorsepowerTrucks:f2}.");

        }

        private static double GetAverageHorsepower(List<Vehicle> catalogue, string vehicleType)
        {
            double numberOfVehicles = 0;
            int horsePowerOfVehicles = 0;

            foreach (Vehicle vehicle in catalogue)
            {

                if (vehicle.Type == vehicleType)
                {
                    numberOfVehicles++;
                    horsePowerOfVehicles += vehicle.Horsepower;

                }
            }
            if (numberOfVehicles == 0)
            {
                return 0;
            }

            double averageHorsepower = horsePowerOfVehicles / numberOfVehicles;

            return averageHorsepower;
        }

        private static Vehicle GetModel(List<Vehicle> catalogue, string model)
        {
            foreach (Vehicle vehicle in catalogue)
            {
                if (vehicle.Model == model)
                {
                    return vehicle;
                }
            }

            return null;
        }
    }
}
