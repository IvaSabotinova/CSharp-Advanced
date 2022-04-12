using System;

namespace T07Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tuple<string> output = new Tuple<string>();

            string[] firstLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = firstLine[0] + " " + firstLine[1];
            output.AddLine(name, firstLine[2]);

            string[] secondLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            output.AddLine(secondLine[0], secondLine[1]);

            string[] thirdLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            output.AddLine(thirdLine[0], thirdLine[1]);

            Console.WriteLine(output.ToString());
        }

    }
}
