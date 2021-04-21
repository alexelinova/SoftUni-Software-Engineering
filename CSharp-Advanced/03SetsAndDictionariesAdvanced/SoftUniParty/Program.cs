using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> guestList = new HashSet<string>();
            HashSet<string> viptList = new HashSet<string>();

            while (input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    viptList.Add(input);
                }
                else
                {
                    guestList.Add(input);
                }
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                input = Console.ReadLine();

                if (char.IsDigit(input[0]))
                {
                    viptList.Remove(input);
                }
                else
                {
                    guestList.Remove(input);
                };
            }

            Console.WriteLine(guestList.Count + viptList.Count);

            foreach (var guest in viptList)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in guestList)
            {
                Console.WriteLine(guest);
            }

        }
    }
}
