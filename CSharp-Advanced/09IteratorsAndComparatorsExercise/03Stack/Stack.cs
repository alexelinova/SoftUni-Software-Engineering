using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;

        public Stack()
        {
            this.collection = new List<T>();
        }

        public void Push(T element)
        {
            collection.Insert(collection.Count, element);
        }
        public T Pop()
        {
            if (collection.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            T removed = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);

            return removed;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
