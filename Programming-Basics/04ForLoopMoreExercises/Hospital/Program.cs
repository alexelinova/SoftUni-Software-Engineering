using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int doctors = 7;
            int checkedPatients = 0;
            int notCheckedPatients = 0;


            for (int day = 1; day <= days; day++)
            {
                if (day % 3 == 0 && notCheckedPatients > checkedPatients)
                { 
                    doctors++;
                }
                int patients = int.Parse(Console.ReadLine());
                if (patients >= doctors)
                {
                    checkedPatients += doctors;
                    notCheckedPatients += patients - doctors;
                }
                else
                {
                    checkedPatients += patients;
                }
            }
            Console.WriteLine($"Treated patients: {checkedPatients}.");
            Console.WriteLine($"Untreated patients: {notCheckedPatients}.");
        }
    }
}
