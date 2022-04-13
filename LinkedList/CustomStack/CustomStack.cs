using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    class CustomStack
    {
        public CustomStack()
        {
            Count = 0;
            items = new int[initialCapacity];
        }
        private int[] items;
        private const int initialCapacity = 4;
        public int Count { get; set; }

        public void Push(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = element;
            Count++;
        }

        public void Resize()
        {
            int[] copy = new int[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public int Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException();
            }
            
            int result = items[Count - 1];
            items[Count - 1] = default(int);
            Count--;
            if (Count <= items.Length / 4)
            {
                int[] copy = new int[items.Length / 2];
                for (int i = 0; i < items.Length / 2; i++)
                {
                    copy[i] = items[i];
                }

                items = copy;
            }

            return result;

        }
        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            int result = items[Count - 1];
            return result;
        }


        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }

        public Action<object> action()
        {
            return x => Console.WriteLine(x);
        }
    }
}
