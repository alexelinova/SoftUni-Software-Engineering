using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string day = Console.ReadLine();

            double totalPrice = 0.00;


            if (typeOfPeople == "Students")
            {
                if (day == "Friday")
                {
                    totalPrice = numberOfPeople * 8.45;
                }
                else if (day == "Saturday")
                {
                    totalPrice = numberOfPeople * 9.80;
                }
                else if (day == "Sunday")
                {
                    totalPrice = numberOfPeople * 10.46;
                }

                if (numberOfPeople >= 30)
                {
                    totalPrice -= totalPrice * 0.15;
                }
            }
            else if (typeOfPeople == "Business")
            {
                if (day == "Friday")
                {
                    totalPrice = numberOfPeople * 10.90;
                }
                else if (day == "Saturday")
                {
                    totalPrice = numberOfPeople * 15.60;
                }
                else if (day == "Sunday")
                {
                    totalPrice = numberOfPeople * 16;
                }

                if (numberOfPeople >= 100)
                {
                    totalPrice -= totalPrice / numberOfPeople * 10;
                }
            }
            else if (typeOfPeople == "Regular")
            {
                if (day == "Friday")
                {
                    totalPrice = numberOfPeople * 15;
                }
                else if (day == "Saturday")
                {
                    totalPrice = numberOfPeople * 20;
                }
                else if (day == "Sunday")
                {
                    totalPrice = numberOfPeople * 22.50;
                }

                if (numberOfPeople >= 10 && numberOfPeople <= 20)
                {
                    totalPrice -= totalPrice * 0.05;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
