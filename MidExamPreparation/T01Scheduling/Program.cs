using System;
using System.Collections.Generic;
using System.Linq;

namespace T01Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] taskElements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] threadElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int taskToRemove = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(taskElements);
            Queue<int> threads = new Queue<int>(threadElements);

            while (true)
            {
                if (tasks.Peek() == taskToRemove)
                {
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Pop()}");
                    Console.WriteLine(string.Join(" ", threads));
                    break;
                }
                if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
                
            }
            
        }
    }
}
