using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {
                 people = ReadPeople();
                 products = ReadProduct();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                string product = info[1];

                Person currPerson = people[name];
                Product currProduct = products[product];

                try
                {
                    currPerson.BuyProduct(currProduct);
                    Console.WriteLine($"{currPerson.Name} bought {currProduct}");
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
               
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.Value);
            }
        }

        private static Dictionary<string, Product> ReadProduct()
        {
            Dictionary<string, Product> result = new Dictionary<string, Product>(); ;

            string[] productsInfo = Console.ReadLine()
                .Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsInfo.Length; i++)
            {
                string[] info = productsInfo[i].Split("=");
                Product product = new Product(info[0], decimal.Parse(info[1]));
                result.Add(info[0], product);
            }

            return result;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            Dictionary<string, Person> result = new Dictionary<string, Person>();

            string[] peopleInfo = Console.ReadLine()
                .Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleInfo.Length; i++)
            {
                string[] info = peopleInfo[i].Split("=");
                Person person = new Person(info[0], decimal.Parse(info[1]));
                result.Add(info[0], person);
            }

            return result;
        }
    }
}
