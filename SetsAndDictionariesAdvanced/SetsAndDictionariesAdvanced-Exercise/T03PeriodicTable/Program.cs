using System;
using System.Collections.Generic;

namespace T03PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            SortedSet<string> uniqueChemElements = new SortedSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] chemElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < chemElements.Length; j++)
                {
                    uniqueChemElements.Add(chemElements[j]);
                }

            }
            Console.WriteLine(string.Join(" ", uniqueChemElements));

        }
    }
}
