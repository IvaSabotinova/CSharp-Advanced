using System;
using System.Collections.Generic;
using System.Linq;

namespace T01CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                .ToArray();

            Dictionary<double, int> valuesCount = new Dictionary<double, int>();

            for (int i = 0; i < values.Length; i++)
            {
                if (!valuesCount.ContainsKey(values[i]))
                {
                    valuesCount.Add(values[i], 0);
                }

                valuesCount[values[i]]++;

            }

            foreach (KeyValuePair<double, int> value in valuesCount)
            {
                Console.WriteLine($"{value.Key} - {value.Value} times");
            }


        }
    }
}
