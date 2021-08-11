using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public void Add(ICar model)
        {
            cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return cars.AsReadOnly();
        }

        public ICar GetByName(string name)
        {
            ICar car = cars.FirstOrDefault(m => m.Model == name);

            return car;
        }

        public bool Remove(ICar model)
        {
            return cars.Remove(model);
        }
    }
}
