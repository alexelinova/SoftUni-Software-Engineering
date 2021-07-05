using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name
        {
            get => this.name;
            set
            {
                string valueAsLower = value.ToLower();
                if (valueAsLower != "meat" && valueAsLower != "veggies" && valueAsLower != "cheese" && valueAsLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.name = value; ;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.Name} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double modifier = GetModifier();

            return this.Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            string nameLower = this.Name.ToLower();

            if (nameLower == "meat")
            {
                return 1.2;
            }

            if (nameLower == "veggies")
            {
                return 0.8;
            }

            if (nameLower == "cheese")
            {
                return 1.1;
            }

            return 0.9;
        }
    }
}
