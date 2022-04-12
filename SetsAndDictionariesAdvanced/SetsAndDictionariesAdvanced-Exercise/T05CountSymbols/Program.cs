using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace T05CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();

            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {

                if (symbols.ContainsKey(text[i]) == false)
                {
                    symbols.Add(text[i], 0);
                }

                symbols[text[i]]++;

            }

            foreach (KeyValuePair<char, int> symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }

        }
    }
}
