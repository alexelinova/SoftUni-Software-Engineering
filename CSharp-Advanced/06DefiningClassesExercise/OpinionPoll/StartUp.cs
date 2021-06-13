using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
     public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            List<Person> sorted = people.Where(x => x.Age > 30).OrderBy(n => n.Name).ToList();

            foreach (Person person in sorted)
            {
                Console.WriteLine(person);
            }
        }
    }
}
