using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);

            BookComparator bookComp = new BookComparator();
            this.books.Sort(bookComp);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;

            private int currentIndex = -1;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }

            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            
            }

            public bool MoveNext()
            {
                this.currentIndex++;

                if (currentIndex >= books.Count)
                {
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
