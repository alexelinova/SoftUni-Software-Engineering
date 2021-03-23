using System;
using System.ComponentModel.Design.Serialization;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            if (dayOfTheWeek == "Monday" || dayOfTheWeek == "Tuesday" || dayOfTheWeek == "Wednesday" || dayOfTheWeek == "Thursday" || dayOfTheWeek == "Friday")
            {
                if (fruit == "banana")
                {
                    price = quantity * 2.50;
                }
                else if (fruit == "apple")
                {
                    price = quantity * 1.20;
                }
                else if (fruit == "orange")
                {
                    price = quantity * 0.85;
                }
                else if (fruit == "grapefruit")
                {
                    price = quantity * 1.45;
                }
                else if (fruit == "kiwi")
                {
                    price = quantity * 2.70;
                }
                else if (fruit == "pineapple")
                {
                    price = quantity * 5.50;
                }
                else if (fruit == "grapes")
                {
                    price = quantity * 3.85;
                }
                else
                {
                    Console.WriteLine("error");
                }
      
            }
            else if (dayOfTheWeek == "Saturday" || dayOfTheWeek == "Sunday")
            {
                if (fruit == "banana")
                {
                    price = quantity * 2.70;
                }
                else if (fruit == "apple")
                {
                    price = quantity * 1.25;
                }
                else if (fruit == "orange")
                {
                    price = quantity * 0.90;
                }
                else if (fruit == "grapefruit")
                {
                    price = quantity * 1.60;
                }
                else if (fruit == "kiwi")
                {
                    price = quantity * 3;
                }
                else if (fruit == "pineapple")
                {
                    price = quantity * 5.60;
                }
                else if (fruit == "grapes")
                {
                    price = quantity * 4.20;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }

            if (price != 0)
            {
                Console.WriteLine($"{price:f2}");
            }
            //Напишете програма, която чете от конзолата плод(banana / apple / orange / grapefruit / kiwi /
//pineapple / grapes), ден от седмицата(Monday / Tuesday / Wednesday / Thursday / Friday /
//Saturday / Sunday) и количество(реално число) , въведени от потребителя, и пресмята цената според
//цените от таблиците по-горе.Резултатът да се отпечата закръглен с 2 цифри след десетичната точка. При
//невалиден ден от седмицата или невалидно име на плод да се отпечата & quot; error & quot;.
        }
    }
}
