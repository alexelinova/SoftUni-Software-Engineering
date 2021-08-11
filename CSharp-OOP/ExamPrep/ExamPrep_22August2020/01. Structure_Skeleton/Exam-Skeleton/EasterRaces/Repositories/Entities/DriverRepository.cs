using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly ICollection<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }

        public IDriver FirstOrDefault { get; internal set; }

        public void Add(IDriver model)
        {
           
            drivers.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.drivers.ToList();
        }

        public IDriver GetByName(string name)
        {
            IDriver driver = drivers.FirstOrDefault(m => m.Name == name);

            return driver;
        }

        public bool Remove(IDriver model)
        {
            return drivers.Remove(model);
        }
    }
}
