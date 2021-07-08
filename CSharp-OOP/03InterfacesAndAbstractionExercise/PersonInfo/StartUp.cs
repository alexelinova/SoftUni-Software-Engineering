using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string,IBuyer> buyers = new Dictionary<string,IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (data.Length == 4)
                {
                    buyers.Add(data[0],new Citizen(data[0], int.Parse(data[1]), data[2], data[3]));
                }
                else
                {
                    buyers.Add(data[0],new Rebel(data[0], int.Parse(data[1]), data[2]));
                }
            }

            while (true)
            {
                string buyersName = Console.ReadLine();

                if (buyersName == "End")
                {
                    break;
                }

                if (!buyers.ContainsKey(buyersName))
                {
                    continue;
                }

                buyers[buyersName].BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Value.Food));
        }
    }
}
