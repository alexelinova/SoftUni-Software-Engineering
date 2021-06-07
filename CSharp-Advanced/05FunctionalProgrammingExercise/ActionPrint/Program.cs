using System;
using System.Linq;


namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = text => Console.WriteLine(text);

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);  
        }
    }
}
