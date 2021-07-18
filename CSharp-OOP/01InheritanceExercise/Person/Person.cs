using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
        public virtual int Age
        {
            get { return this.age; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative.");
                }

                this.age = value;
            }
        }

        public string Name { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.Name}, Age: {this.Age}");
            return sb.ToString().TrimEnd();
        }
    }
}
