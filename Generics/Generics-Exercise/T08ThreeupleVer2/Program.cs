using System;

namespace T08ThreeupleVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<string> output = new Tuple<string>();

            string[] firstLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = firstLine[0] + " " + firstLine[1];
            output.AddLine(name, firstLine[2], string.Join(" ", firstLine[3..^0]));

            string[] secondLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double litresBeer = double.Parse(secondLine[1]);
            bool isDrunk = secondLine[2] == "drunk";
            output.AddLine(secondLine[0], $"{litresBeer}", isDrunk.ToString());

            string[] thirdLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double accBalance = double.Parse(thirdLine[1]);
            output.AddLine(thirdLine[0], $"{accBalance}", thirdLine[2]);

            Console.WriteLine(output.ToString());
        }
    }
}
