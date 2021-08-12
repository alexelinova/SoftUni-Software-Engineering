using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private const int EnergyDrop = 10;

        private string name;
        private int energy;

        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            Dyes = new List<IDye>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }

        public int Energy 
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energy = value;
            }
        }

        public ICollection<IDye> Dyes {get;}

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }

        public virtual void Work()
        {
            this.Energy -= EnergyDrop;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}" +
                Environment.NewLine +
                $"Energy: {this.Energy}" +
                Environment.NewLine +
                $"Dyes: {this.Dyes.Count} not finished";

        }
    }
}
