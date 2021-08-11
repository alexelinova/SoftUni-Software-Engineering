using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EasterRaces.Repositories.Entities
{
    class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }
        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.races.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            IRace race = races.FirstOrDefault(m => m.Name == name);

            return race;
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
    }
}
