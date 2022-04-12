using System;
using System.Linq;

namespace T05GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int numOfLines = int.Parse(Console.ReadLine());
            Box<string> allElements = new Box<string>();

            for (int i = 0; i < numOfLines; i++)
            {
                string elements = Console.ReadLine();

                allElements.Add(elements);
            }
            string element = Console.ReadLine();

            Console.WriteLine(allElements.CountOfLargerElements(element));
            
        }
    }
}
