using System;

namespace CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string classOfCar = "";
            string typeOfCar = "";
            double price = 0;

            if ( budget <= 100)
            {
                classOfCar = "Economy class";
                if (season == "Summer")
                {
                    typeOfCar = "Cabrio";
                    price = 0.35 * budget;
                }
                else
                {
                    typeOfCar = "Jeep";
                    price = 0.65 * budget;
                }

            }
            else if (budget <= 500)
            {
                classOfCar = "Compact class";
                if (season == "Summer")
                {
                    typeOfCar = "Cabrio";
                    price = 0.45 * budget;
                }
                else
                {
                    typeOfCar = "Jeep";
                    price = 0.80 * budget;
                }
            }
            else if (budget > 500)
            {
                classOfCar = "Luxury class";
                typeOfCar = "Jeep";
                price = 0.9 * budget;
            }

            Console.WriteLine(classOfCar);
            Console.WriteLine($"{typeOfCar} - {price:f2}");
        }
    }
}
