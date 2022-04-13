using System;
using System.Collections.Generic;
using System.Linq;

namespace T01TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOrcWaves = int.Parse(Console.ReadLine());

            int[] defence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> platesOfDefence = new Queue<int>(defence);
            Stack<int> orcs = new Stack<int>();

            bool isBreak = false;

            for (int i = 1; i <= numberOfOrcWaves; i++)
            {
                int[] orcWaves = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                orcs = new Stack<int>(orcWaves);

                if (i % 3 == 0)
                {
                    platesOfDefence.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (orcs.Count > 0)
                {
                    if (platesOfDefence.Count == 0)
                    {
                        isBreak = true;
                        break;
                    }

                    if (orcs.Peek() > platesOfDefence.Peek())
                    {

                        orcs.Push(orcs.Pop() - platesOfDefence.Dequeue());

                    }
                    else if (orcs.Peek() < platesOfDefence.Peek())
                    {
                        Queue<int> updatedPlatesOfDefence = new Queue<int>();
                        updatedPlatesOfDefence.Enqueue(platesOfDefence.Dequeue() - orcs.Pop());

                        for (int j = 0; j < platesOfDefence.Count; j++)
                        {
                            updatedPlatesOfDefence.Enqueue(platesOfDefence.ElementAt(j));
                        }

                        platesOfDefence = updatedPlatesOfDefence;
                    }
                    else
                    {
                        orcs.Pop();
                        platesOfDefence.Dequeue();

                    }

                }

                if (isBreak)
                {
                    break;
                }
            }

            if (platesOfDefence.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesOfDefence)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }


        }
    }
}
