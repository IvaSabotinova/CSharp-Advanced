using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T06SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string commands = Console.ReadLine();
                

                if (commands == "Play")
                {
                    queue.Dequeue();
                }
                else if (commands.Substring(0,4) == "Add ")
                {
                    string song = commands.Substring(4);
                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }

                }
                else if (commands.Substring(0, 4) == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue));
                }
                
            }

            Console.WriteLine("No more songs!");

            
        }
    }
}
