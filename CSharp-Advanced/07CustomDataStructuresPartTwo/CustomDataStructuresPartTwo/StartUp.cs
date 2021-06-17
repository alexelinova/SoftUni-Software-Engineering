using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<int> linkedlist = new DoublyLinkedList<int>();

            linkedlist.AddFirst(1);
        }
    }
}
