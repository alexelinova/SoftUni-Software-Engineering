using System;


namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity, double airConModifier)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConModifier = airConModifier;
        }

        protected double AirConModifier { get; set; }
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            protected set
            {
                if (value > TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; }
        public int TankCapacity { get; }

        public void Drive(double distance)
        {
            if (distance * (FuelConsumption + AirConModifier) <= FuelQuantity)
            {
                Console.WriteLine($"{GetType().Name} travelled {distance} km");

                FuelQuantity -= distance * (FuelConsumption + AirConModifier);
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (amount + fuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
