using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] citizenInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);

                Citizen citizen = new Citizen(name, country, age);

                Console.WriteLine((citizen as IPerson).GetName());
                Console.WriteLine((citizen as IResident).GetName());
            }
        }
    }
}
