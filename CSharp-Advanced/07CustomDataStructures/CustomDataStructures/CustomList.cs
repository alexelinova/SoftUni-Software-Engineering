using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomList<T>
    {
        public T[] items;

        private const int InitialCapacity = 2;

        public CustomList()
        {
            this.items = new T[InitialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.items[index];
            }

            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            }

        }

        public void Add(T element)
        {
            EnsureCapacity();
            this.items[Count] = element;
            this.Count++;
        }
        private void EnsureCapacity()
        {
            if (this.items.Length > this.Count)
            {
                return;
            }
            T[] newarr = new T[this.items.Length * 2];

            // Array.Copy(this.items, newarr, this.items.Length); - alternative 

            for (int i = 0; i < this.items.Length; i++)
            {
                newarr[i] = this.items[i];
            }

            this.items = newarr;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

        }

        public T RemoveAt(int index)
        {
            ValidateIndex(index);
            T removedElement = this.items[index];

            ShiftLeft(index);
            Count--;
            Shrink();

            return removedElement;
        }

        public void InsertAt(int index, T element)
        {
            ValidateIndex(index);
            EnsureCapacity();
            Count++;
            ShiftRight(index);
            this.items[index] = element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            T temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        public void Reverse()
        {
            for (int i = 0; i < this.Count / 2; i++)
            {
                Swap(i, this.Count - 1 - i);
            }
        }

        public override string ToString()
        {
            return string.Join(" ", this.items);
        }

        private void Shrink()
        {
            if (this.Count * 4 < this.items.Length)
            {
                T[] newarr = new T[this.items.Length / 2];

                for (int i = 0; i < this.Count; i++)
                {
                    newarr[i] = this.items[i];
                }

                this.items = newarr;
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[Count - 1] = default;
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
    }
}
