using System;
using System.Text.RegularExpressions;

namespace _01WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                 .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Regex winningRegex = new Regex(@"(@{6,10}|\${6,10}|#{6,10}|\^{6,10})");

            foreach (var ticket in tickets)
            {

                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                
                string leftSide = ticket.Substring(0, 10);

                string rightSide = ticket.Substring(10);


                if (!winningRegex.IsMatch(rightSide) || !winningRegex.IsMatch(leftSide))
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                string leftSideMatch = winningRegex.Match(leftSide).ToString();

                string rightSideMatch = winningRegex.Match(rightSide).ToString();

                if (leftSideMatch[1] != rightSideMatch[1])
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                if (leftSideMatch.Length == 10 && rightSideMatch.Length == 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {leftSideMatch.Length}{leftSideMatch[1]} Jackpot!");
                }
                else
                {
                    string shorter = leftSideMatch.Length > rightSideMatch.Length ? rightSideMatch : leftSideMatch;

                    Console.WriteLine(($"ticket \"{ticket}\" - {shorter.Length}{shorter[1]}"));
                }    

            }
        }
    }
}
