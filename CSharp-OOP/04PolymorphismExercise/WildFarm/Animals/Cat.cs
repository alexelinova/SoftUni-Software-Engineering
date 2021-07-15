using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Cat : Feline
    {
        private const double BaseWeightModifier = 0.3;

        private static HashSet<string> catAllowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable)
        };

        public Cat(string name, double weigth, string livingRegion, string breed) 
            : base(name, weigth, catAllowedFoods, BaseWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
