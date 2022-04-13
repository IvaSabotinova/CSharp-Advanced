using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        private IComparable<Book> books;

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = new List<string>(authors);
        }

        public int CompareTo(Book other)
        {
            if (this.Year > other.Year)
            {
                return 1;
            }

            if (this.Year < other.Year)
            {
                return -1;
            }
            else
            {
                return Title.CompareTo(other.Title);

                //if (Title.CompareTo(other.Title) > 0)
                //{
                //    return 1;
                //}

                //if (Title.CompareTo(other.Title) < 0)
                //{
                //    return -1;
                //}
                //else
                //{
                //    return 0;
                //}
            }

        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }

    public class BookComparator : IComparer<Book>
    {
        //private IComparer<Book> _books;
        public int Compare(Book x, Book y)
        {
            int result = x.Title.CompareTo(y.Title);
            if (result == 0)
            {
                result = y.Year.CompareTo(x.Year);
            }

            return result;

        }
    }
}
