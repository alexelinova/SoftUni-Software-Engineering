using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printWithSir = collection =>
            {
                foreach (var name in collection)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printWithSir(names);
        }
    }
}
