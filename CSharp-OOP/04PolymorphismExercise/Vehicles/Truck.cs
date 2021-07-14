

using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConModifier = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, TruckAirConModifier)
        {
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (amount + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            FuelQuantity += amount * 0.95;
        }

    }
}
