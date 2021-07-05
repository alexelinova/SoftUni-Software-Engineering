using System;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];
            string[] doughInfo = Console.ReadLine().Split();

            string flourType = doughInfo[1];
            string bakingTechnique = doughInfo[2];
            int weight = int.Parse(doughInfo[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    string[] data = input.Split();

                    string toppingName = data[1];
                    int toppingWeight = int.Parse(data[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
