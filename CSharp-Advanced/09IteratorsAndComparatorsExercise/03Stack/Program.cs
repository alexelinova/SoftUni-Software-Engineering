using System;
using System.Linq;

namespace _03Stack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stack<string> collection = new Stack<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (input == "Pop")
                {
                    try
                    {
                        collection.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    string[] elements = input.Substring(5).Split(", ").ToArray();

                    for (int i = 0; i < elements.Length; i++)
                    {
                        collection.Push(elements[i]);
                    }
                }
            }

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }
    }
}
