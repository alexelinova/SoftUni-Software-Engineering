using System;

namespace DefiningClasses
{
     public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person()
            {
                Name = "Pesho",
                Age = 20
            };

            Person secondPerson = new Person()
            {
                Name = "Gosho",
                Age = 18
            };

            Person thirdPerson = new Person()
            {
                Name = "Stamat",
                Age = 43
            };

        }
    }
}
