using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;

        private int index;

        public ListyIterator(params T[] collection)
        {
            this.collection = new List<T>(collection);
            this.index = 0;
        }
        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }
            return false;  
        }

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.collection[this.index]);
            }
        }            
        public bool HasNext()
        {
            if (this.index < this.collection.Count - 1)
            {
                return true;
            }
            return false;
        }

        public void PrintAll()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in collection)
            {
                sb.Append(item + " ");
            }

            string array = sb.ToString().TrimEnd();
            Console.WriteLine(array);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

