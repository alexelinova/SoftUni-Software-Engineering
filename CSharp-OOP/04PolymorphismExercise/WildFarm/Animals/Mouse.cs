using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Mouse : Mammal
    {
        private const double BaseWeightModifier = 0.1;

        private static HashSet<string> mouseAllowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit),
          
        };

        public Mouse(string name, double weigth, string livingRegion) 
            : base(name, weigth, mouseAllowedFoods, BaseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
