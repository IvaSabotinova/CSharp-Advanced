using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> list;

        private int currentIndex = 0;

        public ListyIterator(params T[] collection)
        {
            list = new List<T>(collection);
        }

        public bool MoveNext()
        {
            if (HasNext())
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return currentIndex < list.Count - 1;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine(list[currentIndex]);
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", list));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
