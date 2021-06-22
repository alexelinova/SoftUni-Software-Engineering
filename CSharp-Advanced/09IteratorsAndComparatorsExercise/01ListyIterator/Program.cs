using System;
using System.Linq;

namespace _01ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] collectionInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            ListyIterator<string> collection = new ListyIterator<string>(collectionInfo);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (input == "HasNext")
                {
                    Console.WriteLine(collection.HasNext());
                }
                else if (input == "Move")
                {
                    Console.WriteLine(collection.Move());
                }
                else if (input == "Print")
                {
                    try
                    {
                        collection.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message); 
                    }
                }
                else if (input == "PrintAll")
                {
                    collection.PrintAll();
                }
            }
        }
    }
}
