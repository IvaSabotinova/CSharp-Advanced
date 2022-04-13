using System;
using System.Collections;
using System.Collections.Generic;


namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {

        private SortedSet<Book> books { get; set; }

        public Library(params Book[] _books)
        {
            this.books = new SortedSet<Book>(_books, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex = -1;

            public LibraryIterator(IEnumerable<Book> _books)
            {
                this.books = new List<Book>(_books);
            }

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }
        }
    }
}