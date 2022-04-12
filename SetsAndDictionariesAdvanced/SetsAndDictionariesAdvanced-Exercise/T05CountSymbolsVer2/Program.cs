using System;
using System.Collections.Generic;
using System.Linq;

namespace T05CountSymbolsVer2
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();

            Dictionary<char, int> symbols = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {

                if (symbols.ContainsKey(text[i]) == false)
                {
                    symbols.Add(text[i], 0);
                }

                symbols[text[i]]++;

            }

            List<char> list = symbols.Keys.ToList();
            list.Sort();

            foreach (char symbol in list)
            {
                Console.WriteLine($"{symbol}: {symbols[symbol]} time/s");
            }

        }
    }
}
