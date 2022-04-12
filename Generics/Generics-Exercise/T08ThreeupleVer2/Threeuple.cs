using System;
using System.Collections.Generic;
using System.Text;

namespace T08ThreeupleVer2
{
    public class Tuple<T> where T : IComparable
    {

        private readonly List<(T, T, T)> data;
        public Tuple()
        {
            data = new List<(T, T, T)>();
        }


        public void AddLine(T item1, T item2, T item3)
        {
            data.Add((item1, item2, item3));
        }

       public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach ((T, T, T) item in data)
            {
                sb.AppendLine($"{item.Item1} -> {item.Item2} -> {item.Item3}");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
