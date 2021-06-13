using System;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double amountOfKilometers)
        {
            if (FuelAmount >= FuelConsumptionPerKilometer * amountOfKilometers)
            {
                FuelAmount -= FuelConsumptionPerKilometer * amountOfKilometers;
                TravelledDistance += amountOfKilometers;
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
