using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Beast")
                {
                    break;
                }

                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                if (string.IsNullOrEmpty(name) 
                    || age < 0
                    || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                }

                if (input == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (input == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (input == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if (input == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                }
                else if (input == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }

            }
        }
    }
}
