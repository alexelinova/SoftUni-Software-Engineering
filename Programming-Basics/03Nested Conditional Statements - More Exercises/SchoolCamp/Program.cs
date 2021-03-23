using System;

namespace SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string typeOfGroup = Console.ReadLine();
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfNights = int.Parse(Console.ReadLine());

            string sport = "";
            double price = 0;

            if (season == "Winter")
            {
                if (typeOfGroup == "boys")
                {
                    sport = "Judo";
                    price = numberOfStudents * numberOfNights * 9.60;

                }
                else if (typeOfGroup == "girls")
                {
                    sport = "Gymnastics";
                    price = price = numberOfStudents * numberOfNights * 9.60;

                }
                else if (typeOfGroup == "mixed")
                {
                    sport = "Ski";
                    price = price = numberOfStudents * numberOfNights * 10;
                }
            }
            else if (season == "Spring")
            {
                if (typeOfGroup == "boys")
                {
                    sport = "Tennis";
                    price = numberOfStudents * numberOfNights * 7.20;

                }
                else if (typeOfGroup == "girls")
                {
                    sport = "Athletics";
                    price = numberOfStudents * numberOfNights * 7.20;
                }
                else if (typeOfGroup == "mixed")
                {
                    sport = "Cycling";
                    price = numberOfStudents * numberOfNights * 9.50;
                }
            }
            else if (season == "Summer")
            {
                if (typeOfGroup == "boys")
                {
                    sport = "Football";
                    price = numberOfNights * numberOfStudents * 15;
                }
                else if (typeOfGroup == "girls")
                {
                    sport = "Volleyball";
                    price = numberOfNights * numberOfStudents * 15;
                }
                else if (typeOfGroup == "mixed")
                {
                    sport = "Swimming";
                    price = numberOfNights * numberOfStudents * 20;
                }
            }
            if (numberOfStudents >= 50)
            {
                price -= 0.50 * price;
            }
            else if (numberOfStudents >= 20)
            {
                price -= 0.15 * price;
            }
            else if (numberOfStudents >= 10)
            {
                price -= price * 0.05;
            }

            Console.WriteLine($"{sport} {price:f2} lv.");
        }
    }
}
