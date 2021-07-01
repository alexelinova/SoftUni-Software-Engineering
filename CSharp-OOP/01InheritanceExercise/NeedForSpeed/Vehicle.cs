using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual double FuelConsumption => DefaultConsumption;

        public virtual void Drive(double km)
        {
            if (this.Fuel - km * this.FuelConsumption >= 0)
            {
                this.Fuel -= km * this.FuelConsumption;
            }
          
        }


    }
}
