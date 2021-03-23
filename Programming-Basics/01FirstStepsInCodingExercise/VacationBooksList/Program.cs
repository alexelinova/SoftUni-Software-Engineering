using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Брой страници в текущата книга – цяло число в интервала[1…1000];
            int numberOfPages = int.Parse(Console.ReadLine());
            //2.Страници, които може да прочита за 1 час – реално число в интервала[1.00…1000.00];
            double pagesPerHour = double.Parse(Console.ReadLine());
            //3.Броя на дните, за които трябва да прочете книгата – цяло число в интервала[1…1000];
            int numberOfDays = int.Parse(Console.ReadLine());
            //4. Калкулация
            double hoursPerDay = (numberOfPages / pagesPerHour) / numberOfDays;
            //5.Да се отпечата на конзолата броят часове, които Жоро трябва да отделя за четене всеки ден.
            Console.WriteLine(hoursPerDay);
        }
    }
}
