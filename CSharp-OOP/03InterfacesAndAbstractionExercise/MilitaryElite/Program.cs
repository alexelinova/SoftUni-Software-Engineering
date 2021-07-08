using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] data = line.Split();

                string type = data[0];
                string id = data[1];
                string firstName = data[2];
                string lastName = data[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(data[4]);

                    soldiers.Add(id, new Private(id, firstName, lastName, salary));
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(data[4]);

                    ILieutenantGeneral leutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < data.Length; i++)
                    {
                        string privateId = data[i];

                        if (!soldiers.ContainsKey(privateId))
                        {
                            continue;

                        }
                        leutenantGeneral.AddPrivate((IPrivate)soldiers[privateId]);
                    }

                    soldiers.Add(id, leutenantGeneral);
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(data[4]);

                    bool isCorpsValid = Enum.TryParse(data[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string part = data[i];
                        int hoursWorked = int.Parse(data[i + 1]);

                        IRepair repair = new Repair(part, hoursWorked);
                        engineer.AddRepair(repair);
                    }
                    soldiers.Add(id, engineer);
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(data[4]);

                    bool isCorpsValid = Enum.TryParse(data[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string codeName = data[i];
                        string state = data[i + 1];

                        bool isMissionStateValid = Enum.TryParse(state, out MissionState missionState);

                        if (!isMissionStateValid)
                        {
                            continue;
                        }
                        IMission mission = new Mission(codeName, missionState);
                        commando.AddMission(mission);
                    }

                    soldiers.Add(id, commando);
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(data[4]);
                    soldiers.Add(id, new Spy(id, firstName, lastName, codeNumber));
                }
            }

            foreach (var soldier in soldiers.Values)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
