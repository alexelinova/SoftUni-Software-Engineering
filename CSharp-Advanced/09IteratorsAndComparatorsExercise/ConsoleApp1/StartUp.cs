using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] personInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int NthPerson = int.Parse(Console.ReadLine());

            Person targetPerson = people[NthPerson - 1];

            int matches = CountEqualPeople(targetPerson, people);
            int difference = CountDifferentPeople(targetPerson, people);

            if (matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {difference} {people.Count}");
            }
        }

        private static int CountDifferentPeople(Person targetPerson, List<Person> people)
        {
            int differentCount = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (targetPerson.CompareTo(people[i]) != 0)
                {
                    differentCount++;
                }
            }

            return differentCount;
        }

        private static int CountEqualPeople(Person targetPerson, List<Person> people)
        {
            int equalCount = 0;

            for (int i = 1; i < people.Count; i++)
            {
                if (targetPerson.CompareTo(people[i]) == 0)
                {
                    equalCount++;
                }
            }

            return equalCount;
        }
    }
}
