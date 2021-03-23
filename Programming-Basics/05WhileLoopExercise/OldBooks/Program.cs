using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookNeeded = Console.ReadLine();
            int bookCount = 0;
            string currentBook = Console.ReadLine();
            bool bookFound = false;
            while (currentBook != "No More Books")
            {
                if (currentBook == bookNeeded)
                {
                    bookFound = true;
                    break;
                }
                bookCount++;
                currentBook = Console.ReadLine();
            }
            if (bookFound)
            {
                Console.WriteLine($"You checked {bookCount} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {bookCount} books.");
            }
        }
    }
}
