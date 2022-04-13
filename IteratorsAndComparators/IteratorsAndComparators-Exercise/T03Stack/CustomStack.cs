using System;
using System.Collections;
using System.Collections.Generic;



namespace T03Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private readonly List<T> list;

        public CustomStack(params T[] data)
        {
            list = new List<T>(data);
        }

        public void Push(params T[] items)
        {
            foreach (T item in items)
            {
                list.Insert(list.Count, item);
            }

        }

        public void Pop()
        {
           list.Remove(list[list.Count - 1]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
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
