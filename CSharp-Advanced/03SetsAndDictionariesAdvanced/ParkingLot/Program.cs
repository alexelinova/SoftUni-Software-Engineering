using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNums = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] carsData = input.Split(", ");

                string action = carsData[0];
                string registration = carsData[1];

                if (action == "IN")
                {
                    carNums.Add(registration);
                }
                else
                {
                    carNums.Remove(registration);
                }
            }

            if (carNums.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, carNums));
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}
