using System;

namespace TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double price = 0;

            if (kilometers < 20)
            {
                if (timeOfDay == "day")
                {
                    price = 0.70 + kilometers * 0.79;
                }
                else
                {
                    price = 0.70 + kilometers * 0.9;
                }
            }
            else if (kilometers < 100)
            {
                price = 0.09 * kilometers;
            }
            else
            {
                price = kilometers * 0.06;
            }
            Console.WriteLine($"{price:f2}");
           

        }
    }
}
