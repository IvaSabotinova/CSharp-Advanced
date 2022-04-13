using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    class ListyIterator<T>
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


    }
}
