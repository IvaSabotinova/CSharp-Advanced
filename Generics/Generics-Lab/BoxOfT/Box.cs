using System;
using System.Collections.Generic;
using System.Linq;


namespace BoxOfT
{
    public class Box<T>
    {
        private readonly Stack<T> stack;
        public Box()
        {
            stack = new Stack<T>();

        }

        public int Count
        {
            get
            {
                return stack.Count;
            }
        }

        public void Add(T element)
        {
            stack.Push(element);
        }

        public T Remove()
        {

            if (stack.Count > 0)
            {
                return stack.Pop();
            }
            return default;

        }

    }
}