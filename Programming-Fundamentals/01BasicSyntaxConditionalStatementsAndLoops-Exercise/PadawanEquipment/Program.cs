using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double pricePerLightsaber = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());

            double priceForRobes = countOfStudents * pricePerRobe;
            double priceForLightsaber = (Math.Ceiling(countOfStudents * 1.1)) * pricePerLightsaber;
            double priceForBelts = (countOfStudents - countOfStudents / 6) * pricePerBelt;

            double totalPrice = priceForBelts + priceForLightsaber + priceForRobes;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {

                Console.WriteLine($"Ivan Cho will need {(totalPrice - budget):f2}lv more.");
            }
        }
    }
}
