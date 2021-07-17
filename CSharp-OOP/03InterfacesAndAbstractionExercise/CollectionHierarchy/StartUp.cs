using CollectionHierarchy.Contracts;
using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            PrintAddedResults(input, addCollection);
            PrintAddedResults(input, addRemoveCollection);
            PrintAddedResults(input, myList);

            PrintRemovedResults(n, addRemoveCollection);
            PrintRemovedResults(n, myList);
           
        }

        private static void PrintAddedResults(string[] input, IAddCollection addCollection)
        {
            List<int> addedResults = new List<int>();

            foreach (var item in input)
            {
                addedResults.Add(addCollection.Add(item));
            }

            Console.WriteLine(string.Join(" ", addedResults));
        }

        private static void PrintRemovedResults(int removeOperationsCount, IAddRemoveCollection collection)
        {
            List<string> removedResults = new List<string>();

            for (int i = 0; i < removeOperationsCount; i++)
            {
                removedResults.Add(collection.Remove());
            }

            Console.WriteLine(string.Join(" ",removedResults));
        }
    }
}
