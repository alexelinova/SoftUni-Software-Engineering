using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {

            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

            string names = Console.ReadLine();

            MatchCollection matches = Regex.Matches(names, regex);

            Console.Write(string.Join(' ', matches));
            
        }
    }
}
