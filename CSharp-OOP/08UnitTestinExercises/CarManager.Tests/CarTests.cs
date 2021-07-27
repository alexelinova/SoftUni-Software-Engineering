using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Model", "Make", 10, 100);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -50)]
        public void Ctor_ThrowsException_WhenDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10.00;
            double fuelCapacity = 100.00;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void Refuel_ThrowsException_WhenFuelIseroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void Refuel_IncreasesFuelAmount_WhenFuelAmountIsValid()
        {
            double refuelAmount = car.FuelCapacity / 2;
            car.Refuel(refuelAmount);

            Assert.That(car.FuelAmount, Is.EqualTo(refuelAmount));
        }

        [Test]
        public void Refuel_SetFuelAmountToCapacity_WhenCapacityIsExceeded()
        {
            car.Refuel(car.FuelCapacity * 1.2);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowsException_WhenFuelIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

        [Test]
        public void Drive_DecreasesFuelAmount_WhenDistanceISValid()
        {
            double initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);

            car.Drive(100);

            Assert.That(car.FuelAmount, Is.EqualTo(initialFuel - car.FuelConsumption));
        }
    }
}