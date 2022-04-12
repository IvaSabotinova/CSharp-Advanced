using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace T07TupleVer2
{
    public class MyTuple<TItem1, TItem2>
    {

        public TItem1 FirstItem { get; set; }
        public TItem2 SecondItem { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FirstItem} -> {SecondItem}");
            return sb.ToString().TrimEnd();
        }
    }
}
