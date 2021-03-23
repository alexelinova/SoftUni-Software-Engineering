using System;

namespace BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {

            int juniorParticipants = int.Parse(Console.ReadLine());
            int seniorParticipants = int.Parse(Console.ReadLine());
            string typeOFTrail = Console.ReadLine();

            double moneyFromCompetition = 0;

            switch (typeOFTrail)
            {
                case "trail":
                    moneyFromCompetition = juniorParticipants * 5.5 + seniorParticipants * 7;
                    break;
                case "cross-country":
                    moneyFromCompetition = juniorParticipants * 8 + seniorParticipants * 9.50;

                    if (juniorParticipants + seniorParticipants >= 50)
                    {
                        moneyFromCompetition -= moneyFromCompetition * 0.25;
                    }
                    break;
                case "downhill":
                    moneyFromCompetition = juniorParticipants * 12.25 + seniorParticipants * 13.75;
                    break;
                case "road":
                    moneyFromCompetition = juniorParticipants * 20 + seniorParticipants * 21.50;
                    break;
            }

            moneyFromCompetition -= moneyFromCompetition * 0.05;
            Console.WriteLine($"{moneyFromCompetition:f2}");
        }
    }
}
