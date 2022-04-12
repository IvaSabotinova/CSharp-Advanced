using System;

namespace T02GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Box<int> content = new Box<int>();

            for (int i = 0; i < numOfLines; i++)
            {
                int line = int.Parse(Console.ReadLine());

                content.Add(line);
            }

            Console.WriteLine(content.ToString());
        }
    }
}
