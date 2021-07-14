

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirConModifier = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, CarAirConModifier)
        {
        }
       
    }
}
