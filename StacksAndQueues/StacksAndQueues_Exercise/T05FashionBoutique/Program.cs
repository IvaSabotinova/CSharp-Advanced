using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T05FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            int newRack = rackCapacity;

            Stack<int> stack = new Stack<int>(input);

            int numberOfRacks = 1;


            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (stack.Count == 0)
                {
                    break;
                }

                if (rackCapacity - input[i] >= 0)
                {
                    rackCapacity -= stack.Pop();

                }
                else
                {
                    rackCapacity = newRack;
                    numberOfRacks++;
                    rackCapacity -= stack.Pop();
                }

            }

            Console.WriteLine(numberOfRacks);

        }
    }
}
