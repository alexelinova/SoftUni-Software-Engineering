﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\+359([- ])2\1\d{3}\1\d{4}\b";

            string input = Console.ReadLine();

            MatchCollection collection = Regex.Matches(input, regex);

            var matchedphones = collection
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedphones));

        }
    }
}
