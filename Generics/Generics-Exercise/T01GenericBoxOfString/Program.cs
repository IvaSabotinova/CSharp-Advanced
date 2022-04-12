using System;
using System.Collections.Generic;

namespace T01GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Box<string> content = new Box<string>();

            for (int i = 0; i < numOfLines; i++)
            {
                string line = Console.ReadLine();

                content.Add(line);
               
                
            }

            Console.WriteLine(content.ToString());
            
        }
    }
}
