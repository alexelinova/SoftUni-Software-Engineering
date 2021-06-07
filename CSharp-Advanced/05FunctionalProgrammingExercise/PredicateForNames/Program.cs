using System;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            foreach (var name in names.Where(n => n.Length <= length))
            {
                Console.WriteLine(name);
            }
        }
    }
}
