using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        List<T> collection;

        public Box()
        {
            this.collection = new List<T>();
        }
        public int Count => this.collection.Count;

        public void Add(T element)
        {
            this.collection.Add(element);
        }

        public T Remove()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("The box is empty");
            }

            T removed = this.collection[collection.Count - 1];
            this.collection.RemoveAt(collection.Count - 1);

            return removed;
        }
    }
}
