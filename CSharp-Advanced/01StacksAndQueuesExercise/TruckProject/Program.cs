using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                bool isSuccessful = true;
                int petrol = 0;

                for (int j = 0; j < n; j++)
                {
                    int[] currentPump = pumps.Dequeue().Split().Select(int.Parse).ToArray();
                    pumps.Enqueue(string.Join(" ", currentPump));

                    petrol += currentPump[0];

                    petrol -= currentPump[1];

                    if (petrol < 0)
                    {
                        isSuccessful = false;
                    }
                }

                if (isSuccessful)
                {
                    Console.WriteLine(i);
                    break;
                }
                string temp = pumps.Dequeue();
                pumps.Enqueue(temp);

               
            }
          
        }
    }
}
