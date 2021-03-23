using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());
            double apartmentPrice = 0;
            double studioPrice = 0;
            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = numberOfNights * 50;
                    apartmentPrice = numberOfNights * 65;
                    if (numberOfNights > 7 && numberOfNights < 14)
                    {
                        studioPrice = numberOfNights * 50 - numberOfNights * 50 * 0.05;
                    }
                    else if (numberOfNights > 14)
                    {
                        studioPrice = numberOfNights * 50 - numberOfNights * 50 * 0.3;
                        apartmentPrice = numberOfNights * 65 - numberOfNights * 65 * 0.10;
                    }
                        break;
                case "June":
                case "September":
                    studioPrice = numberOfNights * 75.20;
                    apartmentPrice = numberOfNights * 68.70;
                    if (numberOfNights > 14)
                    {
                        studioPrice = numberOfNights * 75.20 - numberOfNights * 75.20 * 0.2;
                        apartmentPrice = numberOfNights * 68.70 - numberOfNights * 68.70 * 0.1;
                    }
                    break;
                case "July":
                case "August":
                    studioPrice = numberOfNights * 76;
                    apartmentPrice = numberOfNights * 77;
                    if (numberOfNights > 14)
                    {
                        apartmentPrice = numberOfNights * 77 - numberOfNights * 77 * 0.1;
                    }
                    break;
            }
            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");

        }
    }
}
