using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(", ");
                string name = line[0];
                int age = int.Parse(line[1]);

                Person person = new Person
                {
                    Name = name,
                    Age = age
                };

                people.Add(person);
            }

            string comparison = Console.ReadLine();
            int compareParameter = int.Parse(Console.ReadLine());

            Func<Person, bool> predicate;

            if (comparison == "older")
            {
                predicate = p => p.Age >= compareParameter;
            }
            else
            {
                predicate = p => p.Age < compareParameter;
            }

            List<Person> filtered = people.Where(predicate).ToList();

            string format = Console.ReadLine();

            foreach (var person in filtered)
            {
                if (format == "name age")
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
                else
                {
                    Console.WriteLine(person.Name);
                }
            }
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
