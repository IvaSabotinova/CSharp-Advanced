using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CustomQueue
{
    class CustomQueue
    {

        private int[] items;
        private const int initialCapacity = 4;
        private int count;
        public int Count => count;

        public CustomQueue()
        {
            items = new int[initialCapacity];
            count = 0;
        }

        public void Enqueue(int element)
        {
           
            if (count == items.Length)
            {
                int[] copy = new int[items.Length * 2];
                items.CopyTo(copy, 0);
                items = copy;
            }
            

            items[count] = element;
            count++;
        }
        public int Dequeue()
        {

            if (count == 0)
            {
                throw new InvalidOperationException("queue is empty");
            }

            int result = items[0];
            int[] copy = new int[items.Length];
            for (int i = 1; i <= count; i++)
            {
               copy[i - 1] = items[i];
               
            }
            items[0] = default(int);
            items = copy;
            
            count--;
            
            if (count<= items.Length/ 4)
            {
                int[] newCopy = new int[items.Length / 2];
                for (int i = 0; i <= count; i++)
                {
                    newCopy[i] = items[i];
                }
                
                items = newCopy;
            }

            return result;
        }

        public int Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            int result = items[0];
            return result;
        }

        public void Clear()
        {
            while (count >0)
            {
                
                Dequeue();
                

            }
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < count; i++)
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
