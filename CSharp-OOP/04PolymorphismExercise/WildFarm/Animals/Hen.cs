using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        private const double BaseWeightModifier = 0.35;

        private static HashSet<string> henAllowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds),
            nameof(Meat)
        };

        public Hen(string name, double weigth, double wingSize) 
            : base(name, weigth, henAllowedFoods, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
