using System;

namespace T06GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Box<double> allElements = new Box<double>();

            for (int i = 0; i < numOfLines; i++)
            {
                double item = double.Parse(Console.ReadLine());

                allElements.Add(item);
            }
            double itemToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(allElements.CountOfLargerElements(itemToCompare));
        }
    }
}
