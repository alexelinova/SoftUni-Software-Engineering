using System;
using System.Text.RegularExpressions;

namespace ExtractMails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex mailRegex = new Regex(@"(^|(?<=\s))[A-Za-z\d]+([.\-_][A-Za-z\d]+)*@[A-Za-z]+(\-[A-Za-z]+)*(\.[A-Za-z]+)+");

            MatchCollection matches = mailRegex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
