using System;


namespace FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFuel = Console.ReadLine();
            int litresInTank = int.Parse(Console.ReadLine());
            if (typeOfFuel == "Diesel" || typeOfFuel == "Gasoline" || typeOfFuel == "Gas")
            {
                if (litresInTank >= 25)
                {
                    Console.WriteLine($"You have enough {typeOfFuel.ToLower()}.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with {typeOfFuel.ToLower()}!");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }
            

        }
    }
}
