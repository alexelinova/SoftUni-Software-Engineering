using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Tiger : Feline
    {
        private const double BaseWeightModifier = 1;

        private static HashSet<string> tigerAllowedFoods = new HashSet<string>
        {
            nameof(Meat)
          
        };

        public Tiger(string name, double weigth, string livingRegion, string breed) 
            : base(name, weigth, tigerAllowedFoods, BaseWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
