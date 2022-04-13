using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CustomList
{
    class StartUp
    {
        static void Main(string[] args)
        {

            CustomList integers = new CustomList();
            integers.Add(5 );
            integers.Add(57 );
            integers.Add(58 );
            integers.Add(60 );
            integers.Add(62 );
            integers.Add(66 );
            integers.Add(133 );
            integers.RemoveAt(2);
            
            integers.Insert(2, 39);
            integers.Print();
            
        }
    }
}
