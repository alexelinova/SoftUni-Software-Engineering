using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();

            if (type == "string")
            {
                Console.WriteLine(GetMax(firstValue, secondValue));
            }
            else if (type == "int")
            {
                Console.WriteLine(GetMax(int.Parse(firstValue), int.Parse(secondValue)));
            }
            else
            {
                Console.WriteLine(GetMax(char.Parse(firstValue), char.Parse(secondValue)));
            }
        }

        static string GetMax(string a, string b)
        {
            if (a.CompareTo(b) >= 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }

        static char GetMax(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
