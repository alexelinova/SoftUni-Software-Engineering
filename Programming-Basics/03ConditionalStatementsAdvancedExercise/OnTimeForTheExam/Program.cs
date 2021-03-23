using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examStartingHour = int.Parse(Console.ReadLine());
            int examStartingMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int examStartingHourMinutes = examStartingHour * 60 + examStartingMinutes;
            int arrivalHourMinutes = arrivalHour * 60 + arrivalMinutes;

            if (arrivalHourMinutes <= examStartingHourMinutes)
            {
                if (arrivalHourMinutes == examStartingHourMinutes)
                {
                    Console.WriteLine("On time");
                   
                }
                else if (examStartingHourMinutes - arrivalHourMinutes <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{examStartingHourMinutes - arrivalHourMinutes} minutes before the start");
                }
                else if (examStartingHourMinutes - arrivalHourMinutes > 30 && examStartingHourMinutes - arrivalHourMinutes < 60)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{ examStartingHourMinutes - arrivalHourMinutes} minutes before the start");
                }
                else
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{(examStartingHourMinutes - arrivalHourMinutes) / 60}:{(examStartingHourMinutes - arrivalHourMinutes) % 60:d2} hours before the start");
                }
            }
            if (arrivalHourMinutes > examStartingHourMinutes)
            {
                if (arrivalHourMinutes - examStartingHourMinutes < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{arrivalHourMinutes - examStartingHourMinutes} minutes after the start");
                }
                else
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{(arrivalHourMinutes - examStartingHourMinutes) / 60}:{(arrivalHourMinutes - examStartingMinutes) % 60:d2} hours after the start");
                }
            }
        }

    }
}
