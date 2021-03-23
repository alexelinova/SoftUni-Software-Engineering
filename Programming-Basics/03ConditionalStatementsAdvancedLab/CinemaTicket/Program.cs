using System;

namespace CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Да се напише програма която чете ден от седмицата (текст) – въведен от потребителя и принтира на
            //конзолата цената на билет за кино според деня от седмицата:
            string dayOfTheWeek = Console.ReadLine();

            switch (dayOfTheWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                    Console.WriteLine(12);
                    break;

                case "Wednesday":
                case "Thursday":
                    Console.WriteLine(14);
                    break;

                case "Saturday":
                case "Sunday":
                    Console.WriteLine(16);
                    break;

                
            }
        }
    }
}
