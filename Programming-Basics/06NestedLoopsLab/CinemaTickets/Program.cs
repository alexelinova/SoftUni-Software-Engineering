using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int student = 0;
            int standard = 0;
            int kid = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Finish")
                {
                    break;
                }

                int freeSeats = int.Parse(Console.ReadLine());

                int currentFreeSeats = freeSeats;

                while (currentFreeSeats > 0)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    currentFreeSeats--;

                    if (ticketType == "student")
                    {
                        student++;
                    }
                    else if (ticketType == "kid")
                    {
                        kid++;
                    }
                    else if (ticketType == "standard")
                    {
                        standard++;
                    }

                }

                double freeSeatsInPercentage = 100 - (currentFreeSeats * 1.0 / freeSeats * 100);

                Console.WriteLine($"{input} - {freeSeatsInPercentage:f2}% full.");
            }

            int totalTickets = kid + standard + student;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{student * 1.0 / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{standard * 1.0 / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{kid * 1.0 / totalTickets * 100:f2}% kids tickets.");

        }
    }
}
