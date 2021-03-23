using System;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int hoursNeeded = int.Parse(Console.ReadLine());
            int deadlineInDays = int.Parse(Console.ReadLine());
            int workersDoingOvertime = int.Parse(Console.ReadLine());

            double hoursForWorking = (deadlineInDays - 0.10 * deadlineInDays) * 8;
            double overtime = workersDoingOvertime * deadlineInDays * 2;
            double allHours = Math.Floor(hoursForWorking + overtime);

            if (allHours < hoursNeeded)
            {
                Console.WriteLine($"Not enough time!{hoursNeeded - allHours} hours needed.");
            }
            else
            {
                Console.WriteLine($"Yes!{allHours - hoursNeeded} hours left.");
            }

        }
    }
}
