using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        private const double BaseWeightModifier = 0.4;

        private static HashSet<string> dogAllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };

        public Dog(string name, double weigth, string livingRegion) 
            : base(name, weigth, dogAllowedFoods, BaseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
