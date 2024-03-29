﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleApp1
{
    class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Town = town;
            Age = age;
        }

        public string Name { get; set; }
        public string Town { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Age.CompareTo(other.Age) !=0)
            {
                return this.Age.CompareTo(other.Age);
            }

            return this.Town.CompareTo(other.Town);
        }
    }
}
