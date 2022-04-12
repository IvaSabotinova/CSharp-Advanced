using System;
using System.Collections.Generic;
using System.Text;

namespace T01GenericBoxOfString
{
    public class Box<T>
    {
       
        private readonly List<T> allboxes;
        
        public Box()
        {
            allboxes = new List<T>();

        }

        public void Add(T element)
        {
            allboxes.Add(element);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T line in allboxes)
            {
                sb.AppendLine($"{line.GetType().FullName}: {line}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }

}
