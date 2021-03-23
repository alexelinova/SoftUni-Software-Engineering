using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string typeOfAccommodation = "";
            string destination = "";
            double price = 0;

            if (budget <= 1000)
            {
                switch (season)
                { 
                    case "Summer":
                        typeOfAccommodation = "Camp";
                        destination = "Alaska";
                        price = budget * 0.65;
                        break;
                    case "Winter":
                        typeOfAccommodation = "Camp";
                        destination = "Morocco";
                        price = budget * 0.45;
                        break;
                }
            }
            else if (budget  <= 3000)
            {
                switch (season)
                {

                    case "Summer":
                        typeOfAccommodation = "Hut";
                        destination = "Alaska";
                        price = budget * 0.8;
                        break;
                    case "Winter":
                        typeOfAccommodation = "Hut";
                        destination = "Morocco";
                        price = budget * 0.6;
                        break;
                }
            }
            else
            {
                switch (season)
                {

                    case "Summer":
                        typeOfAccommodation = "Hotel";
                        destination = "Alaska";
                        price = budget * 0.9;
                        break;
                    case "Winter":
                        typeOfAccommodation = "Hotel";
                        destination = "Morocco";
                        price = budget * 0.9;
                        break;
                }
            }
            Console.WriteLine($"{destination} – {typeOfAccommodation} – {price:f2}");

        }
    }
}
