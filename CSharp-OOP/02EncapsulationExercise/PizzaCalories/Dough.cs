﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const string InvalidDoughExceptionMessage = "Invalid type of dough.";

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                string valueAsLower = value.ToLower();

                if (valueAsLower != "white" && valueAsLower != "wholegrain")
                {
                    throw new ArgumentException(InvalidDoughExceptionMessage);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                string valueAsLower = value.ToLower();

                if (valueAsLower != "crispy" && valueAsLower != "chewy" && valueAsLower != "homemade")
                {
                    throw new ArgumentException(InvalidDoughExceptionMessage);
                }
                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => this.weight;

            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double flourTypeModifier = GetFlourTypeModifier();
            double bakingTechniqueModifier = GetBakingTechniqueModifier();

            return this.Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            string bakingTechniqueLower = this.BakingTechnique.ToLower();

            if (bakingTechniqueLower == "crispy")
            {
                return 0.9;
            }

            if (bakingTechniqueLower == "chewy")
            {
                return 1.1;
            }

            return 1.0;
        }

        private double GetFlourTypeModifier()
        {
            string flourTypeLower = this.FlourType.ToLower();

            if (flourTypeLower == "white")
            {
                return 1.5;
            }

            return 1.0;
        }
    }
}
