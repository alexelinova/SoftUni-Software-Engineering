using System;


namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(site));
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
