using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> firstCollection = new SortedSet<Person>();
            HashSet<Person> secondCollection = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personIfo = Console.ReadLine().Split();
                string name = personIfo[0];
                int age = int.Parse(personIfo[1]);

                Person person = new Person(name, age);

                firstCollection.Add(person);
                secondCollection.Add(person);
            }

            Console.WriteLine(firstCollection.Count);
            Console.WriteLine(secondCollection.Count);
        }
    }
}
