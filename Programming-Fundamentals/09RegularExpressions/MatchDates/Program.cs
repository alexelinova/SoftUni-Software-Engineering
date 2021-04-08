using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>\d{2})([./ -])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            foreach (Match date in matches)
            {
                Console.WriteLine($"Day: {date.Groups["day"]}, Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
            }
        
        }
    }
}
