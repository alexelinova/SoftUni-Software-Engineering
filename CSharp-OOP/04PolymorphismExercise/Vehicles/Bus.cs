using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirConModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, BusAirConModifier)
        {
        }

        public void DriveEmpty(double distance)
        {
            if (distance * FuelConsumption <= FuelQuantity)
            {
                Console.WriteLine($"{GetType().Name} travelled {distance} km");

                FuelQuantity -= distance * FuelConsumption;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

    }
}
