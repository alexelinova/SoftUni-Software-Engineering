using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Facebook = 150;
            const int Instagram = 100;
            const int Reddit = 50;

            int openedTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i <= openedTabs; i++)
            {
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
                string browser = Console.ReadLine();
                if (browser == "Facebook")
                {
                    salary -= Facebook;
                }
                else if (browser == "Instagram")
                {
                    salary -= Instagram;
                }
                else if (browser == "Reddit")
                {
                    salary -= Reddit;
                }

            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }

        }
    }
}
