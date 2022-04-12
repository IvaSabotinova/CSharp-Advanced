using System;
using System.Collections.Generic;
using System.Linq;

namespace T04AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, double> priceWithVAT = p => double.Parse(p) * 1.20;

            Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => priceWithVAT(x)).ToList().ForEach(w => Console.WriteLine($"{w:f2}"));


        }
    }
}