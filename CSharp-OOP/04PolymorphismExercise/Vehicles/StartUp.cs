using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                string vehicleType = input[1];
                double parameter = double.Parse(input[2]);

                try
                {
                    if (vehicleType == nameof(Car))
                    {
                        ProcessCommand(car, command, parameter);
                    }
                    else if (vehicleType == nameof(Truck))
                    {
                        ProcessCommand(truck, command, parameter);
                    }
                    else if (vehicleType == nameof(Bus))
                    {
                        ProcessCommand(bus, command, parameter);
                    }

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
        private static void ProcessCommand(Vehicle vehicle, string command, double parameter)
        {
            if (command == "Drive")
            {
                vehicle.Drive(parameter);
            }
            else if (command == "Refuel")
            {

                vehicle.Refuel(parameter);

            }
            else if (command == "DriveEmpty")
            {
                ((Bus)vehicle).DriveEmpty(parameter);
            }
        }

        private static Vehicle CreateVehicle()
        {
            string[] vehicleInfo = Console.ReadLine().Split();
            string type = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumption = double.Parse(vehicleInfo[2]);
            int tankCapcity = int.Parse(vehicleInfo[3]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapcity);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapcity);
            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapcity);
            }

            return vehicle;
        }
    }
}
