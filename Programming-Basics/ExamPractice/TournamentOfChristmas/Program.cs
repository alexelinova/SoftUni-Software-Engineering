using System;

namespace TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTournament = int.Parse(Console.ReadLine());
            int winCounter = 0;
            int loseCounter = 0;
            double moneyWon = 0;
            double moneyPerDay = 0;
            int wonDaysCounter = 0;
            int lostDaysCounter = 0;


            for (int i = 1; i <= daysOfTournament; i++)
            {
                
                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "Finish")
                    {
                        if (winCounter > loseCounter)
                        {
                            wonDaysCounter++;
                            moneyWon += 0.10 * moneyWon;
                        }
                        else
                        {
                            lostDaysCounter++;
                        }
                        moneyPerDay += moneyWon;
                        winCounter = 0;
                        loseCounter = 0;
                        moneyWon = 0;
                        break;
                    }

                    string result = Console.ReadLine();
                    if (result == "win")
                    {
                        winCounter++;
                        moneyWon += 20;
                    }
                    else if (result == "lose")
                    {
                        loseCounter++;
                    }

                }

            }
            if (wonDaysCounter > lostDaysCounter)
            {
                Console.WriteLine($"You won the tournament! Total raised money: {(moneyPerDay * 0.20 + moneyPerDay):f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {moneyPerDay:f2}");
            }
        }
    }
}
