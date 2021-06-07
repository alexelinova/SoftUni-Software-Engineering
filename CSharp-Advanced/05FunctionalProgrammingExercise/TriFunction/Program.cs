using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> func = (name, number) =>
            {
                return name.ToCharArray().Select(currChar => (int)currChar).Sum() >= number;
            };

            Func<string[], int, Func<string, int, bool>, string> foundName = (collection, value, func) =>
            collection.FirstOrDefault(name => func(name, value));

            Console.WriteLine(foundName(names, n, func));
        }
    }
}
