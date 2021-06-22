using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] personInfo = input.Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                Person person = new Person(name, town, age);

                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            Person currentPerson = people[index];

            int matches = 1;

            foreach (var person in people)
            {
                if (person.CompareTo(currentPerson) == 0 && !person.Equals(currentPerson))
                {
                    matches++;
                }
            }

            if (matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }

        }
    }
}
