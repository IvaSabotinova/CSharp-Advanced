using System;
using System.Collections.Generic;
using System.Text;

namespace T08Threeuple
{
    public class Threeuple<TItem1, TItem2, TItem3>
    {
        public TItem1 FirstItem { get; set; }
        public TItem2 SecondItem { get; set; }
        public TItem3 ThirdItem { get; set; }

      public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FirstItem} -> {SecondItem} -> {ThirdItem}");
            return sb.ToString().TrimEnd();
        }

    }
}
