using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_VehicleCatalogue
{
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class Catalogue
    {
        public Catalogue()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] parts = input.Split("/");

                string type = parts[0];
                string brand = parts[1];
                string model = parts[2];
                int power = int.Parse(parts[3]);

                if (type == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = power

                    };

                    catalogue.Cars.Add(car);
                }

                else
                {
                    Truck truck = new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = power
                    };

                    catalogue.Trucks.Add(truck);
                }
            }

            List<Car> orderedCars = catalogue.Cars
                .OrderBy(n => n.Brand)
                .ToList();

            List<Truck> orderedTrucks = catalogue.Trucks
                .OrderBy(n => n.Brand)
                .ToList();

            if (orderedCars.Count > 0 )
            {
                Console.WriteLine("Cars:");

                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (orderedTrucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
