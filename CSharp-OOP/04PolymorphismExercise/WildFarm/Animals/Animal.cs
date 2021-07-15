using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {

        protected Animal(string name, double weigth, HashSet<string> allowedFoods, double weightModifier)
        {
            Name = name;
            Weight = weigth;
            AllowedFoods = allowedFoods;
            WeightModifier = weightModifier;

        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        private double WeightModifier{ get; set; }
        public abstract string ProduceSound();

        private HashSet<string> AllowedFoods { get; set; }

        public void Eat(Food food)
        {
            if (!AllowedFoods.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            this.Weight += WeightModifier * food.Quantity;
        }
      

    }
}
