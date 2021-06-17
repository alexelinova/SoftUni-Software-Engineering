using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private class ListNode
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
            public T Value { get; set; }
        }

        private ListNode head;

        private ListNode tail;
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            ListNode newHead = new ListNode(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            ListNode newTail = new ListNode(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("DoubleLinkedList is empty");
            }

            T firstElement = this.head.Value;

            ListNode newHead = this.head.NextNode;
            this.head = newHead;

            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("DoubleLinkedList is empty");
            }
            T removedElement = this.tail.Value;

            ListNode newTail = this.tail.PreviousNode;

            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                newTail.NextNode = null;
                this.tail = newTail;
            }
            this.Count--;
            return removedElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.NextNode;
            }
        }

        public void Clear()
        {
            this.head = this.tail = null;
            Count = 0;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            ListNode currentNode = this.head;

            int counter = 0;

            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                counter++; 
               currentNode = currentNode.NextNode;
            }

            return array;
        }
    }
}
