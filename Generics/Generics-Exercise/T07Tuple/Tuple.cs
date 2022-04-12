using System;
using System.Collections.Generic;
using System.Text;

namespace T07Tuple
{
    public class Tuple<T> where T: IComparable
    {
        
        private readonly List<(T, T)> data;
        public Tuple()
        {
            data = new List<(T, T)>();
        }
      

        public void AddLine(T item1, T item2)
        {
            data.Add((item1, item2));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach ((T, T) item in data)
            {
                sb.AppendLine($"{item.Item1} -> {item.Item2}");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
