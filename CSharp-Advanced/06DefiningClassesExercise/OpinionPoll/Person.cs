
namespace DefiningClasses
{
     public class Person
    {
        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age)
            : this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
            : this(age)
        {
            this.Name = name;
        }

        public int Age { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Age}";
        }
    }
}
