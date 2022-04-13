using System;
using System.Collections.Generic;

using System.Text;

namespace CustomList
{
    class CustomList
    {
        public CustomList()
        {
            items = new int[InitialCapacity];
        }

        private int[] items;
        private const int InitialCapacity = 2;

        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index] = value;
            }

        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public void Add(int item)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = item;
            Count++;

        }

        public void Print()
        {
            Console.WriteLine(string.Join(" ", items));

        }
        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        public void Shrink()
        {
            int[] copy = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;

        }

        public int RemoveAt(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int result = items[index];
            items[index] = default(int);
            Shift(index);
            items[Count - 1] = default(int);
            Count--;
            if (Count <= items.Length / 4)
            {
                Shrink();
            }
            return result;

        }

        public void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }

        public void Insert(int index, int item)
        {
            if (index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Count == items.Length)
            {
                Resize();
            }
            if (index == Count)
            {
                Add(item);
                
            }
            ShiftToRight(index);
            items[index] = item;
            Count++;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >=Count || secondIndex >=Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
    }
}
