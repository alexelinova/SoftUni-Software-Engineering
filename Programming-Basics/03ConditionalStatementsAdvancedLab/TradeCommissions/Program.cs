using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Напишете конзолна програма, която чете име на град (стринг) и обем на продажби (реално число) ,
            // въведени от потребителя, и изчислява и извежда размера на търговската комисионна според горната
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double commission = 0;

            if (town == "Sofia")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commission = sales * 0.05;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = sales * 0.07;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commission = sales * 0.08;
                }
                else if (sales > 10000)
                {
                    commission = sales * 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                }
                
            }

            else if (town == "Varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commission = sales * 0.045;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = sales * 0.075;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commission = sales * 0.10;
                }
                else if (sales > 10000)
                {
                    commission = sales * 0.13;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            else if (town == "Plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commission = sales * 0.055;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = sales * 0.08;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commission = sales * 0.12;
                }
                else if (sales > 10000)
                {
                    commission = sales * 0.145;
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
            if (commission >0)
            {
                Console.WriteLine($"{commission:f2}");
            }
            

        }
    }
}
