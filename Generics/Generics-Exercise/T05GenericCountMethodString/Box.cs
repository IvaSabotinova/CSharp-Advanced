using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T05GenericCountMethodString
{
    public class Box<T> where T : IComparable
    {

        private readonly List<T> allElements;

        public Box()
        {
            allElements = new List<T>();
        }

        public void Add(T element)
        {
            allElements.Add(element);
        }

        public int CountOfLargerElements(T element)
        {

            int count = allElements.Where(x => element.CompareTo(x) < 0).Count();
            return count;
        }

    }
}
